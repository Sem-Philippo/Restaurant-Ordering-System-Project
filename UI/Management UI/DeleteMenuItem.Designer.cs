namespace UI
{
    partial class DeleteMenuItem
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
            menuItemBox = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // menuItemBox
            // 
            menuItemBox.FormattingEnabled = true;
            menuItemBox.Location = new Point(10, 22);
            menuItemBox.Margin = new Padding(3, 2, 3, 2);
            menuItemBox.Name = "menuItemBox";
            menuItemBox.Size = new Size(365, 23);
            menuItemBox.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(87, 122);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(217, 36);
            button1.TabIndex = 1;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DeleteMenuItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 306);
            Controls.Add(button1);
            Controls.Add(menuItemBox);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DeleteMenuItem";
            Text = "Form1";
           
            ResumeLayout(false);
        }

        #endregion

        private ComboBox menuItemBox;
        private Button button1;
    }
}