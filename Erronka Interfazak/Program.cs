namespace Erronka_Interfazak
{
    /// <summary>
    /// Aplikazioaren puntu nagusia. Inbentario kudeaketa sistemarako sarrera-puntua.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Aplikazioaren hasiera-puntua. Sarrera formularioa irekitzen du eta aplikazioa exekutatzen du.
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