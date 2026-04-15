using System;
using System.Windows.Forms;

namespace Erronka_Interfazak
{
    public partial class FAldatu : Form
    {
        public FAldatu()
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

            lblaldatu.Left = (w - lblaldatu.Width) / 2;
            lblaldatu.Top = panDatuak.Top - lblaldatu.Height - 20;
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
    }
}
