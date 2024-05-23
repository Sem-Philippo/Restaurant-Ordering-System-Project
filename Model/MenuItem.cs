using Model.Enums;
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
        public Categories Category { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public int Stock { get; set; }
        public MenuTypes Type { get; set; }
        public bool IsAlchoholic { get; set; }
        public MenuItem(int menuItemId, string name, Categories category, decimal price, decimal tax, int stock, MenuTypes type, bool isAlchoholic)
        {
            MenuItemId = menuItemId;
            Name = name;
            Category = category;
            Price = price;
            Tax = tax;
            Stock = stock;
            Type = type;
            IsAlchoholic = isAlchoholic;
        }
    }
}
