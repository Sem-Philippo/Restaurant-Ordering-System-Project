namespace UI.Stocks_UI
{
    partial class AddEmployee
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
            button1 = new Button();
            label1 = new Label();
            firstNameTxt = new TextBox();
            lastNameTxt = new TextBox();
            label2 = new Label();
            pinTxt = new TextBox();
            label3 = new Label();
            label4 = new Label();
            roleComboBox = new ComboBox();
            idTxt = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(177, 466);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Done";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 142);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 1;
            label1.Text = "First name";
            // 
            // firstNameTxt
            // 
            firstNameTxt.Location = new Point(309, 137);
            firstNameTxt.Name = "firstNameTxt";
            firstNameTxt.Size = new Size(125, 27);
            firstNameTxt.TabIndex = 2;
            // 
            // lastNameTxt
            // 
            lastNameTxt.Location = new Point(309, 192);
            lastNameTxt.Name = "lastNameTxt";
            lastNameTxt.Size = new Size(125, 27);
            lastNameTxt.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(104, 197);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 3;
            label2.Text = "Last name";
            // 
            // pinTxt
            // 
            pinTxt.Location = new Point(309, 246);
            pinTxt.Name = "pinTxt";
            pinTxt.Size = new Size(125, 27);
            pinTxt.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(104, 251);
            label3.Name = "label3";
            label3.Size = new Size(32, 20);
            label3.TabIndex = 5;
            label3.Text = "PIN";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(104, 311);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 7;
            label4.Text = "Role";
            // 
            // roleComboBox
            // 
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Location = new Point(283, 311);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(151, 28);
            roleComboBox.TabIndex = 8;
            // 
            // idTxt
            // 
            idTxt.Location = new Point(309, 104);
            idTxt.Name = "idTxt";
            idTxt.Size = new Size(125, 27);
            idTxt.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(104, 109);
            label5.Name = "label5";
            label5.Size = new Size(24, 20);
            label5.TabIndex = 9;
            label5.Text = "ID";
            // 
            // AddEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 582);
            Controls.Add(idTxt);
            Controls.Add(label5);
            Controls.Add(roleComboBox);
            Controls.Add(label4);
            Controls.Add(pinTxt);
            Controls.Add(label3);
            Controls.Add(lastNameTxt);
            Controls.Add(label2);
            Controls.Add(firstNameTxt);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "AddEmployee";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox firstNameTxt;
        private TextBox lastNameTxt;
        private Label label2;
        private TextBox pinTxt;
        private Label label3;
        private Label label4;
        private ComboBox roleComboBox;
        private TextBox idTxt;
        private Label label5;
    }
}