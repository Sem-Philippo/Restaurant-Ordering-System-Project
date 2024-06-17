namespace UI
{
    partial class Payment
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
            listView1 = new ListView();
            ItemName = new ColumnHeader();
            VatValue = new ColumnHeader();
            ItemDescription = new ColumnHeader();
            ItemPrice = new ColumnHeader();
            ItemQuantity = new ColumnHeader();
            ItemTotal = new ColumnHeader();
            SplitBtn = new Button();
            PaymentNrLbl = new Label();
            EvenSplitNumeric = new NumericUpDown();
            ManualSplitBox = new TextBox();
            TipBtn = new Button();
            label1 = new Label();
            BillOptions = new GroupBox();
            PaymentTypeCombo = new ComboBox();
            PaymentTypeLbl = new Label();
            payBtn = new Button();
            EvenSplitLbl = new Label();
            label2 = new Label();
            TablesCombo = new ComboBox();
            OverviewBtn = new Button();
            MenuBtn = new Button();
            OrdersBtn = new Button();
            ManagementBtn = new Button();
            HistoryBtn = new Button();
            TabelsLbl = new Label();
            PaymentDetails = new GroupBox();
            TipAmountLbl = new Label();
            AmountDueLbl = new Label();
            TotalAmountLbl = new Label();
            AmountDueTxt = new Label();
            label3 = new Label();
            TotalTxt = new Label();
            FeedbackGroup = new GroupBox();
            FeedbackBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)EvenSplitNumeric).BeginInit();
            BillOptions.SuspendLayout();
            PaymentDetails.SuspendLayout();
            FeedbackGroup.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { ItemName, VatValue, ItemDescription, ItemPrice, ItemQuantity, ItemTotal });
            listView1.Location = new Point(18, 87);
            listView1.Name = "listView1";
            listView1.Size = new Size(467, 253);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // ItemName
            // 
            ItemName.Text = "Item name";
            ItemName.Width = 100;
            // 
            // VatValue
            // 
            VatValue.Text = "VAT";
            // 
            // ItemDescription
            // 
            ItemDescription.Text = "Description";
            ItemDescription.Width = 100;
            // 
            // ItemPrice
            // 
            ItemPrice.Text = "item price";
            ItemPrice.Width = 70;
            // 
            // ItemQuantity
            // 
            ItemQuantity.Text = "Quantity";
            ItemQuantity.Width = 65;
            // 
            // ItemTotal
            // 
            ItemTotal.Text = "Total price";
            ItemTotal.Width = 70;
            // 
            // SplitBtn
            // 
            SplitBtn.Location = new Point(129, 57);
            SplitBtn.Name = "SplitBtn";
            SplitBtn.Size = new Size(75, 23);
            SplitBtn.TabIndex = 1;
            SplitBtn.Text = "Split";
            SplitBtn.UseVisualStyleBackColor = true;
            // 
            // PaymentNrLbl
            // 
            PaymentNrLbl.AutoSize = true;
            PaymentNrLbl.Location = new Point(367, 61);
            PaymentNrLbl.Name = "PaymentNrLbl";
            PaymentNrLbl.Size = new Size(25, 15);
            PaymentNrLbl.TabIndex = 2;
            PaymentNrLbl.Text = "......";
            // 
            // EvenSplitNumeric
            // 
            EvenSplitNumeric.Location = new Point(304, 28);
            EvenSplitNumeric.Name = "EvenSplitNumeric";
            EvenSplitNumeric.Size = new Size(65, 23);
            EvenSplitNumeric.TabIndex = 3;
            // 
            // ManualSplitBox
            // 
            ManualSplitBox.Location = new Point(98, 28);
            ManualSplitBox.Name = "ManualSplitBox";
            ManualSplitBox.Size = new Size(106, 23);
            ManualSplitBox.TabIndex = 4;
            // 
            // TipBtn
            // 
            TipBtn.Location = new Point(10, 57);
            TipBtn.Name = "TipBtn";
            TipBtn.Size = new Size(75, 23);
            TipBtn.TabIndex = 5;
            TipBtn.Text = "Tips";
            TipBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(235, 61);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 6;
            label1.Text = "Number of payments: ";
            // 
            // BillOptions
            // 
            BillOptions.Controls.Add(PaymentTypeCombo);
            BillOptions.Controls.Add(PaymentTypeLbl);
            BillOptions.Controls.Add(payBtn);
            BillOptions.Controls.Add(EvenSplitLbl);
            BillOptions.Controls.Add(label1);
            BillOptions.Controls.Add(label2);
            BillOptions.Controls.Add(EvenSplitNumeric);
            BillOptions.Controls.Add(PaymentNrLbl);
            BillOptions.Controls.Add(TipBtn);
            BillOptions.Controls.Add(ManualSplitBox);
            BillOptions.Controls.Add(SplitBtn);
            BillOptions.Location = new Point(12, 352);
            BillOptions.Name = "BillOptions";
            BillOptions.Size = new Size(776, 86);
            BillOptions.TabIndex = 7;
            BillOptions.TabStop = false;
            BillOptions.Text = "Bill options";
            // 
            // PaymentTypeCombo
            // 
            PaymentTypeCombo.FormattingEnabled = true;
            PaymentTypeCombo.Location = new Point(555, 42);
            PaymentTypeCombo.Name = "PaymentTypeCombo";
            PaymentTypeCombo.Size = new Size(121, 23);
            PaymentTypeCombo.TabIndex = 16;
            // 
            // PaymentTypeLbl
            // 
            PaymentTypeLbl.AutoSize = true;
            PaymentTypeLbl.Location = new Point(466, 45);
            PaymentTypeLbl.Name = "PaymentTypeLbl";
            PaymentTypeLbl.Size = new Size(83, 15);
            PaymentTypeLbl.TabIndex = 15;
            PaymentTypeLbl.Text = "Payment type:";
            // 
            // payBtn
            // 
            payBtn.Location = new Point(695, 28);
            payBtn.Name = "payBtn";
            payBtn.Size = new Size(75, 48);
            payBtn.TabIndex = 13;
            payBtn.Text = "Pay";
            payBtn.UseVisualStyleBackColor = true;
            // 
            // EvenSplitLbl
            // 
            EvenSplitLbl.AutoSize = true;
            EvenSplitLbl.Location = new Point(235, 31);
            EvenSplitLbl.Name = "EvenSplitLbl";
            EvenSplitLbl.Size = new Size(63, 15);
            EvenSplitLbl.TabIndex = 14;
            EvenSplitLbl.Text = "Even split: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 31);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 10;
            label2.Text = "Enter amount:";
            // 
            // TablesCombo
            // 
            TablesCombo.FormattingEnabled = true;
            TablesCombo.Location = new Point(58, 58);
            TablesCombo.Name = "TablesCombo";
            TablesCombo.Size = new Size(71, 23);
            TablesCombo.TabIndex = 8;
            // 
            // OverviewBtn
            // 
            OverviewBtn.Location = new Point(18, 12);
            OverviewBtn.Name = "OverviewBtn";
            OverviewBtn.Size = new Size(75, 23);
            OverviewBtn.TabIndex = 9;
            OverviewBtn.Text = "Overview";
            OverviewBtn.UseVisualStyleBackColor = true;
            // 
            // MenuBtn
            // 
            MenuBtn.Location = new Point(99, 12);
            MenuBtn.Name = "MenuBtn";
            MenuBtn.Size = new Size(75, 23);
            MenuBtn.TabIndex = 10;
            MenuBtn.Text = "Menu";
            MenuBtn.UseVisualStyleBackColor = true;
            // 
            // OrdersBtn
            // 
            OrdersBtn.Location = new Point(180, 12);
            OrdersBtn.Name = "OrdersBtn";
            OrdersBtn.Size = new Size(75, 23);
            OrdersBtn.TabIndex = 11;
            OrdersBtn.Text = "Orders";
            OrdersBtn.UseVisualStyleBackColor = true;
            // 
            // ManagementBtn
            // 
            ManagementBtn.Location = new Point(261, 12);
            ManagementBtn.Name = "ManagementBtn";
            ManagementBtn.Size = new Size(90, 23);
            ManagementBtn.TabIndex = 12;
            ManagementBtn.Text = "Management";
            ManagementBtn.UseVisualStyleBackColor = true;
            // 
            // HistoryBtn
            // 
            HistoryBtn.Location = new Point(685, 12);
            HistoryBtn.Name = "HistoryBtn";
            HistoryBtn.Size = new Size(103, 23);
            HistoryBtn.TabIndex = 13;
            HistoryBtn.Text = "Payment history";
            HistoryBtn.UseVisualStyleBackColor = true;
            // 
            // TabelsLbl
            // 
            TabelsLbl.AutoSize = true;
            TabelsLbl.Location = new Point(18, 61);
            TabelsLbl.Name = "TabelsLbl";
            TabelsLbl.Size = new Size(34, 15);
            TabelsLbl.TabIndex = 9;
            TabelsLbl.Text = "Table";
            // 
            // PaymentDetails
            // 
            PaymentDetails.Controls.Add(TipAmountLbl);
            PaymentDetails.Controls.Add(AmountDueLbl);
            PaymentDetails.Controls.Add(TotalAmountLbl);
            PaymentDetails.Controls.Add(AmountDueTxt);
            PaymentDetails.Controls.Add(label3);
            PaymentDetails.Controls.Add(TotalTxt);
            PaymentDetails.Location = new Point(491, 245);
            PaymentDetails.Name = "PaymentDetails";
            PaymentDetails.Size = new Size(297, 95);
            PaymentDetails.TabIndex = 14;
            PaymentDetails.TabStop = false;
            PaymentDetails.Text = "Payment details";
            // 
            // TipAmountLbl
            // 
            TipAmountLbl.AutoSize = true;
            TipAmountLbl.Location = new Point(228, 72);
            TipAmountLbl.Name = "TipAmountLbl";
            TipAmountLbl.Size = new Size(46, 15);
            TipAmountLbl.TabIndex = 21;
            TipAmountLbl.Text = ".............";
            // 
            // AmountDueLbl
            // 
            AmountDueLbl.AutoSize = true;
            AmountDueLbl.Location = new Point(228, 48);
            AmountDueLbl.Name = "AmountDueLbl";
            AmountDueLbl.Size = new Size(46, 15);
            AmountDueLbl.TabIndex = 20;
            AmountDueLbl.Text = ".............";
            // 
            // TotalAmountLbl
            // 
            TotalAmountLbl.AutoSize = true;
            TotalAmountLbl.Location = new Point(228, 24);
            TotalAmountLbl.Name = "TotalAmountLbl";
            TotalAmountLbl.Size = new Size(46, 15);
            TotalAmountLbl.TabIndex = 19;
            TotalAmountLbl.Text = ".............";
            // 
            // AmountDueTxt
            // 
            AmountDueTxt.AutoSize = true;
            AmountDueTxt.Location = new Point(124, 48);
            AmountDueTxt.Name = "AmountDueTxt";
            AmountDueTxt.Size = new Size(77, 15);
            AmountDueTxt.TabIndex = 18;
            AmountDueTxt.Text = "Amount due:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(124, 72);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 17;
            label3.Text = "Tip amount:";
            // 
            // TotalTxt
            // 
            TotalTxt.AutoSize = true;
            TotalTxt.Location = new Point(124, 24);
            TotalTxt.Name = "TotalTxt";
            TotalTxt.Size = new Size(80, 15);
            TotalTxt.TabIndex = 16;
            TotalTxt.Text = "Total amount:";
            // 
            // FeedbackGroup
            // 
            FeedbackGroup.Controls.Add(FeedbackBox);
            FeedbackGroup.Location = new Point(491, 87);
            FeedbackGroup.Name = "FeedbackGroup";
            FeedbackGroup.Size = new Size(297, 152);
            FeedbackGroup.TabIndex = 0;
            FeedbackGroup.TabStop = false;
            FeedbackGroup.Text = "Feedback";
            // 
            // FeedbackBox
            // 
            FeedbackBox.Location = new Point(6, 22);
            FeedbackBox.Multiline = true;
            FeedbackBox.Name = "FeedbackBox";
            FeedbackBox.Size = new Size(285, 124);
            FeedbackBox.TabIndex = 15;
            FeedbackBox.Text = "Type here...";
            // 
            // Payment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(FeedbackGroup);
            Controls.Add(PaymentDetails);
            Controls.Add(TabelsLbl);
            Controls.Add(HistoryBtn);
            Controls.Add(TablesCombo);
            Controls.Add(ManagementBtn);
            Controls.Add(OrdersBtn);
            Controls.Add(MenuBtn);
            Controls.Add(OverviewBtn);
            Controls.Add(BillOptions);
            Controls.Add(listView1);
            Name = "Payment";
            Text = "Payment";
            ((System.ComponentModel.ISupportInitialize)EvenSplitNumeric).EndInit();
            BillOptions.ResumeLayout(false);
            BillOptions.PerformLayout();
            PaymentDetails.ResumeLayout(false);
            PaymentDetails.PerformLayout();
            FeedbackGroup.ResumeLayout(false);
            FeedbackGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader ItemName;
        private ColumnHeader ItemDescription;
        private ColumnHeader ItemPrice;
        private ColumnHeader ItemQuantity;
        private ColumnHeader ItemTotal;
        private Button SplitBtn;
        private Label PaymentNrLbl;
        private NumericUpDown EvenSplitNumeric;
        private TextBox ManualSplitBox;
        private Button TipBtn;
        private Label label1;
        private GroupBox BillOptions;
        private ComboBox TablesCombo;
        private Button OverviewBtn;
        private Button MenuBtn;
        private Button OrdersBtn;
        private Button ManagementBtn;
        private Label label2;
        private Label TabelsLbl;
        private Button HistoryBtn;
        private Label EvenSplitLbl;
        private Label PaymentTypeLbl;
        private Button payBtn;
        private ComboBox PaymentTypeCombo;
        private ColumnHeader VatValue;
        private GroupBox PaymentDetails;
        private Label label3;
        private Label TotalTxt;
        private GroupBox FeedbackGroup;
        private TextBox FeedbackBox;
        private Label TipAmountLbl;
        private Label AmountDueLbl;
        private Label TotalAmountLbl;
        private Label AmountDueTxt;
    }
}