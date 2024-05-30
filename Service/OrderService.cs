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
        public void SaveOrder(Order order)
        {
            OrderDAO orderDAO = new OrderDAO();
            orderDAO.SaveOrder(order);
        }
    }
}
