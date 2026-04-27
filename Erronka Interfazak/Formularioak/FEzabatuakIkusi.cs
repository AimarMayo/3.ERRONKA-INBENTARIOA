using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    /// <summary>
    /// Ezabatutako gailuak ikusteko formularioa. Historiko gisa gordetako ezabatutako gailu guztiak erakusten ditu.
    /// </summary>
    public partial class FEzabatuakIkusi : Form
    {
        /// <summary>
        /// FEzabatuakIkusi formularioa hasieratzen du.
        /// </summary>
        public FEzabatuakIkusi()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Formularioa kargatzean ezabatutako gailuak kargatzen ditu.
        /// </summary>
        /// <param name="sender">Gertaeraren iturria.</param>
        /// <param name="e">Gertaeraren argumentuak.</param>
        private void FEzabatuakIkusi_Load(object sender, EventArgs e)
        {
            KargatuEzabatuak();
        }

        /// <summary>
        /// EZABATUTAKO_GAILUA taulatik erregistro guztiak kargatzen ditu eta DataGridView-an erakusten ditu.
        /// </summary>
        private void KargatuEzabatuak()
        {
            try
            {
                DBKonexioa.konektatu();

                string query = "SELECT * FROM EZABATUTAKO_GAILUA";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, DBKonexioa.con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvEzabatuak.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea datuak kargatzean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
