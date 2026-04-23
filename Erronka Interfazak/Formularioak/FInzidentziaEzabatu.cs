using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FInzidentziaEzabatu : Form
    {
        private int _inzidentziaId = -1;
        private Gailua? _gailua = null;

        public FInzidentziaEzabatu()
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
            panDatuak.Top  = (h - panDatuak.Height) / 2;

            lblizenburua.Left = (w - lblizenburua.Width) / 2;
            lblizenburua.Top  = panDatuak.Top - lblizenburua.Height - 20;
        }

        private void butbilatu_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtid.Text.Trim(), out int id))
            {
                lblemaitza.Text = "Mesedez, sartu ID zenbaki bat.";
                lblemaitza.ForeColor = Color.Red;
                butezabatu.Enabled = false;
                _inzidentziaId = -1;
                _gailua = null;
                return;
            }

            try
            {
                DBKonexioa.konektatu();

                string query = @"SELECT i.ID_INZIDENTZIA, g.ID_GAILUA, g.MARKA, g.KOKALEKUA, g.EGOERA, g.EROSTEDATA
                                 FROM INZIDENTZIAK i
                                 JOIN GAILUA g ON g.ID_GAILUA = i.ID_GAILUA
                                 WHERE i.ID_INZIDENTZIA = @id AND g.EGOERA = 'matxuratuta'";
                if (Saioa.Rola == "Mintegiburua")
                    query += " AND g.ID_MINTEGIA = @idmintegia";

                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                cmd.Parameters.AddWithValue("@id", id);
                if (Saioa.Rola == "Mintegiburua")
                    cmd.Parameters.AddWithValue("@idmintegia", Saioa.MintegiaId);
                using MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    lblemaitza.Text = Saioa.Rola == "Mintegiburua"
                        ? "Ez da inzidentziarik aurkitu ID horrekin zure mintegian (matxuratuta egon behar du)."
                        : "Ez da inzidentziarik aurkitu ID horrekin edo gailua ez dago matxuratuta.";
                    lblemaitza.ForeColor = Color.Red;
                    butezabatu.Enabled = false;
                    _inzidentziaId = -1;
                    _gailua = null;
                    return;
                }

                _inzidentziaId = reader.GetInt32("ID_INZIDENTZIA");
                int idGailua   = reader.GetInt32("ID_GAILUA");
                string marka   = reader["MARKA"].ToString()!;
                string kokalekua = reader["KOKALEKUA"].ToString()!;
                string egoera  = reader["EGOERA"].ToString()!;
                DateTime erosteData = Convert.ToDateTime(reader["EROSTEDATA"]);

                _gailua = new Gailua(idGailua, marka, kokalekua, egoera, erosteData);

                lblemaitza.Text = $"Inzidentzia: {_inzidentziaId}  |  {_gailua.Marka}  |  {_gailua.Kokalekua}  |  {_gailua.Egoera}";
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
            if (_gailua == null || _inzidentziaId == -1) return;

            DialogResult erantzuna = Galdera.Galdetu(
                $"Ziur zaude {_inzidentziaId} ID-ko inzidentzia ezabatu nahi duzula?",
                "Berrespena");

            if (erantzuna != DialogResult.Yes) return;

            try
            {
                DBKonexioa.konektatu();

                string deleteInzidentzia = "DELETE FROM INZIDENTZIAK WHERE ID_INZIDENTZIA = @id";
                using (MySqlCommand cmd = new MySqlCommand(deleteInzidentzia, DBKonexioa.con))
                {
                    cmd.Parameters.AddWithValue("@id", _inzidentziaId);
                    cmd.ExecuteNonQuery();
                }

                string updateGailua = "UPDATE GAILUA SET EGOERA = 'erabilgarri' WHERE ID_GAILUA = @id";
                using (MySqlCommand cmd = new MySqlCommand(updateGailua, DBKonexioa.con))
                {
                    cmd.Parameters.AddWithValue("@id", _gailua.Id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Inzidentzia behar bezala ezabatu da.", "Ondo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtid.Clear();
                lblemaitza.Text = "";
                butezabatu.Enabled = false;
                _inzidentziaId = -1;
                _gailua = null;
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
