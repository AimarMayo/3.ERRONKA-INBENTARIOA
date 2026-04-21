using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FLangileaGehitu : Form
    {

        public FLangileaGehitu()
        {
            InitializeComponent();

            panela.Resize += (s, e) => ErdiratuKontrolak();
            this.Load += (s, e) =>
            {
                ErdiratuKontrolak();
                KargatuMintegiak();
            };
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

        private void KargatuMintegiak()
        {
            try
            {
                DBKonexioa.konektatu();

                using MySqlCommand cmd = new MySqlCommand("SELECT IZENA FROM MINTEGIA ORDER BY IZENA", DBKonexioa.con);
                using MySqlDataReader dr = cmd.ExecuteReader();

                cmbMintegia.Items.Clear();
                while (dr.Read())
                {
                    Mintegia mintegia = new Mintegia(dr.GetString("IZENA"));
                    cmbMintegia.Items.Add(mintegia);
                }

                cmbMintegia.DisplayMember = "Izena";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ezin izan da mintegiak kargatu:\n{ex.Message}", "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butGehitu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIzena.Text) ||
                string.IsNullOrWhiteSpace(txtEmaila.Text) ||
                cmbRola.SelectedIndex == -1 ||
                cmbMintegia.SelectedIndex == -1)
            {
                MessageBox.Show("Mesedez, bete eremu guztiak.", "Abisua",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Langilea behar bezala gorde da!", "Ondo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void butAtzera_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is FMenua menu) { menu.MostrarMenua(); return; }
            }
        }

        private void panela_Paint(object sender, PaintEventArgs e)
        {
        }
    }

}
