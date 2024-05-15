using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
        public decimal PaymentAmount { get; set; }
        public int InvoiceId { get; set; }
        public decimal Tip { get; set; }
        public Payment(int paymentId, string paymentType, decimal paymentAmount, int invoiceId, decimal tip)
        {
            PaymentId = paymentId;
            PaymentType = paymentType;
            PaymentAmount = paymentAmount;
            InvoiceId = invoiceId;
            Tip = tip;
        }
    }
    
}
