using MySql.Data.MySqlClient;
using System;

namespace Erronka_Interfazak

{
    /// <summary>
    /// MySQL datu-basearekin konexioa kudeatzen duen klase estatikoa.
    /// </summary>
    public static class DBKonexioa
    {
        /// <summary>Datu-basearekin partekatutako konexio-instantzia.</summary>
        public static MySqlConnection? con;

        /// <summary>
        /// Datu-basearekin konexioa irekitzen du, oraindik irekita ez badago.
        /// </summary>
        public static void konektatu()
        {
            try
            {
                if (con == null)
                    con = new MySqlConnection("Server=sql7.freesqldatabase.com;Port=3306;Database=sql7823980;Uid=sql7823980;Pwd=cnSQMT5lub;");

                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
            }
            catch
            {

            }
        }
    }
}