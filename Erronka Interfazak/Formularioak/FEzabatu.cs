using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FEzabatu : Form
    {
        private int _idGailua = -1;

        public FEzabatu()
        {
            InitializeComponent();

            butbilatu.Click += butbilatu_Click;
            butezabatu.Click += butezabatu_Click;

            panela.Resize += (s, e) => ErdiratuKontrolak();
            this.Load += (s, e) =>
            {
                ErdiratuKontrolak();
                butezabatu.Enabled = false;
            };
        }

        private void ErdiratuKontrolak()
        {
            int w = panela.ClientSize.Width;
            int h = panela.ClientSize.Height;

            panDatuak.Left = (w - panDatuak.Width) / 2;
            panDatuak.Top = (h - panDatuak.Height) / 2;

            lblizenburua.Left = (w - lblizenburua.Width) / 2;
            lblizenburua.Top = panDatuak.Top - lblizenburua.Height - 20;
        }

        private void butbilatu_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtid.Text.Trim(), out int id))
            {
                lblemaitza.Text = "Mesedez, sartu ID zenbaki bat.";
                lblemaitza.ForeColor = Color.Red;
                butezabatu.Enabled = false;
                _idGailua = -1;
                return;
            }

            try
            {
                DBKonexioa.konektatu();

                string query = @"SELECT g.ID_GAILUA, g.MARKA, g.KOKALEKUA, g.EGOERA
                                 FROM GAILUA g
                                 WHERE g.ID_GAILUA = @id";

                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                cmd.Parameters.AddWithValue("@id", id);
                using MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    lblemaitza.Text = "Ez da gailurik aurkitu ID horrekin.";
                    lblemaitza.ForeColor = Color.Red;
                    butezabatu.Enabled = false;
                    _idGailua = -1;
                    return;
                }

                _idGailua = id;
                string marka = reader["MARKA"].ToString()!;
                string kokalekua = reader["KOKALEKUA"].ToString()!;
                string egoera = reader["EGOERA"].ToString()!;

                lblemaitza.Text = $"ID: {_idGailua}  |  {marka}  |  {kokalekua}  |  {egoera}";
                lblemaitza.ForeColor = Color.Black;
                butezabatu.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea bilaketean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butezabatu_Click(object sender, EventArgs e)
        {
            if (_idGailua == -1) return;

            DialogResult erantzuna = MessageBox.Show(
                $"Ziur zaude {_idGailua} ID-ko gailua ezabatu nahi duzula?",
                "Berrespena",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (erantzuna != DialogResult.Yes) return;

            try
            {
                DBKonexioa.konektatu();

                // Las tablas hijas se eliminan primero por las FK
                string deleteOrdenagailua = "DELETE FROM ORDENAGAILUA WHERE ID_GAILUA = @id";
                using (MySqlCommand cmd1 = new MySqlCommand(deleteOrdenagailua, DBKonexioa.con))
                {
                    cmd1.Parameters.AddWithValue("@id", _idGailua);
                    cmd1.ExecuteNonQuery();
                }

                string deleteInprimagailua = "DELETE FROM INPRIMAGAILUA WHERE ID_GAILUA = @id";
                using (MySqlCommand cmd2 = new MySqlCommand(deleteInprimagailua, DBKonexioa.con))
                {
                    cmd2.Parameters.AddWithValue("@id", _idGailua);
                    cmd2.ExecuteNonQuery();
                }

                string deleteGailua = "DELETE FROM GAILUA WHERE ID_GAILUA = @id";
                using (MySqlCommand cmd3 = new MySqlCommand(deleteGailua, DBKonexioa.con))
                {
                    cmd3.Parameters.AddWithValue("@id", _idGailua);
                    cmd3.ExecuteNonQuery();
                }

                MessageBox.Show("Gailua behar bezala ezabatu da.", "Ondo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtid.Clear();
                lblemaitza.Text = "";
                butezabatu.Enabled = false;
                _idGailua = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea ezabatzean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butatzera_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is FMenua menu) { menu.MostrarMenua(); return; }
            }
        }
    }
}
