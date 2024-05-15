using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderItem
    {
        public int OrderitemId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public Status Status { get; set; }
        public string Comment { get; set; }
        public TimeOnly StatusTime { get; set; }

    }
}
