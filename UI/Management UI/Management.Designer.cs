namespace UI
{
    partial class Management
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
            menuStrip1 = new MenuStrip();
            stocksToolStripMenuItem = new ToolStripMenuItem();
            employeesToolStripMenuItem = new ToolStripMenuItem();
            overviewToolStripMenuItem = new ToolStripMenuItem();
            stocksPanel = new Panel();
            updateButton = new Button();
            stockAmountButton = new Button();
            updateMenuItem = new Button();
            stocksList = new ListView();
            ID = new ColumnHeader();
            name = new ColumnHeader();
            category = new ColumnHeader();
            stoc = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader16 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            dinnerButton = new Button();
            drinkButton = new Button();
            deleteButton = new Button();
            lunchDinner = new Button();
            label1 = new Label();
            overviewPanel = new Panel();
            lowStockList = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            columnHeader15 = new ColumnHeader();
            label2 = new Label();
            groupBox1 = new GroupBox();
            tipsLabel = new Label();
            revenuelabel = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            employeesPanel = new Panel();
            addEmployeeBtn = new Button();
            removeEmployeeBtn = new Button();
            updateEmployeeBtn = new Button();
            employeesList = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            label6 = new Label();
            menuStrip1.SuspendLayout();
            stocksPanel.SuspendLayout();
            overviewPanel.SuspendLayout();
            groupBox1.SuspendLayout();
            employeesPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { stocksToolStripMenuItem, employeesToolStripMenuItem, overviewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(664, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // stocksToolStripMenuItem
            // 
            stocksToolStripMenuItem.Name = "stocksToolStripMenuItem";
            stocksToolStripMenuItem.Size = new Size(53, 20);
            stocksToolStripMenuItem.Text = "Stocks";
            stocksToolStripMenuItem.Click += stocksToolStripMenuItem_Click;
            // 
            // employeesToolStripMenuItem
            // 
            employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            employeesToolStripMenuItem.Size = new Size(76, 20);
            employeesToolStripMenuItem.Text = "Employees";
            employeesToolStripMenuItem.Click += employeesToolStripMenuItem_Click;
            // 
            // overviewToolStripMenuItem
            // 
            overviewToolStripMenuItem.Name = "overviewToolStripMenuItem";
            overviewToolStripMenuItem.Size = new Size(68, 20);
            overviewToolStripMenuItem.Text = "Overview";
            overviewToolStripMenuItem.Click += overviewToolStripMenuItem_Click;
            // 
            // stocksPanel
            // 
            stocksPanel.Controls.Add(updateButton);
            stocksPanel.Controls.Add(stockAmountButton);
            stocksPanel.Controls.Add(updateMenuItem);
            stocksPanel.Controls.Add(stocksList);
            stocksPanel.Controls.Add(dinnerButton);
            stocksPanel.Controls.Add(drinkButton);
            stocksPanel.Controls.Add(deleteButton);
            stocksPanel.Controls.Add(lunchDinner);
            stocksPanel.Controls.Add(label1);
            stocksPanel.Location = new Point(10, 23);
            stocksPanel.Margin = new Padding(3, 2, 3, 2);
            stocksPanel.Name = "stocksPanel";
            stocksPanel.Size = new Size(644, 424);
            stocksPanel.TabIndex = 7;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(474, 346);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(75, 23);
            updateButton.TabIndex = 13;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // stockAmountButton
            // 
            stockAmountButton.Location = new Point(182, 346);
            stockAmountButton.Name = "stockAmountButton";
            stockAmountButton.Size = new Size(94, 23);
            stockAmountButton.TabIndex = 14;
            stockAmountButton.Text = "Adjust Stock";
            stockAmountButton.UseVisualStyleBackColor = true;
            stockAmountButton.Click += stockAmountButton_Click;
            // 
            // updateMenuItem
            // 
            updateMenuItem.Location = new Point(330, 346);
            updateMenuItem.Margin = new Padding(3, 2, 3, 2);
            updateMenuItem.Name = "updateMenuItem";
            updateMenuItem.Size = new Size(82, 22);
            updateMenuItem.TabIndex = 11;
            updateMenuItem.Text = "Add Item";
            updateMenuItem.UseVisualStyleBackColor = true;
            updateMenuItem.Click += updateMenuItem_Click;
            // 
            // stocksList
            // 
            stocksList.Columns.AddRange(new ColumnHeader[] { ID, name, category, stoc, columnHeader9, columnHeader10, columnHeader16, columnHeader11 });
            stocksList.Location = new Point(5, 56);
            stocksList.Margin = new Padding(3, 2, 3, 2);
            stocksList.Name = "stocksList";
            stocksList.Size = new Size(639, 253);
            stocksList.TabIndex = 10;
            stocksList.UseCompatibleStateImageBehavior = false;
            stocksList.View = View.Details;
            // 
            // ID
            // 
            ID.Text = "ID";
            // 
            // name
            // 
            name.Text = "Name";
            name.Width = 200;
            // 
            // category
            // 
            category.Text = "Category";
            category.Width = 150;
            // 
            // stoc
            // 
            stoc.Text = "Stock";
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Price";
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Tax";
            // 
            // columnHeader16
            // 
            columnHeader16.DisplayIndex = 7;
            columnHeader16.Text = "Type";
            // 
            // columnHeader11
            // 
            columnHeader11.DisplayIndex = 6;
            columnHeader11.Text = "Alchoholic";
            columnHeader11.Width = 80;
            // 
            // dinnerButton
            // 
            dinnerButton.Location = new Point(490, 15);
            dinnerButton.Margin = new Padding(3, 2, 3, 2);
            dinnerButton.Name = "dinnerButton";
            dinnerButton.Size = new Size(82, 22);
            dinnerButton.TabIndex = 9;
            dinnerButton.Text = "Dinner";
            dinnerButton.UseVisualStyleBackColor = true;
            dinnerButton.Click += dinnerButton_Click_1;
            // 
            // drinkButton
            // 
            drinkButton.Location = new Point(382, 16);
            drinkButton.Margin = new Padding(3, 2, 3, 2);
            drinkButton.Name = "drinkButton";
            drinkButton.Size = new Size(82, 22);
            drinkButton.TabIndex = 8;
            drinkButton.Text = "Drinks";
            drinkButton.UseVisualStyleBackColor = true;
            drinkButton.Click += drinkButton_Click_1;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(66, 346);
            deleteButton.Margin = new Padding(3, 2, 3, 2);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(82, 22);
            deleteButton.TabIndex = 12;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // lunchDinner
            // 
            lunchDinner.Location = new Point(273, 16);
            lunchDinner.Margin = new Padding(3, 2, 3, 2);
            lunchDinner.Name = "lunchDinner";
            lunchDinner.Size = new Size(82, 22);
            lunchDinner.TabIndex = 7;
            lunchDinner.Text = "Lunch";
            lunchDinner.UseVisualStyleBackColor = true;
            lunchDinner.Click += lunchDinner_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(99, 37);
            label1.TabIndex = 6;
            label1.Text = "Stocks";
            label1.UseWaitCursor = true;
            // 
            // overviewPanel
            // 
            overviewPanel.Controls.Add(lowStockList);
            overviewPanel.Controls.Add(label2);
            overviewPanel.Controls.Add(groupBox1);
            overviewPanel.Controls.Add(label3);
            overviewPanel.Location = new Point(9, 26);
            overviewPanel.Margin = new Padding(3, 2, 3, 2);
            overviewPanel.Name = "overviewPanel";
            overviewPanel.Size = new Size(645, 424);
            overviewPanel.TabIndex = 15;
            // 
            // lowStockList
            // 
            lowStockList.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader12, columnHeader13, columnHeader14, columnHeader15 });
            lowStockList.Location = new Point(4, 68);
            lowStockList.Margin = new Padding(3, 2, 3, 2);
            lowStockList.Name = "lowStockList";
            lowStockList.Size = new Size(638, 148);
            lowStockList.TabIndex = 26;
            lowStockList.UseCompatibleStateImageBehavior = false;
            lowStockList.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Name";
            columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Category";
            columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "stock";
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Price";
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "Tax";
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "Type";
            columnHeader14.Width = 100;
            // 
            // columnHeader15
            // 
            columnHeader15.Text = "Alchoholic";
            columnHeader15.Width = 100;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(3, 1);
            label2.Name = "label2";
            label2.Size = new Size(139, 37);
            label2.TabIndex = 25;
            label2.Text = "Overview";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tipsLabel);
            groupBox1.Controls.Add(revenuelabel);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(6, 236);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(265, 148);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "Income Overview";
            // 
            // tipsLabel
            // 
            tipsLabel.AutoSize = true;
            tipsLabel.Location = new Point(185, 100);
            tipsLabel.Name = "tipsLabel";
            tipsLabel.Size = new Size(38, 15);
            tipsLabel.TabIndex = 4;
            tipsLabel.Text = "label7";
            // 
            // revenuelabel
            // 
            revenuelabel.AutoSize = true;
            revenuelabel.Location = new Point(185, 46);
            revenuelabel.Name = "revenuelabel";
            revenuelabel.Size = new Size(38, 15);
            revenuelabel.TabIndex = 3;
            revenuelabel.Text = "label7";
            
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 100);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 1;
            label5.Text = "Tips:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 46);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 0;
            label4.Text = "Total Revenue:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 37);
            label3.Name = "label3";
            label3.Size = new Size(107, 19);
            label3.TabIndex = 23;
            label3.Text = "Low stock items";
            // 
            // employeesPanel
            // 
            employeesPanel.Controls.Add(addEmployeeBtn);
            employeesPanel.Controls.Add(removeEmployeeBtn);
            employeesPanel.Controls.Add(updateEmployeeBtn);
            employeesPanel.Controls.Add(employeesList);
            employeesPanel.Controls.Add(label6);
            employeesPanel.Location = new Point(9, 23);
            employeesPanel.Margin = new Padding(3, 2, 3, 2);
            employeesPanel.Name = "employeesPanel";
            employeesPanel.Size = new Size(645, 424);
            employeesPanel.TabIndex = 22;
            // 
            // addEmployeeBtn
            // 
            addEmployeeBtn.Location = new Point(85, 363);
            addEmployeeBtn.Margin = new Padding(3, 2, 3, 2);
            addEmployeeBtn.Name = "addEmployeeBtn";
            addEmployeeBtn.Size = new Size(104, 22);
            addEmployeeBtn.TabIndex = 26;
            addEmployeeBtn.Text = "Add Employee";
            addEmployeeBtn.UseVisualStyleBackColor = true;
            addEmployeeBtn.Click += addEmployeeBtn_Click;
            // 
            // removeEmployeeBtn
            // 
            removeEmployeeBtn.Location = new Point(195, 363);
            removeEmployeeBtn.Margin = new Padding(3, 2, 3, 2);
            removeEmployeeBtn.Name = "removeEmployeeBtn";
            removeEmployeeBtn.Size = new Size(130, 22);
            removeEmployeeBtn.TabIndex = 25;
            removeEmployeeBtn.Text = "Remove Employee";
            removeEmployeeBtn.UseVisualStyleBackColor = true;
            removeEmployeeBtn.Click += removeEmployeeBtn_Click;
            // 
            // updateEmployeeBtn
            // 
            updateEmployeeBtn.Location = new Point(374, 363);
            updateEmployeeBtn.Margin = new Padding(3, 2, 3, 2);
            updateEmployeeBtn.Name = "updateEmployeeBtn";
            updateEmployeeBtn.Size = new Size(82, 22);
            updateEmployeeBtn.TabIndex = 24;
            updateEmployeeBtn.Text = "Update Employee";
            updateEmployeeBtn.UseVisualStyleBackColor = true;
            updateEmployeeBtn.Click += updateEmployeeBtn_Click;
            // 
            // employeesList
            // 
            employeesList.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6, columnHeader7, columnHeader8 });
            employeesList.Location = new Point(2, 85);
            employeesList.Margin = new Padding(3, 2, 3, 2);
            employeesList.Name = "employeesList";
            employeesList.Size = new Size(639, 253);
            employeesList.TabIndex = 23;
            employeesList.UseCompatibleStateImageBehavior = false;
            employeesList.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "ID";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "First name";
            columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "last name";
            columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Role";
            columnHeader8.Width = 120;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(1, 2);
            label6.Name = "label6";
            label6.Size = new Size(155, 37);
            label6.TabIndex = 22;
            label6.Text = "Employees";
            // 
            // Management
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 476);
            Controls.Add(overviewPanel);
            Controls.Add(stocksPanel);
            Controls.Add(menuStrip1);
            Controls.Add(employeesPanel);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Management";
            Text = "Stock";
            Load += Stock_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            stocksPanel.ResumeLayout(false);
            stocksPanel.PerformLayout();
            overviewPanel.ResumeLayout(false);
            overviewPanel.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            employeesPanel.ResumeLayout(false);
            employeesPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem stocksToolStripMenuItem;
        private ToolStripMenuItem employeesToolStripMenuItem;
        private Panel stocksPanel;
        private ListView stocksList;
        private ColumnHeader ID;
        private ColumnHeader name;
        private ColumnHeader category;
        private ColumnHeader stoc;
        private Button dinnerButton;
        private Button drinkButton;
        private Button lunchDinner;
        private Button updateMenuItem;
        private Button deleteButton;
        private Button updateButton;
        private Button stockAmountButton;
        private ToolStripMenuItem overviewToolStripMenuItem;
        private Label label1;
        private Panel employeesPanel;
        private ListView employeesList;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private Label label6;
        private Button addEmployeeBtn;
        private Button removeEmployeeBtn;
        private Button updateEmployeeBtn;
        private Panel overviewPanel;
        private Label label2;
        private GroupBox groupBox1;
        private Label tipsLabel;
        private Label revenuelabel;
        private Label label5;
        private Label label4;
        private Label label3;
        private ListView lowStockList;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
    }
}