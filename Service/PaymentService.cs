using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace Service
{
    public class PaymentService
    {
        OrderService orderService;
        InvoiceService invoiceService;

        private PaymentDAO paymentDAO { get; set; }
        private decimal totalPayments = 0;
        private int remainingPayments = 0;
        public decimal TotalPayments => totalPayments;
        public int RemainingPayments => remainingPayments;

        public PaymentService()
        {
            paymentDAO = new PaymentDAO();
            orderService = new OrderService();
            invoiceService = new InvoiceService();
        }
        public List<Payments> GetAllPayments()
        {
            try
            {
                return paymentDAO.GetAllPayments();
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
                return paymentDAO.GetPaymentByID(paymentId);
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
                paymentDAO.AddPayment(payment);
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
                paymentDAO.UpdatePayment(payment);
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

        public (bool isSuccess, string message, decimal amountDue) ProcessSinglePayment(decimal singlePayment, decimal totalAmount)
        {
            decimal temp = totalPayments;
            totalPayments += singlePayment;

            if (singlePayment <= totalAmount && totalPayments <= totalAmount)
            { 
                decimal amountDue = totalAmount - totalPayments;
                if (totalAmount == totalPayments)
                {
                    return (true, $"Payment is complete. You have paid a total of {orderService.FormatToStringWithEuro(totalPayments)}", amountDue);
                }
                return (true, $"Payment of {orderService.FormatToStringWithEuro(singlePayment)} is successful. Total paid: {orderService.FormatToStringWithEuro(totalPayments)}", amountDue);
            }
            else if (singlePayment > totalAmount || totalPayments > totalAmount)
            {
                totalPayments = temp; 
                return (false, $"Payment of {orderService.FormatToStringWithEuro(singlePayment)} is too high. You have paid a total of {orderService.FormatToStringWithEuro(totalPayments)} so far.", totalAmount - totalPayments);
            }

            return (false, "Unexpected error occurred during payment processing.", totalAmount - totalPayments);
        }

        public (bool isComplete, string message, decimal amountDue) ProcessEvenSplitPayment(decimal totalAmount)
        {
            decimal singlePayment = totalAmount / remainingPayments;
            remainingPayments--;
            totalPayments += singlePayment;

            if (remainingPayments <= 0)
            {
                totalPayments = totalAmount; 
                return (true, $"Payment is complete. You have paid a total of {orderService.FormatToStringWithEuro(totalPayments)}", 0);
            }

            return (false, $"Payment of {orderService.FormatToStringWithEuro(singlePayment)} is successful. Total paid: {orderService.FormatToStringWithEuro(totalPayments)}", totalAmount - totalPayments);
        }
    }
}
