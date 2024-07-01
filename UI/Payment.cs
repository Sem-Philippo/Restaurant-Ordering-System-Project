using DAL;
using Model;
using Model.Enums;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Payment : Form
    {
        private TableService tableService;
        private OrderService orderService;
        private InvoiceService invoiceService;
        private decimal totalAmount;
        private int invoiceId;
        public Payment()
        {
            InitializeComponent();
            tableService = new TableService();
            orderService = new OrderService();
            invoiceService = new InvoiceService();
            DisableButtons();
            EvenSplitNumeric.Minimum = 1;
            DateTimeLbl.Text = DateTime.Now.ToString();

            LoadTableComboBox();
            LoadPaymentTypeComboBox();
        }
        private void DisableButtons()
        {
            EvenSplitNumeric.Enabled = false;
            TipsTextBox.Enabled = false;
            TipBtn.Enabled = false;
            PayBtn.Enabled = false;
            BeginsPaymentBtn.Enabled = false;
            PaymentAmountTextBox.Enabled = false;
            EvenSplitCheckBox.Enabled = false;
            PaymentTypeCombo.Enabled = false;
        }
        public void LoadTableComboBox()
        {
            try
            {
                List<int> tableNumbers = tableService.GetAllTableNUmbers();
                TablesCombo.Items.Clear();
                foreach (int tableNumber in tableNumbers)
                {
                    TablesCombo.Items.Add(tableNumber);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading table numbers:" + e.Message);
            }
        }
        public void LoadPaymentTypeComboBox()
        {
            try
            {
                PaymentTypeCombo.Items.Clear();
                PaymentTypeCombo.DataSource = Enum.GetValues(typeof(PaymentTypes));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading payment types" + ex.Message);
            }
        }
        private void PaymentTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaymentTypeCombo.SelectedIndex != 0)
            {
                PayBtn.Enabled = true;
            }
            else
            {
                PayBtn.Enabled = false;
            }
        }
        private void EvenSplitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (EvenSplitCheckBox.Checked)
            {
                EvenSplitNumeric.Enabled = true;
                PaymentAmountTextBox.Enabled = false;
                PaymentNrLbl.Text = EvenSplitNumeric.Value.ToString();
                invoiceService.InitializeEvenSplit((int)EvenSplitNumeric.Value);
            }
            else
            {
                EvenSplitNumeric.Enabled = false;
                PaymentAmountTextBox.Enabled = true;
                PaymentNrLbl.Text = 1.ToString();
            }
        }
        private void EvenSplitNumeric_ValueChanged(object sender, EventArgs e)
        {
            PaymentNrLbl.Text = EvenSplitNumeric.Value.ToString();
            invoiceService.InitializeEvenSplit((int)EvenSplitNumeric.Value);
        }
        private void TablesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TablesCombo.SelectedItem != null)
            {
                int selectedTableNumber = (int)TablesCombo.SelectedItem;
                PaymentListView(selectedTableNumber);
                BeginsPaymentBtn.Enabled = true;

                try
                {
                    string employeeName;
                    int orderID;
                    decimal orderTotal = orderService.GetOrderDetailsByTableNumber(selectedTableNumber, out decimal lowVat, out decimal highVat, out employeeName, out orderID);
                    TotalAmountLbl.Text = orderService.FormatToStringWithEuro(orderTotal);
                    LowVatLbl.Text = orderService.FormatToStringWithEuro(lowVat);
                    HighVatLbl.Text = orderService.FormatToStringWithEuro(highVat);
                    EmployeeNameLbl.Text = employeeName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while trying to retrieve order details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void PaymentListView(int tableNumber)
        {
            OrderItemsList.Items.Clear();
            try
            {
                Order order = orderService.GetServedItemsByTableNumber(tableNumber, out _, out _);
                foreach (OrderItem item in order.OrderItems)
                {
                    string vatPercentage = orderService.DisplayVatAsPercantage(item.MenuItem.Tax);
                    ListViewItem listViewItem = new ListViewItem(item.MenuItem.Name);
                    listViewItem.SubItems.Add(vatPercentage);
                    listViewItem.SubItems.Add(item.Comment);
                    listViewItem.SubItems.Add(item.MenuItem.Price.ToString("0.00"));
                    listViewItem.SubItems.Add(item.Quantity.ToString());
                    listViewItem.SubItems.Add((item.MenuItem.Price * item.Quantity).ToString("0.00"));
                    OrderItemsList.Items.Add(listViewItem);
                }
                OrderItemsList.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when trying to retrieve order: {ex.Message}");
            }
        }
        private void TipBtn_Click(object sender, EventArgs e)
        {
            string input = TipsTextBox.Text.Trim();
            if (decimal.TryParse(input, out decimal tipAmount) && tipAmount >= 0)
            {
                TipAmountLbl.Text = orderService.FormatToStringWithEuro(tipAmount);
            }
            else
            {
                MessageBox.Show("Please enter a non-negative number only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TipsTextBox.Focus();
                TipsTextBox.SelectAll();
            }
        }
        private void PayBtn_Click(object sender, EventArgs e)
        {
            try
            {
                decimal totalAmount = orderService.ParseAndRemoveEuro(TotalAmountLbl.Text);
                (bool isSuccess, string message, decimal amountDue) result;
                if (EvenSplitCheckBox.Checked)
                {
                    result = invoiceService.ProcessEvenSplitPayment(totalAmount, invoiceId, new Payments());
                }
                else
                {
                    string input = PaymentAmountTextBox.Text.Trim();
                    decimal singlePayment = orderService.ParseAndRemoveEuro(input);
                    result = invoiceService.ProcessSinglePayment(singlePayment, invoiceId, totalAmount, new Payments());
                }
                MessageBox.Show(result.message, result.isSuccess ? "Payment Successful" : "Invalid Payment", MessageBoxButtons.OK, result.isSuccess ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                AmountDueLbl.Text = result.amountDue.ToString("0.00") + " €";

                if (EvenSplitCheckBox.Checked)
                {
                    PaymentNrLbl.Text = invoiceService.RemainingPayments.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to preform payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DisableButtons();
        }
        private void PaymentTypeCombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (PaymentTypeCombo.SelectedIndex != 0)
            {
                PayBtn.Enabled = true;
            }
            else
            {
                PayBtn.Enabled = false;
            }

        }
        private void BeginsPaymentBtn_Click(object sender, EventArgs e)
        {
            TipsTextBox.Enabled = true;
            TipBtn.Enabled = true;
            PaymentAmountTextBox.Enabled = true;
            PaymentTypeCombo.Enabled = true;
            EvenSplitCheckBox.Enabled = true;
            PaymentTypeCombo.Enabled = true;

            try
            {
                if (TablesCombo.SelectedItem == null)
                {
                    MessageBox.Show("Please select a table number.");
                    return;
                }
                int tableNumber = Convert.ToInt32(TablesCombo.SelectedItem);
                Order order = orderService.GetOrderByTableNumber(tableNumber);
                int orderid = order.Id;
                DateTime orderDateTime = DateTime.Now;
                decimal lowVat = orderService.ParseAndRemoveEuro(LowVatLbl.Text);
                decimal highVat = orderService.ParseAndRemoveEuro(HighVatLbl.Text);
                decimal totalAmount = orderService.ParseAndRemoveEuro(TotalAmountLbl.Text);

                string employeeName = EmployeeNameLbl.Text;
                Invoice invoice = new Invoice(orderDateTime, order, lowVat, highVat, totalAmount, false, employeeName);
                invoiceService.AddInvoice(invoice, orderid);
                MessageBox.Show("Invoice created successfully and saved to database.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating and saving invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BeginsPaymentBtn_Click_1(object sender, EventArgs e)
        {
            TipsTextBox.Enabled = true;
            TipBtn.Enabled = true;
            PaymentAmountTextBox.Enabled = true;
            PaymentTypeCombo.Enabled = true;
            EvenSplitCheckBox.Enabled = true;
            PaymentTypeCombo.Enabled = true;
            MessageBox.Show("Hello");

            try
            {
                if (TablesCombo.SelectedItem == null)
                {
                    MessageBox.Show("Please select a table number.");
                    return;
                }
                int tableNumber = Convert.ToInt32(TablesCombo.SelectedItem);
                Order order = orderService.GetOrderByTableNumber(tableNumber);
                int orderid = order.Id;
                DateTime orderDateTime = DateTime.Now;
                decimal lowVat = orderService.ParseAndRemoveEuro(LowVatLbl.Text);
                decimal highVat = orderService.ParseAndRemoveEuro(HighVatLbl.Text);
                decimal totalAmount = orderService.ParseAndRemoveEuro(TotalAmountLbl.Text);

                string employeeName = EmployeeNameLbl.Text;
                Invoice invoice = new Invoice(orderDateTime, order, lowVat, highVat, totalAmount, false, employeeName);
                invoiceService.AddInvoice(invoice, orderid);
                MessageBox.Show("Invoice created successfully and saved to database.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating and saving invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}