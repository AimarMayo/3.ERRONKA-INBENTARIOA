using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FAldatu : Form
    {
        private int _idGailua = -1;
        private bool _esOrdenagailua = false;

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
                DesGaituDena();
            };
        }

        private void DesGaituDena()
        {
            txtMarka.Enabled = false;
            txtKokalekua.Enabled = false;
            dtpErosteData.Enabled = false;
            rbOrdenagailua.Enabled = false;
            rbInprimagailua.Enabled = false;
            panOrdenagailua.Enabled = false;
            panInprimagailua.Enabled = false;
            butaldatu.Enabled = false;
            panOrdenagailua.Visible = false;
            panInprimagailua.Visible = false;
        }

        private void GaituDatuak()
        {
            txtMarka.Enabled = true;
            txtKokalekua.Enabled = true;
            dtpErosteData.Enabled = true;
            panOrdenagailua.Enabled = true;
            panInprimagailua.Enabled = true;
            butaldatu.Enabled = true;
        }

        private void ErdiratuKontrolak()
        {
            int w = panela.ClientSize.Width;
            int h = panela.ClientSize.Height;

            panDatuak.Left = (w - panDatuak.Width) / 2;
            panDatuak.Top = (h - panDatuak.Height) / 2;

            lblaldatu.Left = (w - lblaldatu.Width) / 2;
            lblaldatu.Top = panDatuak.Top - lblaldatu.Height - 20;
        }

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

                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                cmd.Parameters.AddWithValue("@id", id);
                using MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Ez da gailurik aurkitu ID horrekin.", "Abisua",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DesGaituDena();
                    _idGailua = -1;
                    return;
                }

                _idGailua = id;
                txtMarka.Text = reader["MARKA"].ToString();
                txtKokalekua.Text = reader["KOKALEKUA"].ToString();
                dtpErosteData.Value = Convert.ToDateTime(reader["EROSTEDATA"]);

                int ramOrdinal = reader.GetOrdinal("RAM");
                int koloretakoaOrdinal = reader.GetOrdinal("KOLORETAKOA");

                if (!reader.IsDBNull(ramOrdinal))
                {
                    _esOrdenagailua = true;
                    rbOrdenagailua.Checked = true;
                    panOrdenagailua.Visible = true;
                    panInprimagailua.Visible = false;
                    txtRam.Text = reader["RAM"].ToString();
                    txtRom.Text = reader["ROM"].ToString();
                    txtCpu.Text = reader["CPU"].ToString();
                }
                else if (!reader.IsDBNull(koloretakoaOrdinal))
                {
                    _esOrdenagailua = false;
                    rbInprimagailua.Checked = true;
                    panInprimagailua.Visible = true;
                    panOrdenagailua.Visible = false;
                    bool koloretakoa = Convert.ToBoolean(reader["KOLORETAKOA"]);
                    rbKoloretakuaBai.Checked = koloretakoa;
                    rbKoloretakuaEz.Checked = !koloretakoa;
                }

                GaituDatuak();
                // Radio buttons bloqueados: no puede cambiar el tipo de gailua
                rbOrdenagailua.Enabled = false;
                rbInprimagailua.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea bilaketean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butaldatu_Click(object sender, EventArgs e)
        {
            if (_idGailua == -1) return;

            if (string.IsNullOrWhiteSpace(txtMarka.Text) ||
                string.IsNullOrWhiteSpace(txtKokalekua.Text))
            {
                MessageBox.Show("Mesedez, bete eremu guztiak.", "Abisua",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_esOrdenagailua)
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

            try
            {
                DBKonexioa.konektatu();

                string updateGailua = @"UPDATE GAILUA
                                        SET MARKA = @marka, KOKALEKUA = @kokalekua, EROSTEDATA = @erostedata
                                        WHERE ID_GAILUA = @id";
                using (MySqlCommand cmd = new MySqlCommand(updateGailua, DBKonexioa.con))
                {
                    cmd.Parameters.AddWithValue("@marka", txtMarka.Text.Trim());
                    cmd.Parameters.AddWithValue("@kokalekua", txtKokalekua.Text.Trim());
                    cmd.Parameters.AddWithValue("@erostedata", dtpErosteData.Value.Date);
                    cmd.Parameters.AddWithValue("@id", _idGailua);
                    cmd.ExecuteNonQuery();
                }

                if (_esOrdenagailua)
                {
                    string updateOrdenagailua = @"UPDATE ORDENAGAILUA
                                                  SET RAM = @ram, ROM = @rom, CPU = @cpu
                                                  WHERE ID_GAILUA = @id";
                    using MySqlCommand cmd2 = new MySqlCommand(updateOrdenagailua, DBKonexioa.con);
                    cmd2.Parameters.AddWithValue("@ram", int.Parse(txtRam.Text.Trim()));
                    cmd2.Parameters.AddWithValue("@rom", int.Parse(txtRom.Text.Trim()));
                    cmd2.Parameters.AddWithValue("@cpu", txtCpu.Text.Trim());
                    cmd2.Parameters.AddWithValue("@id", _idGailua);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    string updateInprimagailua = @"UPDATE INPRIMAGAILUA
                                                   SET KOLORETAKOA = @koloretakoa
                                                   WHERE ID_GAILUA = @id";
                    using MySqlCommand cmd3 = new MySqlCommand(updateInprimagailua, DBKonexioa.con);
                    cmd3.Parameters.AddWithValue("@koloretakoa", rbKoloretakuaBai.Checked);
                    cmd3.Parameters.AddWithValue("@id", _idGailua);
                    cmd3.ExecuteNonQuery();
                }

                MessageBox.Show("Gailua behar bezala aldatu da!", "Ondo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtId.Clear();
                DesGaituDena();
                _idGailua = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea aldatzean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
    }
}
