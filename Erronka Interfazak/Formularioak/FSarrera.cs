using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FSarrera : Form
    {
        public FSarrera()
        {
            InitializeComponent();
            txtpasahitza.PasswordChar = '*';
        }

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

                string query = "SELECT EMAILA, PASAHITZA, ID_MINTEGIA FROM ERABILTZAILEA WHERE EMAILA = @emaila";
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

                Sesioa.Emaila = erabiltzailea.Emaila;
                int mintegiaOrdinal = reader.GetOrdinal("ID_MINTEGIA");
                Sesioa.MintegiaId = reader.IsDBNull(mintegiaOrdinal)
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

        private void FSarrera_Load(object sender, EventArgs e)
        {

        }
    }
}
