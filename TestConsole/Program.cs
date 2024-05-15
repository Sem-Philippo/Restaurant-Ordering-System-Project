namespace TestConsole
{
    using Model;
    using DAL;
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeDAO dao = new EmployeeDAO();
            List<Employee> test = dao.GetAllDrinks();
            foreach (Employee emp in test)
            {
                Console.WriteLine(emp.FirstName);
            }

        }
    }
}