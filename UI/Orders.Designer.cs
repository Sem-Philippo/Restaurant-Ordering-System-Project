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
            btnBackToOrders = new Button();
            btnOrder = new Button();
            listviewItems = new ListView();
            name = new ColumnHeader();
            Amount = new ColumnHeader();
            btnComment = new Button();
            pnlComment = new Panel();
            txtComment = new TextBox();
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
            // btnBackToOrders
            // 
            btnBackToOrders.Location = new Point(12, 567);
            btnBackToOrders.Name = "btnBackToOrders";
            btnBackToOrders.Size = new Size(150, 50);
            btnBackToOrders.TabIndex = 7;
            btnBackToOrders.Text = "Back to orders";
            btnBackToOrders.UseVisualStyleBackColor = true;
            btnBackToOrders.Click += btnBackToOrders_Click;
            // 
            // btnOrder
            // 
            btnOrder.Location = new Point(333, 567);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(150, 50);
            btnOrder.TabIndex = 8;
            btnOrder.Text = "Order";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // listviewItems
            // 
            listviewItems.Columns.AddRange(new ColumnHeader[] { name, Amount });
            listviewItems.FullRowSelect = true;
            listviewItems.Location = new Point(100, 375);
            listviewItems.MultiSelect = false;
            listviewItems.Name = "listviewItems";
            listviewItems.Size = new Size(300, 186);
            listviewItems.TabIndex = 9;
            listviewItems.UseCompatibleStateImageBehavior = false;
            listviewItems.View = View.Details;
            listviewItems.SelectedIndexChanged += listviewItems_SelectedIndexChanged;
            // 
            // name
            // 
            name.Text = "Name";
            name.Width = 200;
            // 
            // Amount
            // 
            Amount.Text = "Amount";
            Amount.Width = 100;
            // 
            // btnComment
            // 
            btnComment.Location = new Point(12, 567);
            btnComment.Name = "btnComment";
            btnComment.Size = new Size(150, 50);
            btnComment.TabIndex = 10;
            btnComment.Text = "Comment";
            btnComment.UseVisualStyleBackColor = true;
            btnComment.Click += btnComment_Click;
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
            // Orders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 629);
            Controls.Add(pnlComment);
            Controls.Add(btnComment);
            Controls.Add(listviewItems);
            Controls.Add(btnOrder);
            Controls.Add(btnBackToOrders);
            Controls.Add(btnShowDrinks);
            Controls.Add(btnShowDinner);
            Controls.Add(btnShowLunch);
            Controls.Add(flowPanelLunch);
            Controls.Add(flowPanelDrinks);
            Controls.Add(flowPanelDinner);
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
        private Button btnBackToOrders;
        private Button btnOrder;
        private ListView listviewItems;
        private ColumnHeader name;
        private ColumnHeader Amount;
        private Button btnComment;
        private Panel pnlComment;
        private TextBox txtComment;
    }
}