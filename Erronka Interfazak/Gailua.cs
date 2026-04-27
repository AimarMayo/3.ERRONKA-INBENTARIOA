namespace Erronka_Interfazak
{
    /// <summary>
    /// Inbentarioko gailu baten oinarrizko eredua. Ordenagailuak eta inprimagailuak klase honetatik heredatzen dira.
    /// </summary>
    public class Gailua
    {
        private int id;
        private string marka, kokalekua, egoera;
        private DateTime erosteData;

        /// <summary>Gailuaren datu-baseko identifikatzaile bakarra.</summary>
        public int Id { get => id; set => id = value; }

        /// <summary>Gailuaren marka edo fabrikatzailea.</summary>
        public string Marka { get => marka; set => marka = value; }

        /// <summary>Gailua dagoen kokalekua edo gela.</summary>
        public string Kokalekua { get => kokalekua; set => kokalekua = value; }

        /// <summary>Gailuaren uneko egoera (erabilgarri, matxuratuta...).</summary>
        public string Egoera { get => egoera; set => egoera = value; }

        /// <summary>Gailua erosi zen data.</summary>
        public DateTime ErosteData1 { get => erosteData; set => erosteData = value; }

        /// <summary>
        /// Gailua sortzen du datu-baseko ID batekin.
        /// </summary>
        /// <param name="id">Gailuaren datu-baseko identifikatzailea.</param>
        /// <param name="marka">Gailuaren marka.</param>
        /// <param name="kokalekua">Gailuaren kokalekua.</param>
        /// <param name="egoera">Gailuaren egoera.</param>
        /// <param name="erosteData">Eroste data.</param>
        public Gailua(int id, string marka, string kokalekua, string egoera, DateTime erosteData)
        {
            this.id = id;
            this.marka = marka;
            this.kokalekua = kokalekua;
            this.egoera = egoera;
            this.erosteData = erosteData;
        }

        /// <summary>
        /// Gailua sortzen du ID gabe (datu-basean txertatu aurretik erabiltzeko).
        /// </summary>
        /// <param name="marka">Gailuaren marka.</param>
        /// <param name="kokalekua">Gailuaren kokalekua.</param>
        /// <param name="egoera">Gailuaren egoera.</param>
        /// <param name="erosteData">Eroste data.</param>
        public Gailua(string marka, string kokalekua, string egoera, DateTime erosteData)
        {
            id = 0;
            this.marka = marka;
            this.kokalekua = kokalekua;
            this.egoera = egoera;
            this.erosteData = erosteData;
        }
    }
}
