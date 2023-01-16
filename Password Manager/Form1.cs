using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Manager
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> psswrdMap = new Dictionary<string, string>(); //This creates a map of string to string where we're going to store our passwords and access them
        string directory;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //sets properties here:
            TopMost= true;
            keybox.PasswordChar = '*';
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            //try catch in case of problem reading file
            try
            {
                directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Password Manager");
                if (!System.IO.Directory.Exists(directory)) //Creates directory for the password manager files if the directory does not already exist
                {
                    System.IO.Directory.CreateDirectory(directory);
                }
                directory += "/pswrds.txt";
                if (!File.Exists(directory))
                {
                    FileStream fs = new FileStream(directory, FileMode.CreateNew); //creates text file if it doesn't exist
                    fs.Close();
                    return; //exits function since file didn't already exist and no passwords to read in
                }
                foreach (string line in System.IO.File.ReadLines(directory)) //if the file does exist this code will run and fill the listbox with the password list
                {
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        string name = line.Substring(0, line.IndexOf(''));
                        psswrdLst.Items.Add(name); //adds up to null character
                        psswrdMap.Add(name, line.Substring(line.IndexOf('') + 1)); //adds password (encrypted) to dictionary
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Try launching as admisistrator, or the pswrds.txt file has corrupted.", "Critical Error Reading From Password File"); //shows the user there was an error reading the password file
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //minimized to tray
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            //maximize
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void newPsswrdBtn_Click(object sender, EventArgs e)
        {
            //creates a custom dialog box to get user input
            using (Form2 form2 = new Form2())
            {
                if (form2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (String.IsNullOrWhiteSpace(form2.nameText) || String.IsNullOrWhiteSpace(form2.psswrdText))
                    {
                        MessageBox.Show("Cannot leave name or password blank!");
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(keybox.Text))
                    {
                        MessageBox.Show("You must include a key in the \'Enter Key Here:\' box for encryption.", "Cannot leave key blank for encryption!");
                        return;
                    }
                    if (keybox.Text.Length < 6)
                    {
                        MessageBox.Show("Encryption key should be at least 6 characters long!");
                        return;
                    }
                    if (psswrdMap.ContainsKey(form2.nameText))
                    {
                        MessageBox.Show("A password with this name already exists!");
                        return;
                    }
                    string encryptedPsswrdTxt = AesOperation.EncryptString(form2.psswrdText, keybox.Text);
                    psswrdMap.Add(form2.nameText, encryptedPsswrdTxt);
                    File.AppendAllText(directory, form2.nameText + '' + encryptedPsswrdTxt + Environment.NewLine);
                    psswrdLst.Items.Add(form2.nameText);
                }
            }
        }

        //retrieve password button
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(keybox.Text))
            {
                MessageBox.Show("You must include a key in the \'Enter Key Here:\' box for encryption.", "Cannot leave key blank for encryption!");
                return;
            }
            if (keybox.Text.Length < 6)
            {
                MessageBox.Show("Encryption key should be at least 6 characters long!");
                return;
            }
            //sets text of the textbox to the selected password
            try
            {
                resultPassword.Text = AesOperation.DecryptString(psswrdMap[psswrdLst.GetItemText(psswrdLst.SelectedItem)], keybox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("This could result from an incorrect encryption key.", "Error Retrieving Password");
            }
        }

        private void removePswrdBtn_Click(object sender, EventArgs e)
        {
            var selectedItem = psswrdLst.GetItemText(psswrdLst.SelectedItem);
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(directory).Where(l => !l.Substring(0, l.IndexOf('')).Equals(selectedItem));
            psswrdMap.Remove(selectedItem);
            psswrdLst.Items.Remove(psswrdLst.SelectedItem);
            File.WriteAllLines(tempFile, linesToKeep);
            File.Delete(directory);
            File.Move(tempFile, directory);
        }

        //if the user double clicks the listbox it'll put the result in the result box (for intuitivity) 
        private void psswrdLst_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button1_Click(sender, e);
        }

        private void clipboardBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(keybox.Text))
            {
                MessageBox.Show("You must include a key in the \'Enter Key Here:\' box for encryption.", "Cannot leave key blank for encryption!");
                return;
            }
            if (keybox.Text.Length < 6)
            {
                MessageBox.Show("Encryption key should be at least 6 characters long!");
                return;
            }
            //sets text of the textbox to the selected password
            try
            {
                Clipboard.SetText(AesOperation.DecryptString(psswrdMap[psswrdLst.GetItemText(psswrdLst.SelectedItem)], keybox.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("This could result from an incorrect encryption key.", "Error Retrieving Password");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a basic open source password manager that encrypts and stores your passwords in a text file. The text file is stored in %AppData% in the Password Manager folder. It is a good idea to back this file up onto the cloud or elsewhere for redundency.\nThe key is used for encryption and decryption so it is advisable to keep the same encrpytion key for all your passwords.", "Information");
        }

        private void openexplrBtn_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Password Manager"));
        }
    }
}
