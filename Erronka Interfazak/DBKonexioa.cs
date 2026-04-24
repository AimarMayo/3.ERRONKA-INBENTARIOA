using MySql.Data.MySqlClient;
using System;

namespace Erronka_Interfazak

{
    public static class DBKonexioa
    {
        public static MySqlConnection? con;
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