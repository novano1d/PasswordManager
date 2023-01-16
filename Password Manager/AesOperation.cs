using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace Password_Manager
{
    public class AesOperation
    {
        public static string EncryptString(string plainText, string passPhrase)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes("jambo16bytesX3XD");
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                PasswordDeriveBytes password = new PasswordDeriveBytes
                (
                    passPhrase,
                    null
                );

                byte[] keyBytes = password.GetBytes(256 / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                symmetricKey.Padding = PaddingMode.PKCS7;
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor
                (
                    keyBytes,
                    initVectorBytes
                );
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream
                (
                    memoryStream,
                    encryptor,
                    CryptoStreamMode.Write
                );
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                string cipherText = Convert.ToBase64String(cipherTextBytes);

                return cipherText;
            }
            catch (Exception)
            {
                MessageBox.Show("Error Retrieving Password");
                return "";
            }
        }

        public static string DecryptString(string cipherText, string passPhrase)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes("jambo16bytesX3XD");
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                PasswordDeriveBytes password = new PasswordDeriveBytes
                (
                    passPhrase,
                    null
                );

                byte[] keyBytes = password.GetBytes(256 / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                symmetricKey.Padding = PaddingMode.PKCS7;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor
                (
                    keyBytes,
                    initVectorBytes
                );

                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream
                (
                    memoryStream,
                    decryptor,
                    CryptoStreamMode.Read
                );

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read
                (
                    plainTextBytes,
                    0,
                    plainTextBytes.Length
                );

                memoryStream.Close();
                cryptoStream.Close();
                string plainText = Encoding.UTF8.GetString
                (
                    plainTextBytes,
                    0,
                    decryptedByteCount
                );

                return plainText;
            }
            catch (Exception)
            {
                MessageBox.Show("This could result from an incorrect encryption key.", "Error Retrieving Password");
                return "";
            }
        }
    }
}
