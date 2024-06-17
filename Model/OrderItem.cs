using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public Status Status { get; set; }
        public string Comment { get; set; }
        public TimeSpan StatusTime { get; set; }


        public OrderItem(MenuItem menuItem, int quantity, Status status, string comment, TimeSpan statusTime)
        {
            MenuItem = menuItem;
            Quantity = quantity;
            Status = status;
            Comment = comment;
            StatusTime = statusTime;
        }
    }
}
