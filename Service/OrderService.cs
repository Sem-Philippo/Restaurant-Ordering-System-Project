using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace Service
{
    public class OrderService
    {
        private OrderDAO orderDAO {  get; set; }
        public OrderService()
        {
            orderDAO = new OrderDAO();
        }
        public void SaveOrder(Order order)
        {
            orderDAO.SaveOrder(order);
        }
        public List<PaymentOverview> GetServedItemsByTableNumber(int tableNumber, out string employeeName, out int OrderID)
        {
            return orderDAO.GetServedItemsByTableNumber(tableNumber, out employeeName, out OrderID);
        }

        public decimal GetOrderDetailsByTableNumber(int tableNumber, out decimal lowVat, out decimal highVat, out string employeeName, out int OrderID)
        {
            List<PaymentOverview> items = GetServedItemsByTableNumber(tableNumber, out employeeName, out OrderID);
            decimal orderTotal = 0, vatValue = 0;
            lowVat = 0; highVat = 0;
            foreach (PaymentOverview item in items)
            {
                vatValue = (item.VAT * item.ItemPrice) * item.ItemQuantity;
                orderTotal += item.ItemTotalPrice;
                if (item.VAT == 0.06m)
                {
                    lowVat += vatValue;
                }
                else if (item.VAT == 0.21m)
                {
                    highVat += vatValue;
                }
            }
            return orderTotal;
        }
        public string DisplayVatAsPercantage(decimal vat)
        {
            return (vat * 100).ToString("0.##") + "%";
        }
        public string FormatToStringWithEuro(decimal amount)
        {
            return $"{amount.ToString("0.00")} €";
        }
        public decimal ParseAndRemoveEuro(string amount)
        {
            return decimal.Parse(amount.Replace(" €", ""));
        }
        public Order GetOrderByTableNumber(int tablenumber)
        {
            return orderDAO.GetOrderByTableNumber(tablenumber);
        }
    }

}
