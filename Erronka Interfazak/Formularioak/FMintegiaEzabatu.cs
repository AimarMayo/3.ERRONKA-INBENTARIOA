using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    /// <summary>
    /// Mintegia ezabatzeko formularioa. ID bidez mintegia bilatzen du eta berrestea eskatu ondoren datu-basetik ezabatzen du.
    /// Mintegiak lotutako langileak edo gailuak baditu, ezabatzea blokeatzen du.
    /// </summary>
    public partial class FMintegiaEzabatu : Form
    {
        /// <summary>Uneko bilatutako mintegiaren identifikatzailea.</summary>
        private int _idMintegia = -1;

        /// <summary>
        /// FMintegiaEzabatu formularioa hasieratzen du eta gertaerak lotzen ditu.
        /// </summary>
        public FMintegiaEzabatu()
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
        /// Bilatu botoia sakatzean ID bidez mintegia datu-basetik bilatzen du eta emaitza erakusten du.
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
                _idMintegia = -1;
                return;
            }

            try
            {
                DBKonexioa.konektatu();

                string query = "SELECT ID_MINTEGIA, IZENA FROM MINTEGIA WHERE ID_MINTEGIA = @id";
                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                cmd.Parameters.AddWithValue("@id", id);
                using MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    lblemaitza.Text = "Ez da mintegiarik aurkitu ID horrekin.";
                    lblemaitza.ForeColor = Color.Red;
                    butezabatu.Enabled = false;
                    _idMintegia = -1;
                    return;
                }

                Mintegia mintegia = new Mintegia(
                    reader.GetInt32("ID_MINTEGIA"),
                    reader.GetString("IZENA"));

                _idMintegia = mintegia.Id;
                lblemaitza.Text = $"ID: {mintegia.Id}  |  {mintegia.Izena}";
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
        /// Ezabatu botoia sakatzean baieztapena eskatzen du eta mintegia datu-basetik ezabatzen du.
        /// FK murrizketa (errore 1451) aktibatzen bada, lotutako elementuak daudela ohartarazten du.
        /// </summary>
        /// <param name="sender">Gertaeraren iturria.</param>
        /// <param name="e">Gertaeraren argumentuak.</param>
        private void butezabatu_Click(object sender, EventArgs e)
        {
            if (_idMintegia == -1) return;

            DialogResult erantzuna = Galdera.Galdetu(
                $"Ziur zaude {_idMintegia} ID-ko mintegia ezabatu nahi duzula?",
                "Berrespena");

            if (erantzuna != DialogResult.Yes) return;

            try
            {
                DBKonexioa.konektatu();

                string query = "DELETE FROM MINTEGIA WHERE ID_MINTEGIA = @id";
                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                cmd.Parameters.AddWithValue("@id", _idMintegia);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Mintegia behar bezala ezabatu da.", "Ondo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtid.Clear();
                lblemaitza.Text = "";
                butezabatu.Enabled = false;
                _idMintegia = -1;
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                MessageBox.Show(
                    "Ezin da mintegia ezabatu.\n\n" +
                    "Mintegiak oraindik langileak edo gailuak ditu lotuta.\n" +
                    "Lehenik, mintegiarekin erlazionatutako langile eta gailu guztiak ezabatu edo aldatu behar dituzu.",
                    "Ezin da ezabatu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
