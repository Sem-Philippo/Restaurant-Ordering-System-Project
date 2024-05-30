using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace Service
{
    public class MenuItemService
    {
        public List<MenuItem> GetAllMenuItems()
        {
            MenuItemDAO menuItemDao = new MenuItemDAO();
            return menuItemDao.GetAllMenuItems();
        }
    }
}
