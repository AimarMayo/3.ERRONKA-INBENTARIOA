using System;

namespace Erronka_Interfazak
{
    /// <summary>
    /// Lantegi edo mintegiaren eredua. Gailuak eta langileak mintegiarekin lotzen dira.
    /// </summary>
    public class Mintegia
    {
        private int id;
        private string izena;

        /// <summary>Mintegiaren datu-baseko identifikatzaile bakarra.</summary>
        public int Id { get => id; set => id = value; }

        /// <summary>Mintegiaren izena.</summary>
        public string Izena { get => izena; set => izena = value; }

        /// <summary>
        /// Mintegia sortzen du ID eta izenarekin.
        /// </summary>
        /// <param name="id">Datu-baseko identifikatzailea.</param>
        /// <param name="i">Mintegiaren izena.</param>
        public Mintegia(int id, string i)
        {
            this.id = id;
            izena = i;
        }

        /// <summary>
        /// Mintegia sortzen du hutsik (combo-box-etarako hasieraketa moduan).
        /// </summary>
        public Mintegia() { }

        /// <summary>
        /// Mintegiaren izenaren testu-adierazpena itzultzen du.
        /// </summary>
        /// <returns>Mintegiaren izena.</returns>
        public override string ToString() => izena;
    }
}
