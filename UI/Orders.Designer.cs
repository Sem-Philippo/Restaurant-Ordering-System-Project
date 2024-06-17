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
            SuspendLayout();
            // 
            // flowPanelDrinks
            // 
            flowPanelDrinks.AutoScroll = true;
            flowPanelDrinks.Location = new Point(12, 12);
            flowPanelDrinks.Name = "flowPanelDrinks";
            flowPanelDrinks.Size = new Size(650, 500);
            flowPanelDrinks.TabIndex = 0;
            // 
            // flowPanelLunch
            // 
            flowPanelLunch.AutoScroll = true;
            flowPanelLunch.Location = new Point(12, 12);
            flowPanelLunch.Name = "flowPanelLunch";
            flowPanelLunch.Size = new Size(650, 500);
            flowPanelLunch.TabIndex = 2;
            // 
            // flowPanelDinner
            // 
            flowPanelDinner.AutoScroll = true;
            flowPanelDinner.Location = new Point(12, 12);
            flowPanelDinner.Name = "flowPanelDinner";
            flowPanelDinner.Size = new Size(650, 500);
            flowPanelDinner.TabIndex = 3;
            // 
            // btnShowLunch
            // 
            btnShowLunch.Location = new Point(144, 60);
            btnShowLunch.Name = "btnShowLunch";
            btnShowLunch.Size = new Size(250, 100);
            btnShowLunch.TabIndex = 4;
            btnShowLunch.Text = "Lunch";
            btnShowLunch.UseVisualStyleBackColor = true;
            btnShowLunch.Click += btnShowLunch_Click;
            // 
            // btnShowDinner
            // 
            btnShowDinner.Location = new Point(144, 190);
            btnShowDinner.Name = "btnShowDinner";
            btnShowDinner.Size = new Size(250, 100);
            btnShowDinner.TabIndex = 5;
            btnShowDinner.Text = "Dinner";
            btnShowDinner.UseVisualStyleBackColor = true;
            btnShowDinner.Click += btnShowDinner_Click;
            // 
            // btnShowDrinks
            // 
            btnShowDrinks.Location = new Point(144, 315);
            btnShowDrinks.Name = "btnShowDrinks";
            btnShowDrinks.Size = new Size(250, 100);
            btnShowDrinks.TabIndex = 6;
            btnShowDrinks.Text = "Drinks";
            btnShowDrinks.UseVisualStyleBackColor = true;
            btnShowDrinks.Click += btnShowDrinks_Click;
            // 
            // btnBackToOrders
            // 
            btnBackToOrders.Location = new Point(12, 524);
            btnBackToOrders.Name = "btnBackToOrders";
            btnBackToOrders.Size = new Size(150, 50);
            btnBackToOrders.TabIndex = 7;
            btnBackToOrders.Text = "Back to orders";
            btnBackToOrders.UseVisualStyleBackColor = true;
            btnBackToOrders.Click += btnBackToOrders_Click;
            // 
            // btnOrder
            // 
            btnOrder.Location = new Point(512, 524);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(150, 50);
            btnOrder.TabIndex = 8;
            btnOrder.Text = "Order";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // Orders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 604);
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
    }
}