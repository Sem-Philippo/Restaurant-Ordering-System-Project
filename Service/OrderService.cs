using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public class OrderService
    {
        private OrderDAO orderDAO { get; set; }
        public OrderService()
        {
            orderDAO = new OrderDAO();
        }
        public void SaveOrder(Order order)
        {
            orderDAO.SaveOrder(order);
        }
        public Order GetServedItemsByTableNumber(int tableNumber, out string employeeName, out int orderId)
        {
            return orderDAO.GetServedItemsByTableNumber(tableNumber, out employeeName, out orderId);
        }

        public decimal GetOrderDetailsByTableNumber(int tableNumber, out decimal lowVat, out decimal highVat, out string employeeName, out int orderId)
        {
            Order order = GetServedItemsByTableNumber(tableNumber, out employeeName, out orderId);
            decimal orderTotal = 0, vatValue = 0;
            lowVat = 0; highVat = 0;
            foreach (OrderItem item in order.OrderItems)
            {
                vatValue = (item.MenuItem.Tax * item.MenuItem.Price) * item.Quantity;
                orderTotal += item.MenuItem.Price * item.Quantity;
                if (item.MenuItem.Tax == 0.06m)
                {
                    lowVat += vatValue;
                }
                else if (item.MenuItem.Tax == 0.21m)
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
        public bool AddToExistingOrder(Order order)
        {
            return orderDAO.AddToExistingOrder(order);
        }
    }
}