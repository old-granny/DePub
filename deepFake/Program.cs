namespace deepFake
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Acceuil pageAcceuil = new Acceuil();
            Application.Run(pageAcceuil);
        }
        
    }
   
}