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
                List<int?> mintegiaIdak = new List<int?>();

                string query = @"SELECT g.*, o.RAM, o.ROM, o.CPU, i.KOLORETAKOA
                                 FROM GAILUA g
                                 LEFT JOIN ORDENAGAILUA o ON o.ID_GAILUA = g.ID_GAILUA
                                 LEFT JOIN INPRIMAGAILUA i ON i.ID_GAILUA = g.ID_GAILUA";
                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                using MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id            = Convert.ToInt32(reader["ID_GAILUA"]);
                    string marka      = reader["MARKA"].ToString()!;
                    string kokalekua  = reader["KOKALEKUA"].ToString()!;
                    string egoera     = reader["EGOERA"].ToString()!;
                    DateTime erosteData = Convert.ToDateTime(reader["EROSTEDATA"]);

                    int mintegiaOrdinal = reader.GetOrdinal("ID_MINTEGIA");
                    mintegiaIdak.Add(reader.IsDBNull(mintegiaOrdinal) ? (int?)null : Convert.ToInt32(reader["ID_MINTEGIA"]));

                    int ramOrdinal          = reader.GetOrdinal("RAM");
                    int koloretakoaOrdinal  = reader.GetOrdinal("KOLORETAKOA");

                    Gailua gailua;
                    if (!reader.IsDBNull(ramOrdinal))
                    {
                        int ram    = Convert.ToInt32(reader["RAM"]);
                        int rom    = Convert.ToInt32(reader["ROM"]);
                        string cpu = reader["CPU"].ToString()!;
                        gailua = new Ordenagailua(marka, kokalekua, egoera, erosteData, ram, rom, cpu);
                    }
                    else if (!reader.IsDBNull(koloretakoaOrdinal))
                    {
                        bool koloretakoa = Convert.ToBoolean(reader["KOLORETAKOA"]);
                        gailua = new Inprimagailua(marka, kokalekua, egoera, erosteData, koloretakoa);
                    }
                    else
                    {
                        gailua = new Gailua(marka, kokalekua, egoera, erosteData);
                    }
                    gailua.Id = id;
                    zerrenda.Add(gailua);
                }

                dgvGailuak.DataSource = ZerrendaDataTable(zerrenda, mintegiaIdak);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea datuak kargatzean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ZerrendaDataTable(List<Gailua> zerrenda, List<int?> mintegiaIdak)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID",          typeof(int));
            dt.Columns.Add("Marka");
            dt.Columns.Add("Kokalekua");
            dt.Columns.Add("Egoera");
            dt.Columns.Add("ErosteData", typeof(DateTime));
            dt.Columns.Add("Mota");
            dt.Columns.Add("RAM",         typeof(int));
            dt.Columns.Add("ROM",         typeof(int));
            dt.Columns.Add("CPU");
            dt.Columns.Add("Koloretakoa", typeof(bool));
            dt.Columns.Add("ID_Mintegia", typeof(int));

            for (int idx = 0; idx < zerrenda.Count; idx++)
            {
                Gailua g = zerrenda[idx];
                DataRow row = dt.NewRow();
                row["ID"]        = g.Id;
                row["Marka"]     = g.Marka;
                row["Kokalekua"] = g.Kokalekua;
                row["Egoera"]    = g.Egoera;
                row["ErosteData"] = g.ErosteData1;
                row["ID_Mintegia"] = mintegiaIdak[idx].HasValue ? (object)mintegiaIdak[idx]! : DBNull.Value;

                if (g is Ordenagailua o)
                {
                    row["Mota"] = "Ordenagailua";
                    row["RAM"]  = o.Ram;
                    row["ROM"]  = o.Rom;
                    row["CPU"]  = o.Cpu;
                }
                else if (g is Inprimagailua i)
                {
                    row["Mota"]        = "Inprimagailua";
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
