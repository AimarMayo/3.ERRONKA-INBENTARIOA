using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FInzidentziak : Form
    {
        public FInzidentziak()
        {
            InitializeComponent();
        }

        private void FInzidentziak_Load(object sender, EventArgs e)
        {
            KargatuInzidentziak();
        }

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
