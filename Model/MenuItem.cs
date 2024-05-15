using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public int Stock { get; set; }
        public string Type { get; set; }
        public bool IsAlchoholic { get; set; }
    }
}
