namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
<<<<<<< HEAD
            Application.Run(new Payment());
=======

            Application.Run(new LoginPage());

           

>>>>>>> 3116a052fb3deac49d79f7dbf944f18bbef924d6
        }
    }
}