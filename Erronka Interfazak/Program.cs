namespace Erronka_Interfazak
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FSarrera fSarrera = new FSarrera();
            fSarrera.Show();

            Application.Run();
        }
    }
}