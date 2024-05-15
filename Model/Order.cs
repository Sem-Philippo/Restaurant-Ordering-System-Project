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
        public List <OrderItem> orderItems { get; set; }
        public DateTime Time { get; set; }
        public int EmployeeId { get; set; }
        public int TableId { get; set; }
        public decimal Total { get; set; }

        public Order (int id, List<OrderItem> orderItems, DateTime time, int employeeId, int tableId, decimal total)
        {
            Id = id;
            this.orderItems = orderItems;
            Time = time;
            EmployeeId = employeeId;
            TableId = tableId;
            Total = total;
        }
    }
}
