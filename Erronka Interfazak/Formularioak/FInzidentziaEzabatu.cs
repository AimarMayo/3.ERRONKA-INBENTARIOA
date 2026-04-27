using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    /// <summary>
    /// Inzidentzia ezabatzeko formularioa. ID bidez inzidentzia bilatzen du, gailua ezabatutakoen zerrendara
    /// mugitzen du eta inzidentzia eta gailua datu-basetik ezabatzen ditu.
    /// </summary>
    public partial class FInzidentziaEzabatu : Form
    {
        /// <summary>Uneko bilatutako inzidentziaren identifikatzailea.</summary>
        private int _inzidentziaId = -1;

        /// <summary>Inzidentziari lotutako gailua.</summary>
        private Gailua? _gailua = null;

        /// <summary>
        /// FInzidentziaEzabatu formularioa hasieratzen du eta gertaerak lotzen ditu.
        /// </summary>
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

        /// <summary>
        /// Datu-panela eta izenburua panelaren erdian kokatzen ditu tamaina aldatzean.
        /// </summary>
        private void ErdiratuKontrolak()
        {
            int w = panela.ClientSize.Width;
            int h = panela.ClientSize.Height;

            panDatuak.Left = (w - panDatuak.Width) / 2;
            panDatuak.Top  = (h - panDatuak.Height) / 2;

            lblizenburua.Left = (w - lblizenburua.Width) / 2;
            lblizenburua.Top  = panDatuak.Top - lblizenburua.Height - 20;
        }

        /// <summary>
        /// Bilatu botoia sakatzean ID bidez inzidentzia matxuratutako gailuekin bilatzen du.
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

        /// <summary>
        /// Ezabatu botoia sakatzean inzidentzia ezabatzen du, gailua ezabatutakoen zerrendara mugitzen du
        /// eta lotutako inzidentzia eta gailua datu-basetik kentzen ditu.
        /// </summary>
        /// <param name="sender">Gertaeraren iturria.</param>
        /// <param name="e">Gertaeraren argumentuak.</param>
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

                int idErabiltzailea;
                string queryUserId = "SELECT ID_ERABILTZAILEA FROM ERABILTZAILEA WHERE EMAILA = @emaila";
                using (MySqlCommand cmd = new MySqlCommand(queryUserId, DBKonexioa.con))
                {
                    cmd.Parameters.AddWithValue("@emaila", Saioa.Emaila);
                    idErabiltzailea = Convert.ToInt32(cmd.ExecuteScalar());
                }

                string queryMota = @"SELECT CASE
                                         WHEN o.ID_GAILUA IS NOT NULL THEN 'Ordenagailua'
                                         WHEN i.ID_GAILUA IS NOT NULL THEN 'Inprimagailua'
                                         ELSE 'Gailua' END AS MOTA
                                     FROM GAILUA g
                                     LEFT JOIN ORDENAGAILUA o ON o.ID_GAILUA = g.ID_GAILUA
                                     LEFT JOIN INPRIMAGAILUA i ON i.ID_GAILUA = g.ID_GAILUA
                                     WHERE g.ID_GAILUA = @idgailua";
                string mota;
                using (MySqlCommand cmd = new MySqlCommand(queryMota, DBKonexioa.con))
                {
                    cmd.Parameters.AddWithValue("@idgailua", _gailua.Id);
                    mota = cmd.ExecuteScalar()?.ToString() ?? "Gailua";
                }

                string moveGailua = @"INSERT INTO EZABATUTAKO_GAILUA (marka, kokalekua, mota, erostedata, ezabatze_data, id_erabiltzailea)
                                      VALUES (@marka, @kokalekua, @mota, @erostedata, @ezabatze_data, @id_erabiltzailea)";
                using (MySqlCommand cmd = new MySqlCommand(moveGailua, DBKonexioa.con))
                {
                    cmd.Parameters.AddWithValue("@marka", _gailua.Marka);
                    cmd.Parameters.AddWithValue("@kokalekua", _gailua.Kokalekua);
                    cmd.Parameters.AddWithValue("@mota", mota);
                    cmd.Parameters.AddWithValue("@erostedata", _gailua.ErosteData1);
                    cmd.Parameters.AddWithValue("@ezabatze_data", DateTime.Today);
                    cmd.Parameters.AddWithValue("@id_erabiltzailea", idErabiltzailea);
                    cmd.ExecuteNonQuery();
                }

                string deleteInzidentziak = "DELETE FROM INZIDENTZIAK WHERE ID_GAILUA = @idgailua";
                using (MySqlCommand cmd = new MySqlCommand(deleteInzidentziak, DBKonexioa.con))
                {
                    cmd.Parameters.AddWithValue("@idgailua", _gailua.Id);
                    cmd.ExecuteNonQuery();
                }

                string deleteOrdenagailua = "DELETE FROM ORDENAGAILUA WHERE ID_GAILUA = @idgailua";
                using (MySqlCommand cmd = new MySqlCommand(deleteOrdenagailua, DBKonexioa.con))
                {
                    cmd.Parameters.AddWithValue("@idgailua", _gailua.Id);
                    cmd.ExecuteNonQuery();
                }

                string deleteInprimagailua = "DELETE FROM INPRIMAGAILUA WHERE ID_GAILUA = @idgailua";
                using (MySqlCommand cmd = new MySqlCommand(deleteInprimagailua, DBKonexioa.con))
                {
                    cmd.Parameters.AddWithValue("@idgailua", _gailua.Id);
                    cmd.ExecuteNonQuery();
                }

                string deleteGailua = "DELETE FROM GAILUA WHERE ID_GAILUA = @idgailua";
                using (MySqlCommand cmd = new MySqlCommand(deleteGailua, DBKonexioa.con))
                {
                    cmd.Parameters.AddWithValue("@idgailua", _gailua.Id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Inzidentzia behar bezala ezabatu da eta gailua ezabatutakoen zerrendara pasa da.", "Ondo",
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
