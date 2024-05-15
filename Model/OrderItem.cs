using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public int Quantity { get; set; }
        public Status Status { get; set; }
        public string Comment { get; set; }
        public TimeSpan StatusTime { get; set; }


        public OrderItem( int orderItemId, List<MenuItem> menuItems, int quantity, Status status, string comment, TimeSpan statusTime)
        {
            OrderItemId = orderItemId;
            MenuItems = menuItems;
            Quantity = quantity;
            Status = status;
            Comment = comment;
            StatusTime = statusTime;
        }
    }
}
