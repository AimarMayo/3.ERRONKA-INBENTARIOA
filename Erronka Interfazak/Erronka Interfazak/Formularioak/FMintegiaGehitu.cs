using MySqlConnector;

namespace Erronka_Interfazak
{
    public partial class FMintegiaGehitu : Form
    {
        private const string ConnectionString =
            "Server=localhost;Database=erronka3;User ID=root;Password=;";

        public FMintegiaGehitu()
        {
            InitializeComponent();

            panela.Resize += (s, e) => ErdiratuKontrolak();
            this.Load += (s, e) => ErdiratuKontrolak();
        }

        private void ErdiratuKontrolak()
        {
            int w = panela.ClientSize.Width;
            int h = panela.ClientSize.Height;

            panDatuak.Left = (w - panDatuak.Width) / 2;
            panDatuak.Top = (h - panDatuak.Height) / 2;

            lblTitulua.Left = (w - lblTitulua.Width) / 2;
            lblTitulua.Top = panDatuak.Top - lblTitulua.Height - 20;
        }

        private void butGehitu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIzena.Text))
            {
                MessageBox.Show("Mesedez, sartu mintegiaren izena.", "Abisua",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using MySqlConnection con = new MySqlConnection(ConnectionString);
                con.Open();

                using MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO mintegia (izena) VALUES (@izena)", con);
                cmd.Parameters.AddWithValue("@izena", txtIzena.Text.Trim());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Mintegia behar bezala gorde da!", "Ondo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtIzena.Clear();
                txtIzena.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea mintegia gordetzean:\n{ex.Message}", "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butAtzera_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is FMenua menu) { menu.MostrarMenua(); return; }
            }
        }
    }
}
