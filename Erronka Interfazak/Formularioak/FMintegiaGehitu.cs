using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FMintegiaGehitu : Form
    {
        public FMintegiaGehitu()
        {
            InitializeComponent();

            panela.Resize += (s, e) => ErdiratuKontrolak();
            this.Load += (s, e) => ErdiratuKontrolak();
        }

        private void ErdiratuKontrolak()
        {
            int w = panela.ClientSize.Width;
            int h = panela.ClientSize.Height;

            panDatuak.Left = (w - panDatuak.Width) / 2;
            panDatuak.Top = (h - panDatuak.Height) / 2;

            lblTitulua.Left = (w - lblTitulua.Width) / 2;
            lblTitulua.Top = panDatuak.Top - lblTitulua.Height - 20;
        }

        private void butGehitu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIzena.Text))
            {
                MessageBox.Show("Mesedez, sartu mintegiaren izena.", "Abisua",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Mintegia mintegia = new Mintegia(0, txtIzena.Text.Trim());

            try
            {
                DBKonexioa.konektatu();

                string queryBilatu = "SELECT COUNT(*) FROM MINTEGIA WHERE LOWER(IZENA) = LOWER(@izena)";
                using (MySqlCommand cmdBilatu = new MySqlCommand(queryBilatu, DBKonexioa.con))
                {
                    cmdBilatu.Parameters.AddWithValue("@izena", mintegia.Izena);
                    int kopurua = Convert.ToInt32(cmdBilatu.ExecuteScalar());
                    if (kopurua > 0)
                    {
                        MessageBox.Show($"'{mintegia.Izena}' izeneko mintegia bat dagoeneko existitzen da.", "Abisua",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string query = "INSERT INTO MINTEGIA (IZENA) VALUES (@izena)";
                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                cmd.Parameters.AddWithValue("@izena", mintegia.Izena);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Mintegia behar bezala gorde da!", "Ondo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtIzena.Clear();
                txtIzena.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea mintegia gordetzean:\n{ex.Message}", "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butAtzera_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is FMenua menu) { menu.MostrarMenua(); return; }
            }
        }
    }
}
