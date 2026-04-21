using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    con = new MySqlConnection("Server=izarraitzinbentarioa-izarraitzinbentarioa.e.aivencloud.com;Port=22290;Database=defaultdb;Uid=avnadmin;Pwd=AVNS_N1qRL_HakB4iWRZoqMQ;SslMode=Required;SslCa=C:\\Users\\aimar\\Downloads\\ca.pem;");

                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
            }
            catch
            {

            }
        }
        public static void deskonektatu()
        {
            if (con != null && con.State != System.Data.ConnectionState.Closed)
                con.Close();
        }
    }
}