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
<<<<<<< HEAD
            OrderItemsList = new ListView();
=======

            SuspendLayout();
            // 
            // Payment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "Payment";
            Text = "Payment";
            Load += Payment_Load;
            ResumeLayout(false);

            listView1 = new ListView();
>>>>>>> 3116a052fb3deac49d79f7dbf944f18bbef924d6
            ItemName = new ColumnHeader();
            VatValue = new ColumnHeader();
            ItemDescription = new ColumnHeader();
            ItemPrice = new ColumnHeader();
            ItemQuantity = new ColumnHeader();
            ItemTotal = new ColumnHeader();
            PaymentNrLbl = new Label();
            EvenSplitNumeric = new NumericUpDown();
            TipBtn = new Button();
            NumberOfPaymentsTxt = new Label();
            BillOptions = new GroupBox();
            label1 = new Label();
            EvenSplitCheckBox = new CheckBox();
            PaymentAmountTextBox = new TextBox();
            TipsTextBox = new TextBox();
            PaymentTypeCombo = new ComboBox();
            PaymentTypeLbl = new Label();
            PayBtn = new Button();
            TablesCombo = new ComboBox();
            OverviewBtn = new Button();
            MenuBtn = new Button();
            OrdersBtn = new Button();
            ManagementBtn = new Button();
            HistoryBtn = new Button();
            TabelsLbl = new Label();
            PaymentDetails = new GroupBox();
            LowVatLbl = new Label();
            LowVatText = new Label();
            HighVatLbl = new Label();
            HighVatText = new Label();
            TipAmountLbl = new Label();
            AmountDueLbl = new Label();
            TotalAmountLbl = new Label();
            AmountDueTxt = new Label();
            label3 = new Label();
            TotalTxt = new Label();
            FeedbackGroup = new GroupBox();
            FeedbackBox = new TextBox();
            DateTimeLbl = new Label();
            DateTxt = new Label();
            PaymentGroup = new GroupBox();
            EmployeeText = new Label();
            EmployeeNameLbl = new Label();
            BeginsPaymentBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)EvenSplitNumeric).BeginInit();
            BillOptions.SuspendLayout();
            PaymentDetails.SuspendLayout();
            FeedbackGroup.SuspendLayout();
            PaymentGroup.SuspendLayout();
            SuspendLayout();
            // 
            // OrderItemsList
            // 
            OrderItemsList.Columns.AddRange(new ColumnHeader[] { ItemName, VatValue, ItemDescription, ItemPrice, ItemQuantity, ItemTotal });
            OrderItemsList.Location = new Point(18, 87);
            OrderItemsList.Name = "OrderItemsList";
            OrderItemsList.Size = new Size(467, 253);
            OrderItemsList.TabIndex = 0;
            OrderItemsList.UseCompatibleStateImageBehavior = false;
            OrderItemsList.View = View.Details;
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
            // PaymentNrLbl
            // 
            PaymentNrLbl.AutoSize = true;
            PaymentNrLbl.Location = new Point(415, 61);
            PaymentNrLbl.Name = "PaymentNrLbl";
            PaymentNrLbl.Size = new Size(25, 15);
            PaymentNrLbl.TabIndex = 2;
            PaymentNrLbl.Text = "......";
            // 
            // EvenSplitNumeric
            // 
            EvenSplitNumeric.Location = new Point(377, 28);
            EvenSplitNumeric.Name = "EvenSplitNumeric";
            EvenSplitNumeric.Size = new Size(65, 23);
            EvenSplitNumeric.TabIndex = 3;
            EvenSplitNumeric.ValueChanged += EvenSplitNumeric_ValueChanged;
            // 
            // TipBtn
            // 
            TipBtn.Location = new Point(6, 27);
            TipBtn.Name = "TipBtn";
            TipBtn.Size = new Size(75, 23);
            TipBtn.TabIndex = 5;
            TipBtn.Text = "Tips";
            TipBtn.UseVisualStyleBackColor = true;
            TipBtn.Click += TipBtn_Click;
            // 
            // NumberOfPaymentsTxt
            // 
            NumberOfPaymentsTxt.AutoSize = true;
            NumberOfPaymentsTxt.Location = new Point(283, 61);
            NumberOfPaymentsTxt.Name = "NumberOfPaymentsTxt";
            NumberOfPaymentsTxt.Size = new Size(126, 15);
            NumberOfPaymentsTxt.TabIndex = 6;
            NumberOfPaymentsTxt.Text = "Number of payments: ";
            // 
            // BillOptions
            // 
            BillOptions.Controls.Add(label1);
            BillOptions.Controls.Add(EvenSplitCheckBox);
            BillOptions.Controls.Add(PaymentAmountTextBox);
            BillOptions.Controls.Add(TipsTextBox);
            BillOptions.Controls.Add(NumberOfPaymentsTxt);
            BillOptions.Controls.Add(EvenSplitNumeric);
            BillOptions.Controls.Add(PaymentNrLbl);
            BillOptions.Controls.Add(TipBtn);
            BillOptions.Location = new Point(12, 352);
            BillOptions.Name = "BillOptions";
            BillOptions.Size = new Size(473, 86);
            BillOptions.TabIndex = 7;
            BillOptions.TabStop = false;
            BillOptions.Text = "Bill options";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 61);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 20;
            label1.Text = "Enter amount:";
            // 
            // EvenSplitCheckBox
            // 
            EvenSplitCheckBox.AutoSize = true;
            EvenSplitCheckBox.Location = new Point(283, 29);
            EvenSplitCheckBox.Name = "EvenSplitCheckBox";
            EvenSplitCheckBox.Size = new Size(80, 19);
            EvenSplitCheckBox.TabIndex = 19;
            EvenSplitCheckBox.Text = "Even Split:";
            EvenSplitCheckBox.UseVisualStyleBackColor = true;
            EvenSplitCheckBox.CheckedChanged += EvenSplitCheckBox_CheckedChanged;
            // 
            // PaymentAmountTextBox
            // 
            PaymentAmountTextBox.Location = new Point(96, 57);
            PaymentAmountTextBox.Name = "PaymentAmountTextBox";
            PaymentAmountTextBox.Size = new Size(100, 23);
            PaymentAmountTextBox.TabIndex = 18;
            // 
            // TipsTextBox
            // 
            TipsTextBox.Location = new Point(96, 27);
            TipsTextBox.Name = "TipsTextBox";
            TipsTextBox.Size = new Size(100, 23);
            TipsTextBox.TabIndex = 17;
            // 
            // PaymentTypeCombo
            // 
            PaymentTypeCombo.FormattingEnabled = true;
            PaymentTypeCombo.Location = new Point(122, 24);
            PaymentTypeCombo.Name = "PaymentTypeCombo";
            PaymentTypeCombo.Size = new Size(121, 23);
            PaymentTypeCombo.TabIndex = 16;
            PaymentTypeCombo.SelectedIndexChanged += PaymentTypeCombo_SelectedIndexChanged_1;
            // 
            // PaymentTypeLbl
            // 
            PaymentTypeLbl.AutoSize = true;
            PaymentTypeLbl.Location = new Point(33, 27);
            PaymentTypeLbl.Name = "PaymentTypeLbl";
            PaymentTypeLbl.Size = new Size(83, 15);
            PaymentTypeLbl.TabIndex = 15;
            PaymentTypeLbl.Text = "Payment type:";
            // 
            // PayBtn
            // 
            PayBtn.Location = new Point(36, 54);
            PayBtn.Name = "PayBtn";
            PayBtn.Size = new Size(210, 23);
            PayBtn.TabIndex = 13;
            PayBtn.Text = "Pay";
            PayBtn.UseVisualStyleBackColor = true;
            PayBtn.Click += PayBtn_Click;
            // 
            // TablesCombo
            // 
            TablesCombo.FormattingEnabled = true;
            TablesCombo.Location = new Point(58, 58);
            TablesCombo.Name = "TablesCombo";
            TablesCombo.Size = new Size(71, 23);
            TablesCombo.TabIndex = 8;
            TablesCombo.SelectedIndexChanged += TablesCombo_SelectedIndexChanged;
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
            PaymentDetails.Controls.Add(LowVatLbl);
            PaymentDetails.Controls.Add(LowVatText);
            PaymentDetails.Controls.Add(HighVatLbl);
            PaymentDetails.Controls.Add(HighVatText);
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
            // LowVatLbl
            // 
            LowVatLbl.AutoSize = true;
            LowVatLbl.Location = new Point(235, 44);
            LowVatLbl.Name = "LowVatLbl";
            LowVatLbl.Size = new Size(46, 15);
            LowVatLbl.TabIndex = 23;
            LowVatLbl.Text = ".............";
            // 
            // LowVatText
            // 
            LowVatText.AutoSize = true;
            LowVatText.Location = new Point(171, 44);
            LowVatText.Name = "LowVatText";
            LowVatText.Size = new Size(54, 15);
            LowVatText.TabIndex = 22;
            LowVatText.Text = "Low VAT:";
            // 
            // HighVatLbl
            // 
            HighVatLbl.AutoSize = true;
            HighVatLbl.Location = new Point(235, 19);
            HighVatLbl.Name = "HighVatLbl";
            HighVatLbl.Size = new Size(46, 15);
            HighVatLbl.TabIndex = 15;
            HighVatLbl.Text = ".............";
            // 
            // HighVatText
            // 
            HighVatText.AutoSize = true;
            HighVatText.Location = new Point(171, 19);
            HighVatText.Name = "HighVatText";
            HighVatText.Size = new Size(58, 15);
            HighVatText.TabIndex = 15;
            HighVatText.Text = "High VAT:";
            // 
            // TipAmountLbl
            // 
            TipAmountLbl.AutoSize = true;
            TipAmountLbl.Location = new Point(110, 44);
            TipAmountLbl.Name = "TipAmountLbl";
            TipAmountLbl.Size = new Size(46, 15);
            TipAmountLbl.TabIndex = 21;
            TipAmountLbl.Text = ".............";
            // 
            // AmountDueLbl
            // 
            AmountDueLbl.AutoSize = true;
            AmountDueLbl.Location = new Point(110, 19);
            AmountDueLbl.Name = "AmountDueLbl";
            AmountDueLbl.Size = new Size(46, 15);
            AmountDueLbl.TabIndex = 20;
            AmountDueLbl.Text = ".............";
            // 
            // TotalAmountLbl
            // 
            TotalAmountLbl.AutoSize = true;
            TotalAmountLbl.Location = new Point(180, 77);
            TotalAmountLbl.Name = "TotalAmountLbl";
            TotalAmountLbl.Size = new Size(46, 15);
            TotalAmountLbl.TabIndex = 19;
            TotalAmountLbl.Text = ".............";
            // 
            // AmountDueTxt
            // 
            AmountDueTxt.AutoSize = true;
            AmountDueTxt.Location = new Point(6, 19);
            AmountDueTxt.Name = "AmountDueTxt";
            AmountDueTxt.Size = new Size(77, 15);
            AmountDueTxt.TabIndex = 18;
            AmountDueTxt.Text = "Amount due:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 44);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 17;
            label3.Text = "Tip amount:";
            // 
            // TotalTxt
            // 
            TotalTxt.AutoSize = true;
            TotalTxt.Location = new Point(76, 77);
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
            // DateTimeLbl
            // 
            DateTimeLbl.AutoSize = true;
            DateTimeLbl.Location = new Point(557, 16);
            DateTimeLbl.Name = "DateTimeLbl";
            DateTimeLbl.Size = new Size(61, 15);
            DateTimeLbl.TabIndex = 20;
            DateTimeLbl.Text = "..................";
            // 
            // DateTxt
            // 
            DateTxt.AutoSize = true;
            DateTxt.Location = new Point(472, 15);
            DateTxt.Name = "DateTxt";
            DateTxt.Size = new Size(86, 15);
            DateTxt.TabIndex = 21;
            DateTxt.Text = "Date and Time:";
            // 
            // PaymentGroup
            // 
            PaymentGroup.Controls.Add(PayBtn);
            PaymentGroup.Controls.Add(PaymentTypeLbl);
            PaymentGroup.Controls.Add(PaymentTypeCombo);
            PaymentGroup.Location = new Point(491, 352);
            PaymentGroup.Name = "PaymentGroup";
            PaymentGroup.Size = new Size(297, 86);
            PaymentGroup.TabIndex = 20;
            PaymentGroup.TabStop = false;
            PaymentGroup.Text = "Payment options";
            // 
            // EmployeeText
            // 
            EmployeeText.AutoSize = true;
            EmployeeText.Location = new Point(160, 61);
            EmployeeText.Name = "EmployeeText";
            EmployeeText.Size = new Size(95, 15);
            EmployeeText.TabIndex = 17;
            EmployeeText.Text = "Employee name:";
            // 
            // EmployeeNameLbl
            // 
            EmployeeNameLbl.AutoSize = true;
            EmployeeNameLbl.Location = new Point(261, 61);
            EmployeeNameLbl.Name = "EmployeeNameLbl";
            EmployeeNameLbl.Size = new Size(46, 15);
            EmployeeNameLbl.TabIndex = 22;
            EmployeeNameLbl.Text = ".............";
            // 
            // BeginsPaymentBtn
            // 
            BeginsPaymentBtn.Location = new Point(341, 57);
            BeginsPaymentBtn.Name = "BeginsPaymentBtn";
            BeginsPaymentBtn.Size = new Size(144, 23);
            BeginsPaymentBtn.TabIndex = 21;
            BeginsPaymentBtn.Text = "Start payment process";
            BeginsPaymentBtn.UseVisualStyleBackColor = true;
            BeginsPaymentBtn.Click += BeginsPaymentBtn_Click;
            // 
            // Payment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BeginsPaymentBtn);
            Controls.Add(EmployeeNameLbl);
            Controls.Add(EmployeeText);
            Controls.Add(PaymentGroup);
            Controls.Add(DateTxt);
            Controls.Add(DateTimeLbl);
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
            Controls.Add(OrderItemsList);
            Name = "Payment";
            Text = "Payment";
            ((System.ComponentModel.ISupportInitialize)EvenSplitNumeric).EndInit();
            BillOptions.ResumeLayout(false);
            BillOptions.PerformLayout();
            PaymentDetails.ResumeLayout(false);
            PaymentDetails.PerformLayout();
            FeedbackGroup.ResumeLayout(false);
            FeedbackGroup.PerformLayout();
            PaymentGroup.ResumeLayout(false);
            PaymentGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private ListView OrderItemsList;
        private ColumnHeader ItemName;
        private ColumnHeader ItemDescription;
        private ColumnHeader ItemPrice;
        private ColumnHeader ItemQuantity;
        private ColumnHeader ItemTotal;
        private Button SplitBtn;
        private Label PaymentNrLbl;
        private NumericUpDown EvenSplitNumeric;
        private Button TipBtn;
        private Label NumberOfPaymentsTxt;
        private GroupBox BillOptions;
        private ComboBox TablesCombo;
        private Button OverviewBtn;
        private Button MenuBtn;
        private Button OrdersBtn;
        private Button ManagementBtn;
        private Label TabelsLbl;
        private Button HistoryBtn;
        private Label EvenSplitLbl;
        private Label PaymentTypeLbl;
        private Button PayBtn;
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
        private Label HighVatText;
        private Label HighVatLbl;
        private Label LowVatLbl;
        private Label LowVatText;
        private TextBox TipsTextBox;
        private TextBox PaymentAmountTextBox;
        private CheckBox EvenSplitCheckBox;
        private Label DateTimeLbl;
        private Label DateTxt;
        private GroupBox PaymentGroup;
        private Label EmployeeText;
        private Label EmployeeNameLbl;
        private Label label1;
        private Button BeginsPaymentBtn;
    }
}