using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PaymentOverview
    {
        public string ItemName { get; set; }
        public decimal VAT { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemDescription { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemTotalPrice { get; set; }
        public PaymentOverview(string itemName, decimal Vat, decimal itemPrice, string itemDescription, int itemQuantity, decimal itemTotalPrice)
        {
            ItemName = itemName;
            VAT = Vat;
            ItemPrice = itemPrice;
            ItemDescription = itemDescription;
            ItemQuantity = itemQuantity;
            ItemTotalPrice = itemTotalPrice;
        }
    }

}
