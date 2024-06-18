namespace UI
{
    partial class AddMenuItem
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
            label1 = new Label();
            iDTextbox = new TextBox();
            addItemButton = new Button();
            priceTextBox = new TextBox();
            label4 = new Label();
            nameTextBox = new TextBox();
            label5 = new Label();
            categoryComboBox = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            taxTextBox = new TextBox();
            label6 = new Label();
            label7 = new Label();
            typeComboBox = new ComboBox();
            label8 = new Label();
            alchoholicComboBox = new ComboBox();
            stockTextBox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 80);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "Item name";
            // 
            // iDTextbox
            // 
            iDTextbox.Location = new Point(202, 39);
            iDTextbox.Margin = new Padding(3, 2, 3, 2);
            iDTextbox.Name = "iDTextbox";
            iDTextbox.Size = new Size(166, 23);
            iDTextbox.TabIndex = 1;
            // 
            // addItemButton
            // 
            addItemButton.Location = new Point(93, 368);
            addItemButton.Margin = new Padding(3, 2, 3, 2);
            addItemButton.Name = "addItemButton";
            addItemButton.Size = new Size(178, 34);
            addItemButton.TabIndex = 3;
            addItemButton.Text = "Add";
            addItemButton.UseVisualStyleBackColor = true;
            addItemButton.Click += addItemButton_Click;
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(202, 149);
            priceTextBox.Margin = new Padding(3, 2, 3, 2);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(166, 23);
            priceTextBox.TabIndex = 9;
         
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 154);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 8;
            label4.Text = "Price";
           
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(202, 75);
            nameTextBox.Margin = new Padding(3, 2, 3, 2);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(166, 23);
            nameTextBox.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 44);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 10;
            label5.Text = "ID";
            // 
            // categoryComboBox
            // 
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Location = new Point(202, 259);
            categoryComboBox.Margin = new Padding(3, 2, 3, 2);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new Size(166, 23);
            categoryComboBox.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 265);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 14;
            label2.Text = "Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 224);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 15;
            label3.Text = "Stock";
            // 
            // taxTextBox
            // 
            taxTextBox.Location = new Point(202, 184);
            taxTextBox.Margin = new Padding(3, 2, 3, 2);
            taxTextBox.Name = "taxTextBox";
            taxTextBox.Size = new Size(166, 23);
            taxTextBox.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 190);
            label6.Name = "label6";
            label6.Size = new Size(24, 15);
            label6.TabIndex = 16;
            label6.Text = "Tax";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 117);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 19;
            label7.Text = "Type";
            // 
            // typeComboBox
            // 
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(202, 115);
            typeComboBox.Margin = new Padding(3, 2, 3, 2);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(166, 23);
            typeComboBox.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 296);
            label8.Name = "label8";
            label8.Size = new Size(75, 15);
            label8.TabIndex = 21;
            label8.Text = "Is Alchoholic";
            // 
            // alchoholicComboBox
            // 
            alchoholicComboBox.FormattingEnabled = true;
            alchoholicComboBox.Location = new Point(202, 294);
            alchoholicComboBox.Margin = new Padding(3, 2, 3, 2);
            alchoholicComboBox.Name = "alchoholicComboBox";
            alchoholicComboBox.Size = new Size(166, 23);
            alchoholicComboBox.TabIndex = 20;
            // 
            // stockTextBox
            // 
            stockTextBox.Location = new Point(202, 221);
            stockTextBox.Margin = new Padding(3, 2, 3, 2);
            stockTextBox.Name = "stockTextBox";
            stockTextBox.Size = new Size(166, 23);
            stockTextBox.TabIndex = 22;
            // 
            // AddMenuItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 410);
            Controls.Add(stockTextBox);
            Controls.Add(label8);
            Controls.Add(alchoholicComboBox);
            Controls.Add(label7);
            Controls.Add(typeComboBox);
            Controls.Add(taxTextBox);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(categoryComboBox);
            Controls.Add(nameTextBox);
            Controls.Add(label5);
            Controls.Add(priceTextBox);
            Controls.Add(label4);
            Controls.Add(addItemButton);
            Controls.Add(iDTextbox);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddMenuItem";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox iDTextbox;
        private Button addItemButton;
        private TextBox priceTextBox;
        private Label label4;
        private TextBox nameTextBox;
        private Label label5;
        private ComboBox categoryComboBox;
        private Label label2;
        private Label label3;
        private TextBox taxTextBox;
        private Label label6;
        private Label label7;
        private ComboBox typeComboBox;
        private Label label8;
        private ComboBox alchoholicComboBox;
        private TextBox stockTextBox;
    }
}