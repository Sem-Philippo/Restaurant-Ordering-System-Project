﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public DateTime Time { get; set; }
        public Employee Employee { get; set; }
        public Table Table { get; set; }
        public decimal Total { get; set; }

        public Order(DateTime time, Employee employee, Table table, decimal total)
        {
            OrderItems = new List<OrderItem>();
            Time = time;
            Employee = employee;
            Table = table;
            Total = total;
        }
        public void AddOrderItem(OrderItem newItem)
        {
            bool itemFound = false;
            foreach (var item in OrderItems)
            {
                if (item.MenuItem.MenuItemId == newItem.MenuItem.MenuItemId)
                {
                    item.Quantity += newItem.Quantity;
                    itemFound = true;
                    break;
                }
            }

            if (!itemFound)
            {
                OrderItems.Add(newItem);
            }
        }
        
    }
}
