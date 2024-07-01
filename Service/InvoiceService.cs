using System;
using System.Collections.Generic;
using DAL;
using Model;

namespace Service
{
    public class InvoiceService
    {
        private InvoiceDAO invoiceDAO;
        private OrderService orderService;
        private TableService tableService;
        private decimal totalPayments = 0;
        private int remainingPayments = 0;
        public decimal TotalPayments => totalPayments;
        public int RemainingPayments => remainingPayments;
        public InvoiceService()
        {
            invoiceDAO = new InvoiceDAO();
            orderService = new OrderService();
            tableService = new TableService();
        }
        public List<Invoice> GetAllInvoices()
        {
            try
            {
                return invoiceDAO.GetAllInvoices();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving invoices: " + ex.Message);
            }
        }

        public Invoice GetInvoiceByID(int id)
        {
            try
            {
                return invoiceDAO.GetInvoiceByID(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving invoice with ID {id}: " + ex.Message);
            }
        }

        public void AddInvoice(Invoice invoice, int orderid)
        {
            try
            {
                invoiceDAO.AddInvoice(invoice, orderid);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding invoice: " + ex.Message);
            }
        }

        public void UpdateInvoiceStatus(int invoiceId)
        {
            try
            {
                Invoice invoice = invoiceDAO.GetInvoiceByID(invoiceId);
                invoiceDAO.UpdateInvoiceStatus(invoice);
                totalPayments = 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating invoice: " + ex.Message);
            }
        }

        public decimal GetTotalIncome()
        {
            try
            {
                return invoiceDAO.GetTotalIncome();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving total income: " + ex.Message);
            }
        }
        public List<Payments> GetAllPayments()
        {
            try
            {
                return invoiceDAO.GetAllPayments();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving payments: " + ex.Message);
            }
        }

        public Payments GetPaymentByID(int paymentId)
        {
            try
            {
                return invoiceDAO.GetPaymentByID(paymentId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving payment with ID {paymentId}: " + ex.Message);
            }
        }

        public void AddPayment(Payments payment)
        {
            try
            {
                ValidatePaymentForAdd(payment);
                invoiceDAO.AddPayment(payment);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding payment: " + ex.Message);
            }
        }

        public void UpdatePayment(Payments payment)
        {
            try
            {
                ValidatePaymentForUpdate(payment);
                invoiceDAO.UpdatePayment(payment);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating payment: " + ex.Message);
            }
        }

        private void ValidatePaymentForAdd(Payments payment)
        {
            if (payment.PaymentAmount <= 0)
            {
                throw new Exception("Payment amount must be greater than zero.");
            }
        }

        private void ValidatePaymentForUpdate(Payments payment)
        {
            if (payment.PaymentId <= 0)
            {
                throw new Exception("Invalid Payment ID for update.");
            }
        }

        public void InitializeEvenSplit(int numberOfPayments)
        {
            remainingPayments = numberOfPayments;
        }
        public (bool isSucess, string message, decimal amountDue) ProcessSinglePayment(decimal singlePayment, int invoiceId, decimal totalAmount, Payments payment, int tableNumber, decimal tip)
        {
            decimal temp = totalPayments;
            totalPayments += singlePayment;

            if (singlePayment <= totalAmount && totalPayments <= totalAmount)
            {
                decimal amountDue = totalAmount - totalPayments;
                payment.PaymentAmount = singlePayment;
                payment.PaymentDateTime = DateTime.Now;
                payment.BillInvoice = invoiceDAO.GetInvoiceByID(invoiceId);
                payment.BillInvoice.InvoiceId = invoiceId;
                payment.Tip = tip;
                invoiceDAO.AddPayment(payment);

                if (totalAmount == totalPayments)
                {
                    UpdateInvoiceStatus(invoiceId);
                    tableService.UpdateTable(new Table() { TableNumber = tableNumber });
                    return (true, $"Payment is complete. You have paid a total of {orderService.FormatToStringWithEuro(totalPayments)}", amountDue);
                }
                return (false, $"Payment of {orderService.FormatToStringWithEuro(singlePayment)} is successful. Total paid: {orderService.FormatToStringWithEuro(totalPayments)}", amountDue);
            }
            else if (singlePayment > totalAmount || totalPayments > totalAmount)
            {
                totalPayments = temp;
                return (false, $"Payment of {orderService.FormatToStringWithEuro(singlePayment)} is too high. You have paid a total of {orderService.FormatToStringWithEuro(totalPayments)} so far.", totalAmount - totalPayments);
            }

            return (false, "Unexpected error occurred during payment processing.", totalAmount - totalPayments);
        }

        public (bool isComplete, string message, decimal amountDue) ProcessEvenSplitPayment(decimal totalAmount, int invoiceId, Payments payment, int tableNumber, decimal tip)
        {
            decimal singlePayment = totalAmount / remainingPayments;
            remainingPayments--;
            totalPayments += singlePayment;
            payment.PaymentAmount = singlePayment;
            payment.PaymentDateTime = DateTime.Now;
            tableService.UpdateTable(new Table() { TableNumber = tableNumber });
            payment.BillInvoice = invoiceDAO.GetInvoiceByID(invoiceId);
            payment.BillInvoice.InvoiceId = invoiceId;
            payment.Tip = tip;
            invoiceDAO.AddPayment(payment);
            if (remainingPayments <= 0)
            {
                totalPayments = totalAmount;
                UpdateInvoiceStatus(invoiceId);
                return (true, $"Payment is complete. You have paid a total of {orderService.FormatToStringWithEuro(totalPayments)}", 0);
            }

            return (false, $"Payment of {orderService.FormatToStringWithEuro(singlePayment)} is successful. Total paid: {orderService.FormatToStringWithEuro(totalPayments)}", totalAmount - totalPayments);
        }

        public decimal GetTipsAmount()
        {
            try
            {
                return invoiceDAO.GetAllTipAmount();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving tips amount: " + ex.Message);
            }
        }
    }
}