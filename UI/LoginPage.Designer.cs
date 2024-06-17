namespace UI
{
    partial class LoginPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblForgotPassword = new Label();
            btnlogin = new Button();
            btnSignUp = new Button();
            txtpassword = new TextBox();
            txtfirstName = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // lblForgotPassword
            // 
            lblForgotPassword.AutoSize = true;
            lblForgotPassword.Location = new Point(836, 660);
            lblForgotPassword.Margin = new Padding(6, 0, 6, 0);
            lblForgotPassword.Name = "lblForgotPassword";
            lblForgotPassword.Size = new Size(226, 37);
            lblForgotPassword.TabIndex = 19;
            lblForgotPassword.Text = "Forgot Password?";
            lblForgotPassword.Click += lblForgotPassword_Click;
            // 
            // btnlogin
            // 
            btnlogin.Location = new Point(733, 749);
            btnlogin.Margin = new Padding(6);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(176, 54);
            btnlogin.TabIndex = 18;
            btnlogin.Text = "Login";
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += btnlogin_Click_1;
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(994, 749);
            btnSignUp.Margin = new Padding(6);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(176, 54);
            btnSignUp.TabIndex = 17;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = true;
            // 
            // txtpassword
            // 
            txtpassword.Location = new Point(711, 562);
            txtpassword.Margin = new Padding(6);
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(454, 43);
            txtpassword.TabIndex = 16;
            // 
            // txtfirstName
            // 
            txtfirstName.Location = new Point(711, 466);
            txtfirstName.Margin = new Padding(6);
            txtfirstName.Name = "txtfirstName";
            txtfirstName.Size = new Size(454, 43);
            txtfirstName.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(546, 703);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(0, 37);
            label5.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(546, 562);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(134, 37);
            label4.TabIndex = 13;
            label4.Text = "Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(546, 466);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(101, 37);
            label2.TabIndex = 12;
            label2.Text = " Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(780, 309);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(233, 62);
            label1.TabIndex = 11;
            label1.Text = "Welcome";
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Chapau_removebg_preview_1;
            panel1.Location = new Point(22, 22);
            panel1.Margin = new Padding(6);
            panel1.Name = "panel1";
            panel1.Size = new Size(359, 166);
            panel1.TabIndex = 20;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1701, 1215);
            Controls.Add(panel1);
            Controls.Add(lblForgotPassword);
            Controls.Add(btnlogin);
            Controls.Add(btnSignUp);
            Controls.Add(txtpassword);
            Controls.Add(txtfirstName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(6, 7, 6, 7);
            Name = "LoginPage";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Button btnlogin;
        private Button btnSignUp;
        private TextBox txtpassword;
        private TextBox txtfirstName;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private Panel panel1;
        private Label lblForgotPassword;
    }
}