using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FIkusi : Form
    {
        public FIkusi()
        {
            InitializeComponent();
        }

        private void FIkusi_Load(object sender, EventArgs e)
        {
            KargatuGailuak();
        }

        private void KargatuGailuak()
        {
            try
            {
                DBKonexioa.konektatu();

                List<Gailua> zerrenda = new List<Gailua>();

                string query = "SELECT * FROM GAILUA";
                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                using MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string marka      = reader["MARKA"].ToString()!;
                    string kokalekua  = reader["KOKALEKUA"].ToString()!;
                    string egoera     = reader["EGOERA"].ToString()!;
                    DateTime erosteData = Convert.ToDateTime(reader["EROSTEDATA"]);

                    int ramOrdinal          = reader.GetOrdinal("RAM");
                    int koloretakoaOrdinal  = reader.GetOrdinal("KOLORETAKOA");

                    if (!reader.IsDBNull(ramOrdinal))
                    {
                        int ram    = Convert.ToInt32(reader["RAM"]);
                        int rom    = Convert.ToInt32(reader["ROM"]);
                        string cpu = reader["CPU"].ToString()!;
                        zerrenda.Add(new Ordenagailua(marka, kokalekua, egoera, erosteData, ram, rom, cpu));
                    }
                    else if (!reader.IsDBNull(koloretakoaOrdinal))
                    {
                        bool koloretakoa = Convert.ToBoolean(reader["KOLORETAKOA"]);
                        zerrenda.Add(new Inprimagailua(marka, kokalekua, egoera, erosteData, koloretakoa));
                    }
                    else
                    {
                        zerrenda.Add(new Gailua(marka, kokalekua, egoera, erosteData));
                    }
                }

                dgvGailuak.DataSource = ZerrendaDataTable(zerrenda);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea datuak kargatzean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ZerrendaDataTable(List<Gailua> zerrenda)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Marka");
            dt.Columns.Add("Kokalekua");
            dt.Columns.Add("Egoera");
            dt.Columns.Add("ErosteData", typeof(DateTime));
            dt.Columns.Add("Mota");
            dt.Columns.Add("RAM",         typeof(int));
            dt.Columns.Add("ROM",         typeof(int));
            dt.Columns.Add("CPU");
            dt.Columns.Add("Koloretakoa", typeof(bool));

            foreach (Gailua g in zerrenda)
            {
                DataRow row = dt.NewRow();
                row["Marka"]     = g.Marka;
                row["Kokalekua"] = g.Kokalekua;
                row["Egoera"]    = g.Egoera;
                row["ErosteData"] = g.ErosteData1;

                if (g is Ordenagailua o)
                {
                    row["Mota"] = "Ordenagailua";
                    row["RAM"]  = o.Ram;
                    row["ROM"]  = o.Rom;
                    row["CPU"]  = o.Cpu;
                }
                else if (g is Inprimagailua i)
                {
                    row["Mota"]       = "Inprimagailua";
                    row["Koloretakoa"] = i.Koloretakoa;
                }
                else
                {
                    row["Mota"] = "Gailua";
                }

                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
