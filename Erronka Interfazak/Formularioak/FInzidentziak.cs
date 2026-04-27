using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    /// <summary>
    /// Inzidentziak ikusteko formularioa. Matxuratutako gailuen inzidentzia guztiak DataGridView batean erakusten ditu.
    /// </summary>
    public partial class FInzidentziak : Form
    {
        /// <summary>
        /// FInzidentziak formularioa hasieratzen du.
        /// </summary>
        public FInzidentziak()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Formularioa kargatzean inzidentziak kargatzen ditu.
        /// </summary>
        /// <param name="sender">Gertaeraren iturria.</param>
        /// <param name="e">Gertaeraren argumentuak.</param>
        private void FInzidentziak_Load(object sender, EventArgs e)
        {
            KargatuInzidentziak();
        }

        /// <summary>
        /// Datu-basetik inzidentzia guztiak kargatzen ditu eta DataGridView-an erakusten ditu.
        /// </summary>
        private void KargatuInzidentziak()
        {
            try
            {
                DBKonexioa.konektatu();

                string query = "SELECT * FROM INZIDENTZIAK";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, DBKonexioa.con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvInzidentziak.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea datuak kargatzean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
