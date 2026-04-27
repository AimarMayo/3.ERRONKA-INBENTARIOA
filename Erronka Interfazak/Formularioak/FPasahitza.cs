using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    /// <summary>
    /// Pasahitza aldatzeko formularioa. Lehen saioan "123" pasahitz lehenetsia erabiltzen denean automatikoki irekitzen da.
    /// Gutxienez 8 karaktereko pasahitz berria eskatzen du.
    /// </summary>
    public partial class FPasahitza : Form
    {
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, ref int pvAttribute, int cbAttribute);
        private const int DWMWA_WINDOW_CORNER_PREFERENCE = 33;
        private const int DWMWCP_ROUND = 2;

        /// <summary>Pasahitza aldatu behar duen erabiltzailearen emaila.</summary>
        private readonly string emaila;

        /// <summary>
        /// FPasahitza formularioa hasieratzen du eta emaila gordetzen du.
        /// </summary>
        /// <param name="emaila">Pasahitza aldatu behar duen erabiltzailearen emaila.</param>
        public FPasahitza(string emaila)
        {
            InitializeComponent();
            this.emaila = emaila;
            txtPasahitzBerria.PasswordChar = '*';
        }

        /// <summary>
        /// Formularioa kargatzean leihoko ertzak biribilak ezartzen ditu DWM API bidez.
        /// </summary>
        /// <param name="sender">Gertaeraren iturria.</param>
        /// <param name="e">Gertaeraren argumentuak.</param>
        private void FPasahitza_Load(object sender, EventArgs e)
        {
            int preference = DWMWCP_ROUND;
            DwmSetWindowAttribute(this.Handle, DWMWA_WINDOW_CORNER_PREFERENCE,
                ref preference, sizeof(int));
        }

        /// <summary>
        /// Aldatu botoia sakatzean pasahitzaren luzera egiaztatzen du eta datu-basean eguneratzen du.
        /// Ondoren menu nagusia irekitzen du eta formularioa ixten du.
        /// </summary>
        /// <param name="sender">Gertaeraren iturria.</param>
        /// <param name="e">Gertaeraren argumentuak.</param>
        private void butaldatu_Click(object sender, EventArgs e)
        {
            Erabiltzailea erabiltzailea = new Erabiltzailea("", "", emaila, txtPasahitzBerria.Text);

            if (erabiltzailea.Pasahitza.Length < 8)
            {
                MessageBox.Show("Pasahitzak gutxienez 8 karaktere izan behar ditu.", "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DBKonexioa.konektatu();

                string query = "UPDATE ERABILTZAILEA SET PASAHITZA = @pasahitza WHERE EMAILA = @emaila";
                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                cmd.Parameters.AddWithValue("@pasahitza", erabiltzailea.Pasahitza);
                cmd.Parameters.AddWithValue("@emaila", erabiltzailea.Emaila);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Pasahitza behar bezala aldatu da.", "Ondo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                FMenua fMenua = new FMenua();
                fMenua.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
