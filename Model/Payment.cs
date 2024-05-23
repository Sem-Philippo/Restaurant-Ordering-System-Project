using Model.Enums;
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
        public PaymentTypes PaymentType { get; set; }
        public decimal PaymentAmount { get; set; }
        public int InvoiceId { get; set; }
        public decimal Tip { get; set; }
        public Payment( PaymentTypes paymentType, decimal paymentAmount, int invoiceId, decimal tip)
        {
            PaymentType = paymentType;
            PaymentAmount = paymentAmount;
            InvoiceId = invoiceId;
            Tip = tip;
        }
    }
    
}
