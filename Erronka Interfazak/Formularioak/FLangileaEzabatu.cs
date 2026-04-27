using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    /// <summary>
    /// Langilea ezabatzeko formularioa. ID bidez langilea bilatzen du, berrestea eskatzen du eta datu-basetik ezabatzen du.
    /// </summary>
    public partial class FLangileaEzabatu : Form
    {
        /// <summary>Uneko bilatutako langilearen identifikatzailea.</summary>
        private int _idErabiltzailea = -1;

        /// <summary>
        /// FLangileaEzabatu formularioa hasieratzen du eta gertaerak lotzen ditu.
        /// </summary>
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

        /// <summary>
        /// Datu-panela eta izenburua panelaren erdian kokatzen ditu tamaina aldatzean.
        /// </summary>
        private void ErdiratuKontrolak()
        {
            int w = panela.ClientSize.Width;
            int h = panela.ClientSize.Height;

            panDatuak.Left = (w - panDatuak.Width) / 2;
            panDatuak.Top = (h - panDatuak.Height) / 2;

            lblizenburua.Left = (w - lblizenburua.Width) / 2;
            lblizenburua.Top = panDatuak.Top - lblizenburua.Height - 20;
        }

        /// <summary>
        /// Bilatu botoia sakatzean ID bidez langilea datu-basetik bilatzen du eta emaitza erakusten du.
        /// </summary>
        /// <param name="sender">Gertaeraren iturria.</param>
        /// <param name="e">Gertaeraren argumentuak.</param>
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

        /// <summary>
        /// Ezabatu botoia sakatzean erabiltzaileari baieztapena eskatzen dio eta langilea datu-basetik ezabatzen du.
        /// </summary>
        /// <param name="sender">Gertaeraren iturria.</param>
        /// <param name="e">Gertaeraren argumentuak.</param>
        private void butezabatu_Click(object sender, EventArgs e)
        {
            if (_idErabiltzailea == -1) return;

            DialogResult erantzuna = Galdera.Galdetu(
                $"Ziur zaude {_idErabiltzailea} ID-ko langilea ezabatu nahi duzula?",
                "Berrespena");

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
