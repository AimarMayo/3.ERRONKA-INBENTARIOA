using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FLangileakIkusi : Form
    {
        public FLangileakIkusi()
        {
            InitializeComponent();
        }

        private void FLangileakIkusi_Load(object sender, EventArgs e)
        {
            KargatuLangileak();
        }

        private void KargatuLangileak()
        {
            try
            {
                DBKonexioa.konektatu();

                List<Erabiltzailea> zerrenda = new List<Erabiltzailea>();

                string query = "SELECT * FROM ERABILTZAILEA";
                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                using MySqlDataReader reader = cmd.ExecuteReader();

                var idak = new List<int>();
                var mintegiaIdak = new List<int?>();

                while (reader.Read())
                {
                    idak.Add(Convert.ToInt32(reader["ID_ERABILTZAILEA"]));
                    int ordinal = reader.GetOrdinal("ID_MINTEGIA");
                    mintegiaIdak.Add(reader.IsDBNull(ordinal) ? (int?)null : Convert.ToInt32(reader["ID_MINTEGIA"]));
                    string izena     = reader["IZENA"].ToString()!;
                    string rola      = reader["ROLA"].ToString()!;
                    string emaila    = reader["EMAILA"].ToString()!;
                    string pasahitza = reader["PASAHITZA"].ToString()!;
                    zerrenda.Add(new Erabiltzailea(izena, rola, emaila, pasahitza));
                }

                dgvLangileak.DataSource = ZerrendaDataTable(zerrenda, idak, mintegiaIdak);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea datuak kargatzean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ZerrendaDataTable(List<Erabiltzailea> zerrenda, List<int> idak, List<int?> mintegiaIdak)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Erabiltzailea", typeof(int));
            dt.Columns.Add("Izena");
            dt.Columns.Add("Rola");
            dt.Columns.Add("Emaila");
            dt.Columns.Add("Pasahitza");
            dt.Columns.Add("ID_Mintegia", typeof(int));

            for (int i = 0; i < zerrenda.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["ID_Erabiltzailea"] = idak[i];
                row["Izena"]            = zerrenda[i].Izena;
                row["Rola"]             = zerrenda[i].Rola;
                row["Emaila"]           = zerrenda[i].Emaila;
                row["Pasahitza"]        = zerrenda[i].Pasahitza;
                row["ID_Mintegia"]      = mintegiaIdak[i].HasValue ? (object)mintegiaIdak[i]! : DBNull.Value;
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
