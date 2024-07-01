namespace UI
{
    partial class Orders
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
            flowPanelDrinks = new FlowLayoutPanel();
            flowPanelLunch = new FlowLayoutPanel();
            flowPanelDinner = new FlowLayoutPanel();
            btnShowLunch = new Button();
            btnShowDinner = new Button();
            btnShowDrinks = new Button();
            btnBackToOverview = new Button();
            btnNewOrder = new Button();
            pnlComment = new Panel();
            txtComment = new TextBox();
            btnAddOrder = new Button();
            flOrder = new FlowLayoutPanel();
            pnlComment.SuspendLayout();
            SuspendLayout();
            // 
            // flowPanelDrinks
            // 
            flowPanelDrinks.AutoScroll = true;
            flowPanelDrinks.Location = new Point(12, 12);
            flowPanelDrinks.Name = "flowPanelDrinks";
            flowPanelDrinks.Size = new Size(470, 549);
            flowPanelDrinks.TabIndex = 0;
            // 
            // flowPanelLunch
            // 
            flowPanelLunch.AutoScroll = true;
            flowPanelLunch.Location = new Point(12, 12);
            flowPanelLunch.Name = "flowPanelLunch";
            flowPanelLunch.Size = new Size(470, 549);
            flowPanelLunch.TabIndex = 2;
            // 
            // flowPanelDinner
            // 
            flowPanelDinner.AutoScroll = true;
            flowPanelDinner.Location = new Point(12, 12);
            flowPanelDinner.Name = "flowPanelDinner";
            flowPanelDinner.Size = new Size(470, 549);
            flowPanelDinner.TabIndex = 3;
            // 
            // btnShowLunch
            // 
            btnShowLunch.Location = new Point(123, 14);
            btnShowLunch.Name = "btnShowLunch";
            btnShowLunch.Size = new Size(250, 100);
            btnShowLunch.TabIndex = 4;
            btnShowLunch.Text = "Lunch";
            btnShowLunch.UseVisualStyleBackColor = true;
            btnShowLunch.Click += btnShowLunch_Click;
            // 
            // btnShowDinner
            // 
            btnShowDinner.Location = new Point(123, 144);
            btnShowDinner.Name = "btnShowDinner";
            btnShowDinner.Size = new Size(250, 100);
            btnShowDinner.TabIndex = 5;
            btnShowDinner.Text = "Dinner";
            btnShowDinner.UseVisualStyleBackColor = true;
            btnShowDinner.Click += btnShowDinner_Click;
            // 
            // btnShowDrinks
            // 
            btnShowDrinks.Location = new Point(123, 269);
            btnShowDrinks.Name = "btnShowDrinks";
            btnShowDrinks.Size = new Size(250, 100);
            btnShowDrinks.TabIndex = 6;
            btnShowDrinks.Text = "Drinks";
            btnShowDrinks.UseVisualStyleBackColor = true;
            btnShowDrinks.Click += btnShowDrinks_Click;
            // 
            // btnBackToOverview
            // 
            btnBackToOverview.Location = new Point(12, 567);
            btnBackToOverview.Name = "btnBackToOverview";
            btnBackToOverview.Size = new Size(150, 50);
            btnBackToOverview.TabIndex = 7;
            btnBackToOverview.Text = "Back to overview";
            btnBackToOverview.UseVisualStyleBackColor = true;
            btnBackToOverview.Click += btnBackToOverview_Click;
            // 
            // btnNewOrder
            // 
            btnNewOrder.Location = new Point(332, 567);
            btnNewOrder.Name = "btnNewOrder";
            btnNewOrder.Size = new Size(150, 50);
            btnNewOrder.TabIndex = 8;
            btnNewOrder.Text = "New Order";
            btnNewOrder.UseVisualStyleBackColor = true;
            btnNewOrder.Click += btnNewOrder_Click;
            // 
            // pnlComment
            // 
            pnlComment.Controls.Add(txtComment);
            pnlComment.Location = new Point(12, 12);
            pnlComment.Name = "pnlComment";
            pnlComment.Size = new Size(470, 549);
            pnlComment.TabIndex = 11;
            // 
            // txtComment
            // 
            txtComment.Location = new Point(27, 71);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(419, 270);
            txtComment.TabIndex = 0;
            // 
            // btnAddOrder
            // 
            btnAddOrder.Location = new Point(172, 567);
            btnAddOrder.Name = "btnAddOrder";
            btnAddOrder.Size = new Size(150, 50);
            btnAddOrder.TabIndex = 12;
            btnAddOrder.Text = "Add to previous Order";
            btnAddOrder.UseVisualStyleBackColor = true;
            btnAddOrder.Click += btnAddOrder_Click;
            // 
            // flOrder
            // 
            flOrder.AutoScroll = true;
            flOrder.Location = new Point(0, 376);
            flOrder.Name = "flOrder";
            flOrder.Size = new Size(494, 185);
            flOrder.TabIndex = 13;
            // 
            // Orders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(494, 629);
            Controls.Add(flOrder);
            Controls.Add(btnAddOrder);
            Controls.Add(btnNewOrder);
            Controls.Add(btnBackToOverview);
            Controls.Add(btnShowDrinks);
            Controls.Add(btnShowDinner);
            Controls.Add(btnShowLunch);
            Controls.Add(flowPanelDinner);
            Controls.Add(pnlComment);
            Controls.Add(flowPanelLunch);
            Controls.Add(flowPanelDrinks);
            Name = "Orders";
            Text = "Orders";
            Load += Orders_Load;
            pnlComment.ResumeLayout(false);
            pnlComment.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowPanelDrinks;
        private FlowLayoutPanel flowPanelLunch;
        private FlowLayoutPanel flowPanelDinner;
        private Button btnShowLunch;
        private Button btnShowDinner;
        private Button btnShowDrinks;
        private Button btnBackToOverview;
        private Button btnNewOrder;
        private Panel pnlComment;
        private TextBox txtComment;
        private Button btnAddOrder;
        private ColumnHeader name;
        private ColumnHeader Amount;
        private ListView listviewItems;
        private FlowLayoutPanel flOrder;
    }
}