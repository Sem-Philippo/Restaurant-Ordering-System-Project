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
        OrderDAO orderDAO = new OrderDAO();
        public void SaveOrder(Order order)
        {
            orderDAO.SaveOrder(order);
        }
        public bool AddToExistingOrder(Order order)
        {
            return orderDAO.AddToExistingOrder(order);
        }
    }
}
