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
            lunchDinner = new Button();
            drinkButton = new Button();
            dinnerButton = new Button();
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
            // lunchDinner
            // 
            lunchDinner.Location = new Point(321, 45);
            lunchDinner.Name = "lunchDinner";
            lunchDinner.Size = new Size(94, 29);
            lunchDinner.TabIndex = 2;
            lunchDinner.Text = "Lunch";
            lunchDinner.UseVisualStyleBackColor = true;
            // 
            // drinkButton
            // 
            drinkButton.Location = new Point(445, 45);
            drinkButton.Name = "drinkButton";
            drinkButton.Size = new Size(94, 29);
            drinkButton.TabIndex = 3;
            drinkButton.Text = "Drinks";
            drinkButton.UseVisualStyleBackColor = true;
            // 
            // dinnerButton
            // 
            dinnerButton.Location = new Point(569, 44);
            dinnerButton.Name = "dinnerButton";
            dinnerButton.Size = new Size(94, 29);
            dinnerButton.TabIndex = 4;
            dinnerButton.Text = "Dinner";
            dinnerButton.UseVisualStyleBackColor = true;
            // 
            // Stock
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 450);
            Controls.Add(dinnerButton);
            Controls.Add(drinkButton);
            Controls.Add(lunchDinner);
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
        private Button lunchDinner;
        private Button drinkButton;
        private Button dinnerButton;
    }
}