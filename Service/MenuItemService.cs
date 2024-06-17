using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

using Model.Enums;

using DAL;


namespace Service
{
    public class MenuItemService
    {
        public MenuItemDAO MenuItemDAO { get; set; }
        public MenuItemService()
        {
            MenuItemDAO = new MenuItemDAO();
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return MenuItemDAO.GetAllMenuItems();
        }
        public void AddMenuItem(MenuItem menuItem)
        {
            MenuItemDAO.AddMenuItem(menuItem);
        }

        public void DeleteMenuItem(MenuItem menuItem)
        {
            MenuItemDAO.DeleteMenuItem(menuItem);
        }
        public void UpdateMenuItem(MenuItem menuItem, int id)
        {
            MenuItemDAO.UpdateMenuItem(menuItem, id);
        }
        public void UpdateStock(MenuItem menuItem, int stock)
        {
            MenuItemDAO.UpdateStock(menuItem, stock);
        }
        public List<MenuItem> RefreshItemsByCategory(MenuTypes type)
        {
            List<MenuItem> items = MenuItemDAO.GetAllMenuItems();
            List<MenuItem> filteredItems = new List<MenuItem>();

            foreach (MenuItem item in items)
            {
                if (item.Type == type)
                {
                    filteredItems.Add(item);
                }
            }
            return filteredItems;
        }
        public List<MenuItem> GetAllLowStockItems()
        {
            return MenuItemDAO.GetAllLowStockItems();
        }

        public string DisplayVatAsPercantage(decimal vat)
        {
            return (vat * 100).ToString("0.##") + "%";
        }

    }
}
