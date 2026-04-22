using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FLangileaEzabatu : Form
    {
        private int _idErabiltzailea = -1;

        public FLangileaEzabatu()
        {
            InitializeComponent();

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
                _idErabiltzailea = -1;
                return;
            }

            try
            {
                DBKonexioa.konektatu();

                string query = @"SELECT ID_ERABILTZAILEA, IZENA, EMAILA, ROLA
                                 FROM ERABILTZAILEA
                                 WHERE ID_ERABILTZAILEA = @id";

                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                cmd.Parameters.AddWithValue("@id", id);
                using MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    lblemaitza.Text = "Ez da langilerik aurkitu ID horrekin.";
                    lblemaitza.ForeColor = Color.Red;
                    butezabatu.Enabled = false;
                    _idErabiltzailea = -1;
                    return;
                }

                Erabiltzailea erabiltzailea = new Erabiltzailea(
                    reader["IZENA"].ToString()!,
                    reader["ROLA"].ToString()!,
                    reader["EMAILA"].ToString()!,
                    "");

                _idErabiltzailea = id;
                lblemaitza.Text = $"ID: {_idErabiltzailea}  |  {erabiltzailea.Izena}  |  {erabiltzailea.Emaila}  |  {erabiltzailea.Rola}";
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
            if (_idErabiltzailea == -1) return;

            DialogResult erantzuna = MessageBox.Show(
                $"Ziur zaude {_idErabiltzailea} ID-ko langilea ezabatu nahi duzula?",
                "Berrespena",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (erantzuna != DialogResult.Yes) return;

            try
            {
                DBKonexioa.konektatu();

                string query = "DELETE FROM ERABILTZAILEA WHERE ID_ERABILTZAILEA = @id";
                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                cmd.Parameters.AddWithValue("@id", _idErabiltzailea);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Langilea behar bezala ezabatu da.", "Ondo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtid.Clear();
                lblemaitza.Text = "";
                butezabatu.Enabled = false;
                _idErabiltzailea = -1;
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
