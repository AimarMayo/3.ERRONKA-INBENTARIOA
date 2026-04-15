using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Erronka_Interfazak
{
    public partial class FGehitu : Form
    {
        // Win32: euskarako lokala ezarri DateTimePicker-ek euskarazko egutegia erakutsi dezan
        [DllImport("kernel32.dll")]
        private static extern bool SetThreadLocale(uint Locale);
        private const uint LCID_EUSKARA = 0x042D; // eu-ES

        public FGehitu()
        {
            // Win32 lokala euskarara aldatu ANTES de crear los controles
            SetThreadLocale(LCID_EUSKARA);

            // Kultura kudeatzailean ere ezarri (formatu testualerako)
            Thread.CurrentThread.CurrentCulture = new CultureInfo("eu-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("eu-ES");

            InitializeComponent();

            // Egutegian data luzea euskeraz erakutsi
            dtpErosteData.Format = DateTimePickerFormat.Short;

            // Panela erdian jarri karga eta tamaina aldaketan
            panela.Resize += (s, e) => ErdiratuKontrolak();
            this.Load += (s, e) => ErdiratuKontrolak();
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
            if (string.IsNullOrWhiteSpace(txtMarka.Text) ||
                string.IsNullOrWhiteSpace(txtKokalekua.Text) ||
                (!rbOrdenagailua.Checked && !rbInprimagailua.Checked))
            {
                MessageBox.Show("Mesedez, bete eremu guztiak.", "Abisua",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Gailua behar bezala gorde da!", "Ondo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gordeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            butsartu_Click(sender, e);
        }

        private void itzuliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panela_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
