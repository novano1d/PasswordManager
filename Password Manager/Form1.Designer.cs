namespace Password_Manager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.psswrdLst = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.keybox = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.newPsswrdBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.clipboardBtn = new System.Windows.Forms.Button();
            this.resultPassword = new System.Windows.Forms.TextBox();
            this.removePswrdBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Passwords:";
            // 
            // psswrdLst
            // 
            this.psswrdLst.FormattingEnabled = true;
            this.psswrdLst.Location = new System.Drawing.Point(12, 25);
            this.psswrdLst.Name = "psswrdLst";
            this.psswrdLst.Size = new System.Drawing.Size(120, 199);
            this.psswrdLst.TabIndex = 1;
            this.psswrdLst.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.psswrdLst_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter Key Here:";
            // 
            // keybox
            // 
            this.keybox.Location = new System.Drawing.Point(138, 25);
            this.keybox.Name = "keybox";
            this.keybox.Size = new System.Drawing.Size(111, 20);
            this.keybox.TabIndex = 4;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Password Manager";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // newPsswrdBtn
            // 
            this.newPsswrdBtn.Location = new System.Drawing.Point(138, 51);
            this.newPsswrdBtn.Name = "newPsswrdBtn";
            this.newPsswrdBtn.Size = new System.Drawing.Size(111, 23);
            this.newPsswrdBtn.TabIndex = 5;
            this.newPsswrdBtn.Text = "Add New Password";
            this.newPsswrdBtn.UseVisualStyleBackColor = true;
            this.newPsswrdBtn.Click += new System.EventHandler(this.newPsswrdBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "Retrieve Selected Password";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // clipboardBtn
            // 
            this.clipboardBtn.Location = new System.Drawing.Point(138, 188);
            this.clipboardBtn.Name = "clipboardBtn";
            this.clipboardBtn.Size = new System.Drawing.Size(111, 36);
            this.clipboardBtn.TabIndex = 7;
            this.clipboardBtn.Text = "Copy Password To Clipboard";
            this.clipboardBtn.UseVisualStyleBackColor = true;
            this.clipboardBtn.Click += new System.EventHandler(this.clipboardBtn_Click);
            // 
            // resultPassword
            // 
            this.resultPassword.Location = new System.Drawing.Point(138, 150);
            this.resultPassword.Name = "resultPassword";
            this.resultPassword.Size = new System.Drawing.Size(111, 20);
            this.resultPassword.TabIndex = 8;
            // 
            // removePswrdBtn
            // 
            this.removePswrdBtn.Location = new System.Drawing.Point(138, 80);
            this.removePswrdBtn.Name = "removePswrdBtn";
            this.removePswrdBtn.Size = new System.Drawing.Size(111, 23);
            this.removePswrdBtn.TabIndex = 9;
            this.removePswrdBtn.Text = "Remove Password";
            this.removePswrdBtn.UseVisualStyleBackColor = true;
            this.removePswrdBtn.Click += new System.EventHandler(this.removePswrdBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 237);
            this.Controls.Add(this.removePswrdBtn);
            this.Controls.Add(this.resultPassword);
            this.Controls.Add(this.clipboardBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.newPsswrdBtn);
            this.Controls.Add(this.keybox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.psswrdLst);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Password Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox psswrdLst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox keybox;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button newPsswrdBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button clipboardBtn;
        private System.Windows.Forms.TextBox resultPassword;
        private System.Windows.Forms.Button removePswrdBtn;
    }
}

