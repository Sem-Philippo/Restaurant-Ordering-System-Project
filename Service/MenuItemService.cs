using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace Service
{
    public class MenuItemService
    {
        MenuItemDAO MenuItemDAO { get; set; }
        public MenuItemService()
        {
            MenuItemDAO = new MenuItemDAO();
        }

        public void GetAllMenuItems()
        {
            MenuItemDAO.GetAllMenuItems();
        }
        public void AddMenuItem(MenuItem menuItem)
        {
            MenuItemDAO.AddMenuItem(menuItem);
        }

        public void DeleteMenuItem(MenuItem menuItem)
        {
            MenuItemDAO.DeleteMenuITem(menuItem);
        }
        public void UpdateMenuItem(MenuItem menuItem)
        {
            MenuItemDAO.UpdateMenuItem(menuItem);
        }
        public void UpdateStock(MenuItem menuItem, int stock)
        {
            MenuItemDAO.UpdateStock(menuItem, stock);
        }


    }
}
