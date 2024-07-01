using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Payments
    {
        public int PaymentId { get; set; }
        public PaymentTypes PaymentType { get; set; }
        public decimal PaymentAmount { get; set; }
        public Invoice BillInvoice { get; set; }
        public decimal Tip { get; set; }
        public string Feedback { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public Payments(PaymentTypes paymentType, decimal paymentAmount, Invoice billInvoice, decimal tip, string feedback, DateTime paymentDateTime)
        {
            PaymentType = paymentType;
            PaymentAmount = paymentAmount;
            BillInvoice = billInvoice;
            Tip = tip;
            Feedback = feedback;
            PaymentDateTime = paymentDateTime;
        }
        public Payments() { }

    }

}