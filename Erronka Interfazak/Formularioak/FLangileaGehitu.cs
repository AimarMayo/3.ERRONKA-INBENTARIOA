using System;
using System.Windows.Forms;
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

                using MySqlCommand cmd = new MySqlCommand(
                    "SELECT ID_MINTEGIA, IZENA FROM MINTEGIA ORDER BY IZENA", DBKonexioa.con);
                using MySqlDataReader dr = cmd.ExecuteReader();

                cmbMintegia.Items.Clear();
                while (dr.Read())
                {
                    int id = dr.GetInt32("ID_MINTEGIA");
                    string izena = dr.GetString("IZENA");
                    cmbMintegia.Items.Add(new Mintegia(id, izena));
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

            Mintegia mintegia = (Mintegia)cmbMintegia.SelectedItem!;
            Erabiltzailea erabiltzailea = new Erabiltzailea(
                txtIzena.Text.Trim(),
                cmbRola.SelectedItem!.ToString()!,
                txtEmaila.Text.Trim(),
                "123",
                mintegia);

            try
            {
                DBKonexioa.konektatu();

                string queryBilatu = "SELECT COUNT(*) FROM ERABILTZAILEA WHERE LOWER(EMAILA) = LOWER(@emaila)";
                using (MySqlCommand cmdBilatu = new MySqlCommand(queryBilatu, DBKonexioa.con))
                {
                    cmdBilatu.Parameters.AddWithValue("@emaila", erabiltzailea.Emaila);
                    int kopurua = Convert.ToInt32(cmdBilatu.ExecuteScalar());
                    if (kopurua > 0)
                    {
                        MessageBox.Show($"'{erabiltzailea.Emaila}' emaila duen langile bat dagoeneko existitzen da.", "Abisua",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (erabiltzailea.Rola == "Mintegiburua")
                {
                    string queryMintegiburua = "SELECT COUNT(*) FROM ERABILTZAILEA WHERE ROLA = 'Mintegiburua' AND ID_MINTEGIA = @idmintegia";
                    using MySqlCommand cmdMintegiburua = new MySqlCommand(queryMintegiburua, DBKonexioa.con);
                    cmdMintegiburua.Parameters.AddWithValue("@idmintegia", mintegia.Id);
                    int kopurua = Convert.ToInt32(cmdMintegiburua.ExecuteScalar());
                    if (kopurua > 0)
                    {
                        MessageBox.Show($"'{mintegia.Izena}' mintegiak dagoeneko badu Mintegiburua bat.\nLehenik kendu edo aldatu orain daukan Mintegiburua.", "Abisua",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string query = @"INSERT INTO ERABILTZAILEA (IZENA, EMAILA, ROLA, PASAHITZA, ID_MINTEGIA)
                                 VALUES (@izena, @emaila, @rola, @pasahitza, @idmintegia)";

                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                cmd.Parameters.AddWithValue("@izena", erabiltzailea.Izena);
                cmd.Parameters.AddWithValue("@emaila", erabiltzailea.Emaila);
                cmd.Parameters.AddWithValue("@rola", erabiltzailea.Rola);
                cmd.Parameters.AddWithValue("@pasahitza", erabiltzailea.Pasahitza);
                cmd.Parameters.AddWithValue("@idmintegia", erabiltzailea.Mintegia.Id);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Langilea behar bezala gorde da!", "Ondo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtIzena.Clear();
                txtEmaila.Clear();
                cmbRola.SelectedIndex = -1;
                cmbMintegia.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea langilea gordetzean:\n{ex.Message}", "Errorea",
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
