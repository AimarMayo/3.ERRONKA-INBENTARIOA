using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FGehitu : Form
    {
        [DllImport("kernel32.dll")]
        private static extern bool SetThreadLocale(uint Locale);
        private const uint LCID_EUSKARA = 0x042D;

        public FGehitu()
        {
            SetThreadLocale(LCID_EUSKARA);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("eu-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("eu-ES");

            InitializeComponent();

            dtpErosteData.Format = DateTimePickerFormat.Short;
            butsartu.Enabled = false;

            txtMarka.TextChanged          += (s, e) => EgiaztatuEremuak();
            txtKokalekua.TextChanged      += (s, e) => EgiaztatuEremuak();
            cmbMintegia.SelectedIndexChanged += (s, e) => EgiaztatuEremuak();
            rbOrdenagailua.CheckedChanged += (s, e) => EgiaztatuEremuak();
            rbInprimagailua.CheckedChanged += (s, e) => EgiaztatuEremuak();
            txtRam.TextChanged            += (s, e) => EgiaztatuEremuak();
            txtRom.TextChanged            += (s, e) => EgiaztatuEremuak();
            txtCpu.TextChanged            += (s, e) => EgiaztatuEremuak();
            rbKoloretakuaBai.CheckedChanged += (s, e) => EgiaztatuEremuak();
            rbKoloretakuaEz.CheckedChanged  += (s, e) => EgiaztatuEremuak();

            panela.Resize += (s, e) => ErdiratuKontrolak();
            this.Load += (s, e) =>
            {
                ErdiratuKontrolak();
                KargatuMintegia();
            };
        }

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
                else
                {
                    using MySqlCommand cmd = new MySqlCommand(
                        "SELECT IZENA FROM MINTEGIA WHERE ID_MINTEGIA = @idmintegia", DBKonexioa.con);
                    cmd.Parameters.AddWithValue("@idmintegia", Saioa.MintegiaId);
                    object? result = cmd.ExecuteScalar();
                    lblMintegiaBalio.Text = result?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea mintegia kargatzean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ErdiratuKontrolak()
        {
            int w = panela.ClientSize.Width;
            int h = panela.ClientSize.Height;

            panDatuak.Left = (w - panDatuak.Width) / 2;
            panDatuak.Top = (h - panDatuak.Height) / 2;

            lblsartu.Left = (w - lblsartu.Width) / 2;
            lblsartu.Top = panDatuak.Top - lblsartu.Height - 20;
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

        private void butsartu_Click(object sender, EventArgs e)
        {
            if (Saioa.Rola.Equals("Administratzailea", StringComparison.OrdinalIgnoreCase) && cmbMintegia.SelectedIndex == -1)
            {
                MessageBox.Show("Mesedez, hautatu mintegia.", "Abisua",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMarka.Text) ||
                string.IsNullOrWhiteSpace(txtKokalekua.Text) ||
                (!rbOrdenagailua.Checked && !rbInprimagailua.Checked))
            {
                MessageBox.Show("Mesedez, bete eremu guztiak.", "Abisua",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rbOrdenagailua.Checked)
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

            if (rbInprimagailua.Checked && !rbKoloretakuaBai.Checked && !rbKoloretakuaEz.Checked)
            {
                MessageBox.Show("Mesedez, hautatu inprimagailua koloretakoa den ala ez.", "Abisua",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DBKonexioa.konektatu();

                string insertGailua = @"INSERT INTO GAILUA (MARKA, KOKALEKUA, EROSTEDATA, EGOERA, ID_MINTEGIA)
                                        VALUES (@marka, @kokalekua, @erostedata, 'erabilgarri', @idmintegia);
                                        SELECT LAST_INSERT_ID();";

                long idGailua;
                using (MySqlCommand cmd = new MySqlCommand(insertGailua, DBKonexioa.con))
                {
                    cmd.Parameters.AddWithValue("@marka", txtMarka.Text.Trim());
                    cmd.Parameters.AddWithValue("@kokalekua", txtKokalekua.Text.Trim());
                    int idMintegia = Saioa.Rola.Equals("Administratzailea", StringComparison.OrdinalIgnoreCase)
                        ? ((Mintegia)cmbMintegia.SelectedItem!).Id
                        : Saioa.MintegiaId;
                    cmd.Parameters.AddWithValue("@erostedata", dtpErosteData.Value.Date);
                    cmd.Parameters.AddWithValue("@idmintegia", idMintegia);
                    idGailua = Convert.ToInt64(cmd.ExecuteScalar());
                }

                if (rbOrdenagailua.Checked)
                {
                    int ram = int.Parse(txtRam.Text.Trim());
                    int rom = int.Parse(txtRom.Text.Trim());
                    string cpu = txtCpu.Text.Trim();

                    Ordenagailua ordenagailua = new Ordenagailua(
                        txtMarka.Text.Trim(), txtKokalekua.Text.Trim(), "erabilgarri",
                        dtpErosteData.Value, ram, rom, cpu);

                    string insertOrdenagailua = @"INSERT INTO ORDENAGAILUA (ID_GAILUA, RAM, ROM, CPU)
                                                  VALUES (@idgailua, @ram, @rom, @cpu)";
                    using MySqlCommand cmd2 = new MySqlCommand(insertOrdenagailua, DBKonexioa.con);
                    cmd2.Parameters.AddWithValue("@idgailua", idGailua);
                    cmd2.Parameters.AddWithValue("@ram", ordenagailua.Ram);
                    cmd2.Parameters.AddWithValue("@rom", ordenagailua.Rom);
                    cmd2.Parameters.AddWithValue("@cpu", ordenagailua.Cpu);
                    cmd2.ExecuteNonQuery();
                }
                else if (rbInprimagailua.Checked)
                {
                    bool koloretakoa = rbKoloretakuaBai.Checked;

                    Inprimagailua inprimagailua = new Inprimagailua(
                        txtMarka.Text.Trim(), txtKokalekua.Text.Trim(), "erabilgarri",
                        dtpErosteData.Value, koloretakoa);

                    string insertInprimagailua = @"INSERT INTO INPRIMAGAILUA (ID_GAILUA, KOLORETAKOA)
                                                   VALUES (@idgailua, @koloretakoa)";
                    using MySqlCommand cmd3 = new MySqlCommand(insertInprimagailua, DBKonexioa.con);
                    cmd3.Parameters.AddWithValue("@idgailua", idGailua);
                    cmd3.Parameters.AddWithValue("@koloretakoa", inprimagailua.Koloretakoa);
                    cmd3.ExecuteNonQuery();
                }

                MessageBox.Show("Gailua behar bezala gorde da!", "Ondo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMarka.Clear();
                txtKokalekua.Clear();
                dtpErosteData.Value = DateTime.Today;
                rbOrdenagailua.Checked = false;
                rbInprimagailua.Checked = false;
                txtRam.Clear();
                txtRom.Clear();
                txtCpu.Clear();
                panOrdenagailua.Visible = false;
                panInprimagailua.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea gailua gordetzean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EgiaztatuEremuak()
        {
            bool oinarrizkoak = !string.IsNullOrWhiteSpace(txtMarka.Text) &&
                                !string.IsNullOrWhiteSpace(txtKokalekua.Text);

            bool mintegia = Saioa.Rola.Equals("Administratzailea", StringComparison.OrdinalIgnoreCase)
                ? cmbMintegia.SelectedIndex != -1
                : true;

            bool mota = rbOrdenagailua.Checked || rbInprimagailua.Checked;

            bool ordenagailuaDatuak = true;
            if (rbOrdenagailua.Checked)
                ordenagailuaDatuak = !string.IsNullOrWhiteSpace(txtRam.Text) &&
                                     !string.IsNullOrWhiteSpace(txtRom.Text) &&
                                     !string.IsNullOrWhiteSpace(txtCpu.Text) &&
                                     int.TryParse(txtRam.Text, out _) &&
                                     int.TryParse(txtRom.Text, out _);

            bool inprimagailuaDatuak = true;
            if (rbInprimagailua.Checked)
                inprimagailuaDatuak = rbKoloretakuaBai.Checked || rbKoloretakuaEz.Checked;

            butsartu.Enabled = oinarrizkoak && mintegia && mota && ordenagailuaDatuak && inprimagailuaDatuak;
        }

        private void butatzera_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is FMenua menu) { menu.MostrarMenua(); return; }
            }
        }

        private void gordeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            butsartu_Click(sender, e);
        }

        private void itzuliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panela_Paint(object sender, PaintEventArgs e) { }

        private void panDatuak_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
