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
        public int OrderItemId { get; set; }
        public TimeOnly Time { get; set; }
        public int EmployeeId { get; set; }
        public int TableId { get; set; }
        public decimal Total { get; set; }
    }
}
