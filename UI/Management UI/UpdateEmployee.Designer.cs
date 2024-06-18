namespace UI.Stocks_UI
{
    partial class UpdateEmployee
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
            label5 = new Label();
            roleComboBox = new ComboBox();
            label4 = new Label();
            lastNameTxt = new TextBox();
            label2 = new Label();
            firstNameTxt = new TextBox();
            label1 = new Label();
            doneButton = new Button();
            employeeBox = new ComboBox();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(71, 67);
            label5.Name = "label5";
            label5.Size = new Size(128, 20);
            label5.TabIndex = 20;
            label5.Text = "Choose Employee";
            // 
            // roleComboBox
            // 
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Location = new Point(250, 237);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(151, 28);
            roleComboBox.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(71, 237);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 18;
            label4.Text = "Role";
            // 
            // lastNameTxt
            // 
            lastNameTxt.Location = new Point(276, 168);
            lastNameTxt.Name = "lastNameTxt";
            lastNameTxt.Size = new Size(125, 27);
            lastNameTxt.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 173);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 14;
            label2.Text = "Last name";
            // 
            // firstNameTxt
            // 
            firstNameTxt.Location = new Point(276, 113);
            firstNameTxt.Name = "firstNameTxt";
            firstNameTxt.Size = new Size(125, 27);
            firstNameTxt.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 118);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 12;
            label1.Text = "First name";
            // 
            // doneButton
            // 
            doneButton.Location = new Point(144, 392);
            doneButton.Name = "doneButton";
            doneButton.Size = new Size(94, 29);
            doneButton.TabIndex = 11;
            doneButton.Text = "Done";
            doneButton.UseVisualStyleBackColor = true;
            doneButton.Click += button1_Click;
            // 
            // employeeBox
            // 
            employeeBox.FormattingEnabled = true;
            employeeBox.Location = new Point(250, 59);
            employeeBox.Name = "employeeBox";
            employeeBox.Size = new Size(151, 28);
            employeeBox.TabIndex = 21;
            // 
            // UpdateEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 450);
            Controls.Add(employeeBox);
            Controls.Add(label5);
            Controls.Add(roleComboBox);
            Controls.Add(label4);
            Controls.Add(lastNameTxt);
            Controls.Add(label2);
            Controls.Add(firstNameTxt);
            Controls.Add(label1);
            Controls.Add(doneButton);
            Name = "UpdateEmployee";
            Text = "UpdateEmployee";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private ComboBox roleComboBox;
        private Label label4;
        private TextBox lastNameTxt;
        private Label label2;
        private TextBox firstNameTxt;
        private Label label1;
        private Button doneButton;
        private ComboBox employeeBox;
    }
}