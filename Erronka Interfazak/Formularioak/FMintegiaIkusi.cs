using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FMintegiaIkusi : Form
    {
        public FMintegiaIkusi()
        {
            InitializeComponent();
        }

        private void FMintegiaIkusi_Load(object sender, EventArgs e)
        {
            KargatuMintegiak();
        }

        private void KargatuMintegiak()
        {
            try
            {
                DBKonexioa.konektatu();

                List<Mintegia> zerrenda = new List<Mintegia>();

                string query = "SELECT * FROM MINTEGIA";
                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                using MySqlDataReader reader = cmd.ExecuteReader();

                var idak = new List<int>();

                while (reader.Read())
                {
                    idak.Add(Convert.ToInt32(reader["ID_MINTEGIA"]));
                    string izena = reader["IZENA"].ToString()!;
                    zerrenda.Add(new Mintegia(izena));
                }

                dgvMintegiak.DataSource = ZerrendaDataTable(zerrenda, idak);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea datuak kargatzean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ZerrendaDataTable(List<Mintegia> zerrenda, List<int> idak)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Mintegia", typeof(int));
            dt.Columns.Add("Izena");

            for (int i = 0; i < zerrenda.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["ID_Mintegia"] = idak[i];
                row["Izena"]       = zerrenda[i].Izena;
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
