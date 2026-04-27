using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    /// <summary>
    /// Saioa hasteko formularioa. Erabiltzaileak emaila eta pasahitza sartuz sisteman sartzen dira.
    /// </summary>
    public partial class FSarrera : Form
    {
        /// <summary>
        /// FSarrera formularioa hasieratzen du eta pasahitz-eremua ezkutatzen du.
        /// </summary>
        public FSarrera()
        {
            InitializeComponent();
            txtpasahitza.PasswordChar = '*';
        }

        /// <summary>
        /// Sartu botoia sakatzean datu-basean egiaztapen egiten du eta baliozko saioan menuara igaro edo pasahitz-aldaketa eskatzen du.
        /// </summary>
        /// <param name="sender">Gertaeraren iturria.</param>
        /// <param name="e">Gertaeraren argumentuak.</param>
        private void butsartu_Click(object sender, EventArgs e)
        {
            Erabiltzailea erabiltzailea = new Erabiltzailea("", "", txtemaila.Text.Trim(), txtpasahitza.Text);

            if (string.IsNullOrEmpty(erabiltzailea.Emaila) || string.IsNullOrEmpty(erabiltzailea.Pasahitza))
            {
                MessageBox.Show("Mesedez, bete emaila eta pasahitza.", "Abisua",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DBKonexioa.konektatu();

                string query = "SELECT EMAILA, PASAHITZA, ROLA, ID_MINTEGIA FROM ERABILTZAILEA WHERE EMAILA = @emaila";
                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                cmd.Parameters.AddWithValue("@emaila", erabiltzailea.Emaila);
                using MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Emaila ez da existitzen.", "Errorea",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string dbPasahitza = reader["PASAHITZA"].ToString()!;

                if (erabiltzailea.Pasahitza != dbPasahitza)
                {
                    MessageBox.Show("Pasahitza ez da zuzena.", "Errorea",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Saioa.Emaila = erabiltzailea.Emaila;
                Saioa.Rola = reader["ROLA"].ToString()!.Trim();
                int mintegiaOrdinal = reader.GetOrdinal("ID_MINTEGIA");
                Saioa.MintegiaId = reader.IsDBNull(mintegiaOrdinal)
                    ? 0
                    : Convert.ToInt32(reader["ID_MINTEGIA"]);

                reader.Close();

                if (erabiltzailea.Pasahitza == "123")
                {
                    FPasahitza fPasahitza = new FPasahitza(erabiltzailea.Emaila);
                    fPasahitza.Show();
                }
                else
                {
                    FMenua fMenua = new FMenua();
                    fMenua.Show();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Konexio errorea: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Itxi botoia sakatzean aplikazioa ixten du.
        /// </summary>
        /// <param name="sender">Gertaeraren iturria.</param>
        /// <param name="e">Gertaeraren argumentuak.</param>
        private void butitxi_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
