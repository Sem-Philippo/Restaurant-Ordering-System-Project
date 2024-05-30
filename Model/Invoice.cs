﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateOnly OrderDate { get; set; }
        public Order Order { get; set; }
        public decimal LowVat { get; set; }
        public decimal HighVat { get; set; }

        public Invoice ( DateOnly orderDate, Order orders, decimal lowVat, decimal highVat)
        {
            OrderDate = orderDate;
            Order = orders;
            LowVat = lowVat;
            HighVat = highVat;
        }
    }
}
