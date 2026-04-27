using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    /// <summary>
    /// Mintegiak ikusteko formularioa. Sistemako mintegi guztiak DataGridView batean erakusten ditu.
    /// </summary>
    public partial class FMintegiaIkusi : Form
    {
        /// <summary>
        /// FMintegiaIkusi formularioa hasieratzen du.
        /// </summary>
        public FMintegiaIkusi()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Formularioa kargatzean mintegiak kargatzen ditu.
        /// </summary>
        /// <param name="sender">Gertaeraren iturria.</param>
        /// <param name="e">Gertaeraren argumentuak.</param>
        private void FMintegiaIkusi_Load(object sender, EventArgs e)
        {
            KargatuMintegiak();
        }

        /// <summary>
        /// Datu-basetik mintegi guztiak kargatzen ditu eta DataGridView-an erakusten ditu.
        /// </summary>
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
                    int id = Convert.ToInt32(reader["ID_MINTEGIA"]);
                    string izena = reader["IZENA"].ToString()!;
                    idak.Add(id);
                    zerrenda.Add(new Mintegia(id, izena));
                }

                dgvMintegiak.DataSource = ZerrendaDataTable(zerrenda, idak);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea datuak kargatzean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mintegien zerrenda DataTable formatura bihurtzen du DataGridView-an erakusteko.
        /// </summary>
        /// <param name="zerrenda">Mintegien zerrenda.</param>
        /// <param name="idak">Bakoitzari dagokion identifikatzaileen zerrenda.</param>
        /// <returns>Mintegien datuak dituen DataTable bat.</returns>
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
