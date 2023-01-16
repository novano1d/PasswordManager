using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Manager
{
    public partial class Form2 : Form
    {
        public string nameText;
        public string psswrdText;
        public Form2()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            nameText = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            psswrdText = textBox2.Text;
        }
    }
}
