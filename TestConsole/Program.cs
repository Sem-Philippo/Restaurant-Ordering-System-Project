namespace TestConsole
{
    using Model;
    using DAL;
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuItemDAO dao = new MenuItemDAO();
            dao.GetAllMenuItems();

        }
    }
}