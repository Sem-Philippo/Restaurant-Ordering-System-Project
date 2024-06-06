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
        public DateTime OrderDate { get; set; }
        List<Payment> Payments { get; set; }
        public Order Order { get; set; }
        public decimal LowVat { get; set; }
        public decimal HighVat { get; set; }



        public Invoice (DateTime orderDate, Order order, decimal lowVat, decimal highVat)
        {
            Payments = new List<Payment>();
            OrderDate = orderDate;
            Order = order;
            LowVat = lowVat;
            HighVat = highVat;
        }
        public void AddPayment(Payment payments)
        {
            Payments.Add(payments);
        }
    }
}
