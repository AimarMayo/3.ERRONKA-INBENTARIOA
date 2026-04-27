using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    /// <summary>
    /// Gailua ezabatzeko formularioa. ID bidez gailua bilatzen du, berrestea eskatzen du eta
    /// ezabatutakoen zerrendara mugitzen du.
    /// </summary>
    public partial class FEzabatu : Form
    {
        /// <summary>Uneko bilatutako gailua, ezabaketarako.</summary>
        private Gailua? _gailua = null;

        /// <summary>
        /// FEzabatu formularioa hasieratzen du eta gertaerak lotzen ditu.
        /// </summary>
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
        /// Bilatu botoia sakatzean ID bidez gailua datu-basetik bilatzen du eta emaitza erakusten du.
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
                _gailua = null;
                return;
            }

            try
            {
                DBKonexioa.konektatu();

                string query = @"SELECT g.ID_GAILUA, g.MARKA, g.KOKALEKUA, g.EGOERA, g.EROSTEDATA
                                 FROM GAILUA g
                                 WHERE g.ID_GAILUA = @id";
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
                        ? "ID horretako gailua ez da zure mintegiaren gailua."
                        : "Ez da gailurik aurkitu ID horrekin.";
                    lblemaitza.ForeColor = Color.Red;
                    butezabatu.Enabled = false;
                    _gailua = null;
                    return;
                }

                _gailua = new Gailua(
                    reader.GetInt32("ID_GAILUA"),
                    reader["MARKA"].ToString()!,
                    reader["KOKALEKUA"].ToString()!,
                    reader["EGOERA"].ToString()!,
                    Convert.ToDateTime(reader["EROSTEDATA"]));

                lblemaitza.Text = $"ID: {_gailua.Id}  |  {_gailua.Marka}  |  {_gailua.Kokalekua}  |  {_gailua.Egoera}";
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
        /// Ezabatu botoia sakatzean erabiltzaileari baieztapena eskatzen dio, gailua
        /// ezabatutakoen zerrendara mugitzen du eta datu-basetik ezabatzen du.
        /// </summary>
        /// <param name="sender">Gertaeraren iturria.</param>
        /// <param name="e">Gertaeraren argumentuak.</param>
        private void butezabatu_Click(object sender, EventArgs e)
        {
            if (_gailua == null) return;

            DialogResult erantzuna = Galdera.Galdetu(
                $"Ziur zaude {_gailua.Id} ID-ko gailua ezabatu nahi duzula?",
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
                                     WHERE g.ID_GAILUA = @id";
                string mota;
                using (MySqlCommand cmd = new MySqlCommand(queryMota, DBKonexioa.con))
                {
                    cmd.Parameters.AddWithValue("@id", _gailua.Id);
                    mota = cmd.ExecuteScalar()?.ToString() ?? "Gailua";
                }

                string moveGailua = @"INSERT INTO EZABATUTAKO_GAILUA (marka, kokalekua, mota, erostedata, ezabatze_data, id_erabiltzailea)
                                      VALUES (@marka, @kokalekua, @mota, @erostedata, @ezabatze_data, @id_erabiltzailea)";
                using (MySqlCommand cmdMove = new MySqlCommand(moveGailua, DBKonexioa.con))
                {
                    cmdMove.Parameters.AddWithValue("@marka", _gailua.Marka);
                    cmdMove.Parameters.AddWithValue("@kokalekua", _gailua.Kokalekua);
                    cmdMove.Parameters.AddWithValue("@mota", mota);
                    cmdMove.Parameters.AddWithValue("@erostedata", _gailua.ErosteData1);
                    cmdMove.Parameters.AddWithValue("@ezabatze_data", DateTime.Today);
                    cmdMove.Parameters.AddWithValue("@id_erabiltzailea", idErabiltzailea);
                    cmdMove.ExecuteNonQuery();
                }

                string deleteInzidentziak = "DELETE FROM INZIDENTZIAK WHERE ID_GAILUA = @id";
                using (MySqlCommand cmd0 = new MySqlCommand(deleteInzidentziak, DBKonexioa.con))
                {
                    cmd0.Parameters.AddWithValue("@id", _gailua.Id);
                    cmd0.ExecuteNonQuery();
                }

                string deleteOrdenagailua = "DELETE FROM ORDENAGAILUA WHERE ID_GAILUA = @id";
                using (MySqlCommand cmd1 = new MySqlCommand(deleteOrdenagailua, DBKonexioa.con))
                {
                    cmd1.Parameters.AddWithValue("@id", _gailua.Id);
                    cmd1.ExecuteNonQuery();
                }

                string deleteInprimagailua = "DELETE FROM INPRIMAGAILUA WHERE ID_GAILUA = @id";
                using (MySqlCommand cmd2 = new MySqlCommand(deleteInprimagailua, DBKonexioa.con))
                {
                    cmd2.Parameters.AddWithValue("@id", _gailua.Id);
                    cmd2.ExecuteNonQuery();
                }

                string deleteGailua = "DELETE FROM GAILUA WHERE ID_GAILUA = @id";
                using (MySqlCommand cmd3 = new MySqlCommand(deleteGailua, DBKonexioa.con))
                {
                    cmd3.Parameters.AddWithValue("@id", _gailua.Id);
                    cmd3.ExecuteNonQuery();
                }

                MessageBox.Show("Gailua behar bezala ezabatu da.", "Ondo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtid.Clear();
                lblemaitza.Text = "";
                butezabatu.Enabled = false;
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
