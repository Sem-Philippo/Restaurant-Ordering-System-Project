using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService
    {
        private OrderDAO orderDAO;
        public OrderService()
        {
            orderDAO = new OrderDAO();
            
        }
       
    }
}
