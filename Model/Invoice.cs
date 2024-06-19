using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime OrderDateTime { get; set; }
        List<Payments> Payments { get; set; }
        public Order Order { get; set; }
        public decimal VatValue { get; set; }
        public decimal LowVat { get; set; }
        public decimal HighVat { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public string EmployeeName { get; set; }

        public Invoice(DateTime orderDateTime, Order order, decimal lowVat, decimal highVat, decimal totalAmount, bool isPaid, string employeeName)
        {
            Payments = new List<Payments>();
            OrderDateTime = orderDateTime;
            Order = order;
            LowVat = lowVat;
            HighVat = highVat;
            TotalAmount = totalAmount;
            IsPaid = isPaid;
            EmployeeName = employeeName;
        }
        public Invoice() { }
        public void AddPayment(Payments payment)
        {
            Payments.Add(payment);

            // Calculate total paid amount
            decimal totalPaid = Payments.Sum(p => p.PaymentAmount);

            // Check if the invoice is fully paid
            if (totalPaid >= Order.Total)
            {
                IsPaid = true;
            }
        }
    }
}
