using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FKonponduta : Form
    {
        private Gailua? _gailua = null;

        public FKonponduta()
        {
            InitializeComponent();

            butbilatu.Click += butbilatu_Click;
            butkonpondu.Click += butkonpondu_Click;
            butatzera.Click += butatzera_Click;

            panela.Resize += (s, e) => ErdiratuKontrolak();
            this.Load += (s, e) =>
            {
                ErdiratuKontrolak();
                butkonpondu.Enabled = false;
            };
            panDatuak.Paint += panDatuak_Paint;
            panDatuak.Resize += (s, e) => AplikatuBiribilak();
        }

        private void ErdiratuKontrolak()
        {
            int w = panela.ClientSize.Width;
            int h = panela.ClientSize.Height;

            panDatuak.Left = (w - panDatuak.Width) / 2;
            panDatuak.Top = (h - panDatuak.Height) / 2;

            lblizenburua.Left = (w - lblizenburua.Width) / 2;
            lblizenburua.Top = panDatuak.Top - lblizenburua.Height - 20;

            AplikatuBiribilak();
            AplikatuLabelBiribilak();
        }

        private void butbilatu_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtid.Text.Trim(), out int id))
            {
                lblemaitza.Text = "Mesedez, sartu ID zenbaki bat.";
                lblemaitza.ForeColor = Color.Red;
                butkonpondu.Enabled = false;
                _gailua = null;
                return;
            }

            try
            {
                DBKonexioa.konektatu();

                string query = @"SELECT ID_GAILUA, MARKA, KOKALEKUA, EGOERA, EROSTEDATA
                                 FROM GAILUA WHERE ID_GAILUA = @id AND EGOERA = 'matxuratuta'";

                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                cmd.Parameters.AddWithValue("@id", id);
                using MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    lblemaitza.Text = "Ez da gailurik aurkitu ID horrekin edo ez dago matxuratuta.";
                    lblemaitza.ForeColor = Color.Red;
                    butkonpondu.Enabled = false;
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
                butkonpondu.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea bilaketean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butkonpondu_Click(object sender, EventArgs e)
        {
            if (_gailua == null) return;

            try
            {
                DBKonexioa.konektatu();

                string updateGailua = "UPDATE GAILUA SET EGOERA = 'erabilgarri' WHERE ID_GAILUA = @id";
                using (MySqlCommand cmd1 = new MySqlCommand(updateGailua, DBKonexioa.con))
                {
                    cmd1.Parameters.AddWithValue("@id", _gailua.Id);
                    cmd1.ExecuteNonQuery();
                }

                string updateInzidentzia = @"UPDATE INZIDENTZIAK SET KONPONTZE_DATA = @data
                                             WHERE ID_GAILUA = @idgailua AND KONPONTZE_DATA IS NULL";
                using (MySqlCommand cmd2 = new MySqlCommand(updateInzidentzia, DBKonexioa.con))
                {
                    cmd2.Parameters.AddWithValue("@data", DateTime.Now);
                    cmd2.Parameters.AddWithValue("@idgailua", _gailua.Id);
                    cmd2.ExecuteNonQuery();
                }

                MessageBox.Show($"'{_gailua.Marka}' gailua erabilgarri bezala markatu da.", "Ondo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtid.Clear();
                lblemaitza.Text = "";
                butkonpondu.Enabled = false;
                _gailua = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea gordetzean: " + ex.Message, "Errorea",
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

        private void AplikatuLabelBiribilak()
        {
            int r = 10;
            int w = lblizenburua.Width;
            int h = lblizenburua.Height;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, r, r, 180, 90);
            path.AddArc(w - r, 0, r, r, 270, 90);
            path.AddArc(w - r, h - r, r, r, 0, 90);
            path.AddArc(0, h - r, r, r, 90, 90);
            path.CloseAllFigures();
            lblizenburua.Region = new Region(path);
        }

        private void AplikatuBiribilak()
        {
            int r = 10;
            int w = panDatuak.Width;
            int h = panDatuak.Height;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, r, r, 180, 90);
            path.AddArc(w - r, 0, r, r, 270, 90);
            path.AddArc(w - r, h - r, r, r, 0, 90);
            path.AddArc(0, h - r, r, r, 90, 90);
            path.CloseAllFigures();
            panDatuak.Region = new Region(path);
        }

        private void panDatuak_Paint(object? sender, PaintEventArgs e)
        {
            int r = 10;
            int w = panDatuak.Width - 1;
            int h = panDatuak.Height - 1;
            using GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, r, r, 180, 90);
            path.AddArc(w - r, 0, r, r, 270, 90);
            path.AddArc(w - r, h - r, r, r, 0, 90);
            path.AddArc(0, h - r, r, r, 90, 90);
            path.CloseAllFigures();
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(new Pen(SystemColors.Highlight, 2), path);
        }
    }
}
