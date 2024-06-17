using System.Security.Cryptography;
namespace TestConsole
{
    using Model;
    using DAL;
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuItemDAO menuItemDAO = new MenuItemDAO();
            List<MenuItem> list = menuItemDAO.GetAllMenuItems();

            foreach (MenuItem item in list)
            {
                Console.WriteLine(item.Name);
            }

        }
    }
}