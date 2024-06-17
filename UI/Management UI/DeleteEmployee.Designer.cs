namespace UI.Stocks_UI
{
    partial class DeleteEmployee
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
            deleteButton = new Button();
            deleteCombo = new ComboBox();
            SuspendLayout();
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(78, 173);
            deleteButton.Margin = new Padding(3, 2, 3, 2);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(82, 22);
            deleteButton.TabIndex = 0;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // deleteCombo
            // 
            deleteCombo.FormattingEnabled = true;
            deleteCombo.Location = new Point(59, 106);
            deleteCombo.Margin = new Padding(3, 2, 3, 2);
            deleteCombo.Name = "deleteCombo";
            deleteCombo.Size = new Size(133, 23);
            deleteCombo.TabIndex = 1;
            // 
            // DeleteEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 269);
            Controls.Add(deleteCombo);
            Controls.Add(deleteButton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DeleteEmployee";
            Text = "DeleteEmployee";
            ResumeLayout(false);
        }

        #endregion

        private Button deleteButton;
        private ComboBox deleteCombo;
    }
}