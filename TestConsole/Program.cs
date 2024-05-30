namespace TestConsole
{
    using Model;
    using DAL;
    internal class Program
    {
        static void Main(string[] args)
        {
            string mode = Console.ReadLine();
            if (mode.ToLower() == "order")
            {
                Order order = new Order();
            }

        }
    }
}