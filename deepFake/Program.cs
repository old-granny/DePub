using Org.BouncyCastle.Tls;

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
            
            SandBoxe pageAcceuil = new SandBoxe();
            SetGlobals();
            Application.Run(pageAcceuil);
            Globals.AppRunning = false;
        }
        static void SetGlobals()
        {
            Globals.AppRunning = true;
            Globals.FlagChanger = true;
        }
        
    }
   
}