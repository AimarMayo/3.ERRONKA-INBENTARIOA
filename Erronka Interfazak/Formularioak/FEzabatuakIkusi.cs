using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FEzabatuakIkusi : Form
    {
        public FEzabatuakIkusi()
        {
            InitializeComponent();
        }

        private void FEzabatuakIkusi_Load(object sender, EventArgs e)
        {
            KargatuEzabatuak();
        }

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
