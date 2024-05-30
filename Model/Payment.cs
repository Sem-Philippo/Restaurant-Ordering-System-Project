﻿using Model.Enums;
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
        public PaymentTypes PaymentAmount { get; set; }
        public int InvoiceId { get; set; }
        public decimal Tip { get; set; }
        public Payment(string paymentType, PaymentTypes paymentAmount, int invoiceId, decimal tip)
        {
            PaymentType = paymentType;
            PaymentAmount = paymentAmount;
            InvoiceId = invoiceId;
            Tip = tip;
        }
    }
    
}
