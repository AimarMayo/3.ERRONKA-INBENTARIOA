namespace Erronka_Interfazak
{
    /// <summary>
    /// Uneko erabiltzailearen saioa-datuak gordetzen dituen klase estatikoa.
    /// Saioa hasi ondoren, formulario guztiek klase honetatik irakurtzen dute erabiltzailearen informazioa.
    /// </summary>
    public static class Saioa
    {
        /// <summary>Saioa hasi duen erabiltzailearen helbide elektronikoa.</summary>
        public static string Emaila { get; set; } = "";

        /// <summary>Erabiltzailearen mintegiaren datu-baseko identifikatzailea.</summary>
        public static int MintegiaId { get; set; } = 0;

        /// <summary>Erabiltzailearen rola (Administratzailea, Mintegiburua, Irakaslea...).</summary>
        public static string Rola { get; set; } = "";
    }
}
