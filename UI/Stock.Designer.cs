namespace UI
{
    partial class Stock
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
            stocksList = new ListView();
            label1 = new Label();
            SuspendLayout();
            // 
            // stocksList
            // 
            stocksList.Location = new Point(12, 100);
            stocksList.Name = "stocksList";
            stocksList.Size = new Size(730, 338);
            stocksList.TabIndex = 0;
            stocksList.UseCompatibleStateImageBehavior = false;
            stocksList.SelectedIndexChanged += stocksList_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(122, 46);
            label1.TabIndex = 1;
            label1.Text = "Stocks";
            label1.UseWaitCursor = true;
            label1.Click += label1_Click;
            // 
            // Stock
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 450);
            Controls.Add(label1);
            Controls.Add(stocksList);
            Name = "Stock";
            Text = "Stock";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView stocksList;
        private Label label1;
    }
}