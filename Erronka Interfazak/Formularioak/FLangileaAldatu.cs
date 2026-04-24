using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FLangileaAldatu : Form
    {
        private int _idLangilea = -1;

        public FLangileaAldatu()
        {
            InitializeComponent();

            panela.Resize += (s, e) => ErdiratuKontrolak();
            this.Load += (s, e) =>
            {
                ErdiratuKontrolak();
                KargatuMintegiak();
                DesGaituEremuak();
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
                    cmbMintegia.Items.Add(new Mintegia(dr.GetInt32("ID_MINTEGIA"), dr.GetString("IZENA")));

                cmbMintegia.DisplayMember = "Izena";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ezin izan da mintegiak kargatu:\n{ex.Message}", "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DesGaituEremuak()
        {
            txtIzena.Enabled = false;
            txtEmaila.Enabled = false;
            cmbRola.Enabled = false;
            cmbMintegia.Enabled = false;
            butAldatu.Enabled = false;
        }

        private void GaituEremuak()
        {
            txtIzena.Enabled = true;
            txtEmaila.Enabled = true;
            cmbRola.Enabled = true;
            cmbMintegia.Enabled = true;
            butAldatu.Enabled = true;
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

                string query = "SELECT ID_ERABILTZAILEA, IZENA, EMAILA, ROLA, ID_MINTEGIA FROM ERABILTZAILEA WHERE ID_ERABILTZAILEA = @id";
                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                cmd.Parameters.AddWithValue("@id", id);
                using MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Ez da langilerik aurkitu ID horrekin.", "Abisua",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DesGaituEremuak();
                    _idLangilea = -1;
                    return;
                }

                _idLangilea = id;
                txtIzena.Text = reader["IZENA"].ToString();
                txtEmaila.Text = reader["EMAILA"].ToString();
                cmbRola.SelectedItem = reader["ROLA"].ToString()!.Trim();

                int mintegiaOrdinal = reader.GetOrdinal("ID_MINTEGIA");
                if (!reader.IsDBNull(mintegiaOrdinal))
                {
                    int idMintegia = Convert.ToInt32(reader["ID_MINTEGIA"]);
                    reader.Close();
                    foreach (object item in cmbMintegia.Items)
                    {
                        if (item is Mintegia m && m.Id == idMintegia)
                        {
                            cmbMintegia.SelectedItem = m;
                            break;
                        }
                    }
                }
                else
                {
                    reader.Close();
                    cmbMintegia.SelectedIndex = -1;
                }

                GaituEremuak();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea bilaketean:\n{ex.Message}", "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butAldatu_Click(object sender, EventArgs e)
        {
            if (_idLangilea == -1) return;

            if (string.IsNullOrWhiteSpace(txtIzena.Text) ||
                string.IsNullOrWhiteSpace(txtEmaila.Text) ||
                cmbRola.SelectedIndex == -1 ||
                cmbMintegia.SelectedIndex == -1)
            {
                MessageBox.Show("Mesedez, bete eremu guztiak.", "Abisua",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DBKonexioa.konektatu();

                string emailBerria = txtEmaila.Text.Trim();
                string queryBilatu = "SELECT COUNT(*) FROM ERABILTZAILEA WHERE LOWER(EMAILA) = LOWER(@emaila) AND ID_ERABILTZAILEA <> @id";
                using (MySqlCommand cmdBilatu = new MySqlCommand(queryBilatu, DBKonexioa.con))
                {
                    cmdBilatu.Parameters.AddWithValue("@emaila", emailBerria);
                    cmdBilatu.Parameters.AddWithValue("@id", _idLangilea);
                    int kopurua = Convert.ToInt32(cmdBilatu.ExecuteScalar());
                    if (kopurua > 0)
                    {
                        MessageBox.Show($"'{emailBerria}' emaila duen beste langile bat dagoeneko existitzen da.", "Abisua",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                Mintegia mintegia = (Mintegia)cmbMintegia.SelectedItem!;

                if (cmbRola.SelectedItem!.ToString() == "Mintegiburua")
                {
                    string queryMintegiburua = "SELECT COUNT(*) FROM ERABILTZAILEA WHERE ROLA = 'Mintegiburua' AND ID_MINTEGIA = @idmintegia AND ID_ERABILTZAILEA <> @id";
                    using MySqlCommand cmdMintegiburua = new MySqlCommand(queryMintegiburua, DBKonexioa.con);
                    cmdMintegiburua.Parameters.AddWithValue("@idmintegia", mintegia.Id);
                    cmdMintegiburua.Parameters.AddWithValue("@id", _idLangilea);
                    int kopurua = Convert.ToInt32(cmdMintegiburua.ExecuteScalar());
                    if (kopurua > 0)
                    {
                        MessageBox.Show($"'{mintegia.Izena}' mintegiak dagoeneko badu Mintegiburua bat.\nLehenik kendu edo aldatu orain daukan Mintegiburua.", "Abisua",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string query = @"UPDATE ERABILTZAILEA
                                 SET IZENA = @izena, EMAILA = @emaila, ROLA = @rola, ID_MINTEGIA = @idmintegia
                                 WHERE ID_ERABILTZAILEA = @id";
                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                cmd.Parameters.AddWithValue("@izena", txtIzena.Text.Trim());
                cmd.Parameters.AddWithValue("@emaila", emailBerria);
                cmd.Parameters.AddWithValue("@rola", cmbRola.SelectedItem!.ToString());
                cmd.Parameters.AddWithValue("@idmintegia", mintegia.Id);
                cmd.Parameters.AddWithValue("@id", _idLangilea);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Langilea behar bezala aldatu da!", "Ondo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtId.Clear();
                txtIzena.Clear();
                txtEmaila.Clear();
                cmbRola.SelectedIndex = -1;
                cmbMintegia.SelectedIndex = -1;
                DesGaituEremuak();
                _idLangilea = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea langilea aldatzean:\n{ex.Message}", "Errorea",
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
