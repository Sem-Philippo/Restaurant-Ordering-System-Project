using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        public int Id { get; set; }
        public List <OrderItem> OrderItems { get; set; }
        public DateTime Time { get; set; }
        public Employee EmployeeId { get; set; }
        public Table Table { get; set; }
        public decimal Total { get; set; }

        public Order (DateTime time, Employee employeeId, Table tableId, decimal total)
        {
            List<OrderItem> OrderItems = new List<OrderItem>();
            Time = time;
            EmployeeId = employeeId;
            Table = tableId;
            Total = total;
        }
        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }
    }
}
