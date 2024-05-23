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
<<<<<<< HEAD
        public DateOnly OrderDate { get; set; }
        public List <Order> Orders { get; set; }
        public decimal LowVat { get; set; }
        public decimal HighVat { get; set; }

        public Invoice (DateOnly orderDate, List<Order> orders, decimal lowVat, decimal highVat)
=======
        public DateTime OrderDate { get; set; }
        List<Payment> Payments { get; set; }
        public Order Order { get; set; }
        public decimal LowVat { get; set; }
        public decimal HighVat { get; set; }

        public Invoice (DateTime orderDate, Order orders, decimal lowVat, decimal highVat)
>>>>>>> 7ace30da9a252806f863b88f659e1b0c33b845a4
        {
            Payments = new List<Payment>();
            OrderDate = orderDate;
            Orders = orders;
            LowVat = lowVat;
            HighVat = highVat;
        }
        public void AddPayment(Payment payments)
        {
            Payments.Add(payments);
        }
    }
}
