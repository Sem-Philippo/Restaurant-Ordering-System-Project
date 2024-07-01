namespace UI.UserControls
{
    partial class OrderItemUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblDishName = new Label();
            btnIncrease = new Button();
            btnDecrease = new Button();
            lblAmount = new Label();
            btnComment = new Button();
            SuspendLayout();
            // 
            // lblDishName
            // 
            lblDishName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDishName.Location = new Point(0, 0);
            lblDishName.Name = "lblDishName";
            lblDishName.Padding = new Padding(5);
            lblDishName.Size = new Size(181, 65);
            lblDishName.TabIndex = 0;
            lblDishName.Text = "DishName";
            lblDishName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnIncrease
            // 
            btnIncrease.Location = new Point(260, 19);
            btnIncrease.Name = "btnIncrease";
            btnIncrease.Size = new Size(25, 25);
            btnIncrease.TabIndex = 1;
            btnIncrease.Text = "+";
            btnIncrease.UseVisualStyleBackColor = true;
            btnIncrease.Click += btnIncrease_Click;
            // 
            // btnDecrease
            // 
            btnDecrease.Location = new Point(187, 19);
            btnDecrease.Name = "btnDecrease";
            btnDecrease.Size = new Size(25, 25);
            btnDecrease.TabIndex = 2;
            btnDecrease.Text = "-";
            btnDecrease.UseVisualStyleBackColor = true;
            btnDecrease.Click += btnDecrease_Click;
            // 
            // lblAmount
            // 
            lblAmount.Location = new Point(214, 10);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(40, 47);
            lblAmount.TabIndex = 3;
            lblAmount.Text = "0";
            lblAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnComment
            // 
            btnComment.Location = new Point(302, 10);
            btnComment.Name = "btnComment";
            btnComment.Size = new Size(158, 45);
            btnComment.TabIndex = 4;
            btnComment.Text = "Add Comment";
            btnComment.UseVisualStyleBackColor = true;
            btnComment.Click += btnComment_Click;
            // 
            // OrderItemUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnComment);
            Controls.Add(lblAmount);
            Controls.Add(btnDecrease);
            Controls.Add(btnIncrease);
            Controls.Add(lblDishName);
            Name = "OrderItemUserControl";
            Size = new Size(465, 65);
            ResumeLayout(false);
        }

        #endregion

        private Label lblDishName;
        private Button btnIncrease;
        private Button btnDecrease;
        private Label lblAmount;
        private Button btnComment;
    }
}
