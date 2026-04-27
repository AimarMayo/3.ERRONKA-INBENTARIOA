using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    /// <summary>
    /// Gailua aldatzeko formularioa. ID bidez gailua bilatzen du eta bere datuak eguneratzeko aukera ematen du.
    /// </summary>
    public partial class FAldatu : Form
    {
        /// <summary>Uneko bilatutako gailua, aldaketarako.</summary>
        private Gailua? _gailua = null;

        /// <summary>Bilatutako gailuaren mintegiaren identifikatzailea.</summary>
        private int _idMintegia = 0;

        /// <summary>
        /// FAldatu formularioa hasieratzen du, gertaerak lotzen ditu eta formularioa kargatzen du.
        /// </summary>
        public FAldatu()
        {
            InitializeComponent();

            butBilatu.Click += butBilatu_Click;
            butaldatu.Click += butaldatu_Click;
            butatzera.Click += butatzera_Click;

            panela.Resize += (s, e) => ErdiratuKontrolak();
            this.Load += (s, e) =>
            {
                ErdiratuKontrolak();
                KargatuMintegia();
                DesGaituDena();
            };
        }

        /// <summary>
        /// Mintegien zerrenda kargatzen du rolaren arabera: administratzaileak combo-box bat ikusten du,
        /// mintegiburuak bere mintegiaren izena soilik, eta irakasleak ezer ez.
        /// </summary>
        private void KargatuMintegia()
        {
            try
            {
                DBKonexioa.konektatu();

                if (Saioa.Rola.Equals("Administratzailea", StringComparison.OrdinalIgnoreCase))
                {
                    lblMintegiaBalio.Visible = false;
                    cmbMintegia.Visible = true;

                    using MySqlCommand cmd = new MySqlCommand(
                        "SELECT ID_MINTEGIA, IZENA FROM MINTEGIA ORDER BY IZENA", DBKonexioa.con);
                    using MySqlDataReader dr = cmd.ExecuteReader();
                    cmbMintegia.Items.Clear();
                    while (dr.Read())
                        cmbMintegia.Items.Add(new Mintegia(dr.GetInt32("ID_MINTEGIA"), dr.GetString("IZENA")));
                    cmbMintegia.DisplayMember = "Izena";
                }
                else if (Saioa.Rola.Equals("Mintegiburua", StringComparison.OrdinalIgnoreCase))
                {
                    cmbMintegia.Visible = false;
                    lblMintegiaBalio.Visible = true;

                    using MySqlCommand cmd = new MySqlCommand(
                        "SELECT IZENA FROM MINTEGIA WHERE ID_MINTEGIA = @idmintegia", DBKonexioa.con);
                    cmd.Parameters.AddWithValue("@idmintegia", Saioa.MintegiaId);
                    object? result = cmd.ExecuteScalar();
                    lblMintegiaBalio.Text = result?.ToString() ?? "";
                }
                else
                {
                    lblMintegia.Visible = false;
                    lblMintegiaBalio.Visible = false;
                    cmbMintegia.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea mintegia kargatzean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Aldaketa-eremu guztiak desgaitzen ditu bilaketa bat egin arte.
        /// </summary>
        private void DesGaituDena()
        {
            txtMarka.Enabled = false;
            txtKokalekua.Enabled = false;
            dtpErosteData.Enabled = false;
            rbOrdenagailua.Enabled = false;
            rbInprimagailua.Enabled = false;
            panOrdenagailua.Enabled = false;
            panInprimagailua.Enabled = false;
            cmbMintegia.Enabled = false;
            butaldatu.Enabled = false;
            panOrdenagailua.Visible = false;
            panInprimagailua.Visible = false;
        }

        /// <summary>
        /// Gailua aurkitu ondoren aldaketa-eremuak gaitzen ditu.
        /// </summary>
        private void GaituDatuak()
        {
            txtMarka.Enabled = true;
            txtKokalekua.Enabled = true;
            dtpErosteData.Enabled = true;
            panOrdenagailua.Enabled = true;
            panInprimagailua.Enabled = true;
            if (Saioa.Rola.Equals("Administratzailea", StringComparison.OrdinalIgnoreCase))
                cmbMintegia.Enabled = true;
            butaldatu.Enabled = true;
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

            lblaldatu.Left = (w - lblaldatu.Width) / 2;
            lblaldatu.Top = panDatuak.Top - lblaldatu.Height - 20;
        }

        /// <summary>
        /// Bilatu botoia sakatzean ID bidez gailua datu-basetik bilatu eta formularioan kargatzen du.
        /// </summary>
        /// <param name="sender">Gertaeraren iturria.</param>
        /// <param name="e">Gertaeraren argumentuak.</param>
        private void butBilatu_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text.Trim(), out int id))
            {
                MessageBox.Show("Mesedez, sartu ID zenbaki bat.", "Abisua",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DBKonexioa.konektatu();

                string query = @"SELECT g.*, o.RAM, o.ROM, o.CPU, i.KOLORETAKOA
                                 FROM GAILUA g
                                 LEFT JOIN ORDENAGAILUA o ON o.ID_GAILUA = g.ID_GAILUA
                                 LEFT JOIN INPRIMAGAILUA i ON i.ID_GAILUA = g.ID_GAILUA
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
                    MessageBox.Show("Ez da gailurik aurkitu ID horrekin.", "Abisua",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DesGaituDena();
                    _gailua = null;
                    return;
                }

                string marka = reader["MARKA"].ToString()!;
                string kokalekua = reader["KOKALEKUA"].ToString()!;
                string egoera = reader["EGOERA"].ToString()!;
                DateTime erosteData = Convert.ToDateTime(reader["EROSTEDATA"]);

                int mintegiaOrdinal = reader.GetOrdinal("ID_MINTEGIA");
                _idMintegia = reader.IsDBNull(mintegiaOrdinal) ? 0 : Convert.ToInt32(reader["ID_MINTEGIA"]);

                int ramOrdinal = reader.GetOrdinal("RAM");
                int koloretakoaOrdinal = reader.GetOrdinal("KOLORETAKOA");

                if (!reader.IsDBNull(ramOrdinal))
                {
                    _gailua = new Ordenagailua(
                        marka, kokalekua, egoera, erosteData,
                        Convert.ToInt32(reader["RAM"]),
                        Convert.ToInt32(reader["ROM"]),
                        reader["CPU"].ToString()!);
                    _gailua.Id = id;

                    Ordenagailua ord = (Ordenagailua)_gailua;
                    rbOrdenagailua.Checked = true;
                    panOrdenagailua.Visible = true;
                    panInprimagailua.Visible = false;
                    txtRam.Text = ord.Ram.ToString();
                    txtRom.Text = ord.Rom.ToString();
                    txtCpu.Text = ord.Cpu;
                }
                else if (!reader.IsDBNull(koloretakoaOrdinal))
                {
                    _gailua = new Inprimagailua(
                        marka, kokalekua, egoera, erosteData,
                        Convert.ToBoolean(reader["KOLORETAKOA"]));
                    _gailua.Id = id;

                    Inprimagailua inp = (Inprimagailua)_gailua;
                    rbInprimagailua.Checked = true;
                    panInprimagailua.Visible = true;
                    panOrdenagailua.Visible = false;
                    rbKoloretakuaBai.Checked = inp.Koloretakoa;
                    rbKoloretakuaEz.Checked = !inp.Koloretakoa;
                }
                else
                {
                    _gailua = new Gailua(id, marka, kokalekua, egoera, erosteData);
                }

                txtMarka.Text = _gailua.Marka;
                txtKokalekua.Text = _gailua.Kokalekua;
                dtpErosteData.Value = _gailua.ErosteData1;

                if (Saioa.Rola.Equals("Administratzailea", StringComparison.OrdinalIgnoreCase))
                {
                    foreach (object item in cmbMintegia.Items)
                    {
                        if (item is Mintegia m && m.Id == _idMintegia)
                        {
                            cmbMintegia.SelectedItem = m;
                            break;
                        }
                    }
                }

                GaituDatuak();
                rbOrdenagailua.Enabled = false;
                rbInprimagailua.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea bilaketean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Aldatu botoia sakatzean eremuak baliozkotzen ditu eta gailuaren datuak datu-basean eguneratzen ditu.
        /// </summary>
        /// <param name="sender">Gertaeraren iturria.</param>
        /// <param name="e">Gertaeraren argumentuak.</param>
        private void butaldatu_Click(object sender, EventArgs e)
        {
            if (_gailua == null) return;

            if (string.IsNullOrWhiteSpace(txtMarka.Text) ||
                string.IsNullOrWhiteSpace(txtKokalekua.Text))
            {
                MessageBox.Show("Mesedez, bete eremu guztiak.", "Abisua",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_gailua is Ordenagailua)
            {
                if (string.IsNullOrWhiteSpace(txtRam.Text) ||
                    string.IsNullOrWhiteSpace(txtRom.Text) ||
                    string.IsNullOrWhiteSpace(txtCpu.Text))
                {
                    MessageBox.Show("Mesedez, bete ordenagailuaren datuak (RAM, ROM, CPU).", "Abisua",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(txtRam.Text, out _) || !int.TryParse(txtRom.Text, out _))
                {
                    MessageBox.Show("RAM eta ROM zenbakiak izan behar dira.", "Abisua",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (Saioa.Rola.Equals("Administratzailea", StringComparison.OrdinalIgnoreCase) &&
                cmbMintegia.SelectedIndex == -1)
            {
                MessageBox.Show("Mesedez, hautatu mintegia.", "Abisua",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _gailua.Marka = txtMarka.Text.Trim();
            _gailua.Kokalekua = txtKokalekua.Text.Trim();
            _gailua.ErosteData1 = dtpErosteData.Value.Date;

            if (_gailua is Ordenagailua ord)
            {
                ord.Ram = int.Parse(txtRam.Text.Trim());
                ord.Rom = int.Parse(txtRom.Text.Trim());
                ord.Cpu = txtCpu.Text.Trim();
            }
            else if (_gailua is Inprimagailua inp)
            {
                inp.Koloretakoa = rbKoloretakuaBai.Checked;
            }

            int idMintegia = Saioa.Rola.Equals("Administratzailea", StringComparison.OrdinalIgnoreCase)
                ? ((Mintegia)cmbMintegia.SelectedItem!).Id
                : Saioa.Rola.Equals("Mintegiburua", StringComparison.OrdinalIgnoreCase)
                    ? Saioa.MintegiaId
                    : _idMintegia;

            try
            {
                DBKonexioa.konektatu();

                string updateGailua = @"UPDATE GAILUA
                                        SET MARKA = @marka, KOKALEKUA = @kokalekua, EROSTEDATA = @erostedata, ID_MINTEGIA = @idmintegia
                                        WHERE ID_GAILUA = @id";
                using (MySqlCommand cmd = new MySqlCommand(updateGailua, DBKonexioa.con))
                {
                    cmd.Parameters.AddWithValue("@marka", _gailua.Marka);
                    cmd.Parameters.AddWithValue("@kokalekua", _gailua.Kokalekua);
                    cmd.Parameters.AddWithValue("@erostedata", _gailua.ErosteData1);
                    cmd.Parameters.AddWithValue("@idmintegia", idMintegia);
                    cmd.Parameters.AddWithValue("@id", _gailua.Id);
                    cmd.ExecuteNonQuery();
                }

                if (_gailua is Ordenagailua o)
                {
                    string updateOrdenagailua = @"UPDATE ORDENAGAILUA
                                                  SET RAM = @ram, ROM = @rom, CPU = @cpu
                                                  WHERE ID_GAILUA = @id";
                    using MySqlCommand cmd2 = new MySqlCommand(updateOrdenagailua, DBKonexioa.con);
                    cmd2.Parameters.AddWithValue("@ram", o.Ram);
                    cmd2.Parameters.AddWithValue("@rom", o.Rom);
                    cmd2.Parameters.AddWithValue("@cpu", o.Cpu);
                    cmd2.Parameters.AddWithValue("@id", _gailua.Id);
                    cmd2.ExecuteNonQuery();
                }
                else if (_gailua is Inprimagailua i)
                {
                    string updateInprimagailua = @"UPDATE INPRIMAGAILUA
                                                   SET KOLORETAKOA = @koloretakoa
                                                   WHERE ID_GAILUA = @id";
                    using MySqlCommand cmd3 = new MySqlCommand(updateInprimagailua, DBKonexioa.con);
                    cmd3.Parameters.AddWithValue("@koloretakoa", i.Koloretakoa);
                    cmd3.Parameters.AddWithValue("@id", _gailua.Id);
                    cmd3.ExecuteNonQuery();
                }

                MessageBox.Show("Gailua behar bezala aldatu da!", "Ondo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtId.Clear();
                DesGaituDena();
                _gailua = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea aldatzean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Atzera botoia sakatzean formularioa ixten du.
        /// </summary>
        /// <param name="sender">Gertaeraren iturria.</param>
        /// <param name="e">Gertaeraren argumentuak.</param>
        private void butatzera_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbOrdenagailua_CheckedChanged(object sender, EventArgs e)
        {
            panOrdenagailua.Visible = rbOrdenagailua.Checked;
            panInprimagailua.Visible = false;
        }

        private void rbInprimagailua_CheckedChanged(object sender, EventArgs e)
        {
            panInprimagailua.Visible = rbInprimagailua.Checked;
            panOrdenagailua.Visible = false;
        }

        private void butatzera_Click_1(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is FMenua menu) { menu.MostrarMenua(); return; }
            }
        }

        private void butaldatu_Click_1(object sender, EventArgs e)
        {

        }
    }
}
