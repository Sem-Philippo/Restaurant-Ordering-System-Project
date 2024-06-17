namespace UI
{
    partial class AdjustStock
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
            menuItemsCombo = new ComboBox();
            adjustButton = new Button();
            stockBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // menuItemsCombo
            // 
            menuItemsCombo.FormattingEnabled = true;
            menuItemsCombo.Location = new Point(138, 61);
            menuItemsCombo.Name = "menuItemsCombo";
            menuItemsCombo.Size = new Size(121, 23);
            menuItemsCombo.TabIndex = 0;
            // 
            // adjustButton
            // 
            adjustButton.Location = new Point(155, 217);
            adjustButton.Name = "adjustButton";
            adjustButton.Size = new Size(81, 23);
            adjustButton.TabIndex = 1;
            adjustButton.Text = "Done";
            adjustButton.UseVisualStyleBackColor = true;
            adjustButton.Click += adjustButton_Click;
            // 
            // stockBox
            // 
            stockBox.Location = new Point(138, 140);
            stockBox.Name = "stockBox";
            stockBox.Size = new Size(121, 23);
            stockBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 143);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 3;
            label1.Text = "Stock";
            // 
            // AdjustStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 313);
            Controls.Add(label1);
            Controls.Add(stockBox);
            Controls.Add(adjustButton);
            Controls.Add(menuItemsCombo);
            Name = "AdjustStock";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox menuItemsCombo;
        private Button adjustButton;
        private TextBox stockBox;
        private Label label1;
    }
}