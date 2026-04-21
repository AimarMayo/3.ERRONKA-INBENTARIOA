using System.Drawing.Drawing2D;
using MySqlConnector;

namespace Erronka_Interfazak
{
    public partial class FMintegiaEzabatu : Form
    {
        private const string ConnectionString =
            "Server=localhost;Database=erronka3;User ID=root;Password=;";

        private int? _mintegiaId = null;

        public FMintegiaEzabatu()
        {
            InitializeComponent();

            panela.Resize += (s, e) => ErdiratuKontrolak();
            this.Load += (s, e) => ErdiratuKontrolak();
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

        private void butbilatu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text) || !int.TryParse(txtid.Text, out int id))
            {
                lblemaitza.Text = "Mesedez, sartu ID zenbaki bat.";
                lblemaitza.ForeColor = Color.Red;
                _mintegiaId = null;
                return;
            }

            try
            {
                using MySqlConnection con = new MySqlConnection(ConnectionString);
                con.Open();

                using MySqlCommand cmd = new MySqlCommand(
                    "SELECT id, izena FROM mintegia WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);

                using MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    _mintegiaId = dr.GetInt32("id");
                    lblemaitza.Text = $"Mintegia: {dr.GetString("izena")}";
                    lblemaitza.ForeColor = Color.Black;
                }
                else
                {
                    lblemaitza.Text = "Ez da mintegiarik aurkitu ID horrekin.";
                    lblemaitza.ForeColor = Color.Red;
                    _mintegiaId = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea bilaketean:\n{ex.Message}", "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butezabatu_Click(object sender, EventArgs e)
        {
            if (_mintegiaId == null)
            {
                MessageBox.Show("Lehenik mintegia bilatu behar duzu.", "Abisua",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult erantzuna = MessageBox.Show(
                "Ziur zaude mintegia ezabatu nahi duzula?",
                "Berrespena",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (erantzuna != DialogResult.Yes) return;

            try
            {
                using MySqlConnection con = new MySqlConnection(ConnectionString);
                con.Open();

                using MySqlCommand cmd = new MySqlCommand(
                    "DELETE FROM mintegia WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", _mintegiaId.Value);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Mintegia behar bezala ezabatu da.", "Ondo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtid.Clear();
                lblemaitza.Text = string.Empty;
                _mintegiaId = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea mintegia ezabatzean:\n{ex.Message}", "Errorea",
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
