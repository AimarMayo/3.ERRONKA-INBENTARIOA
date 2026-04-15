using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Erronka_Interfazak
{
    public partial class FPasahitza : Form
    {
        // Windows 11 DWM API: bordes redondeados en ventana sin borde
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, ref int pvAttribute, int cbAttribute);
        private const int DWMWA_WINDOW_CORNER_PREFERENCE = 33;
        private const int DWMWCP_ROUND = 2;

        public FPasahitza()
        {
            InitializeComponent();
        }

        private void FPasahitza_Load(object sender, EventArgs e)
        {
            // Esquinas redondeadas como FSarrera (Windows 11)
            int preference = DWMWCP_ROUND;
            DwmSetWindowAttribute(this.Handle, DWMWA_WINDOW_CORNER_PREFERENCE,
                ref preference, sizeof(int));
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblpasahitzaaldatu_Click(object sender, EventArgs e)
        {
        }

        private void butaldatu_Click(object sender, EventArgs e)
        {
            FMenua fmenua = new FMenua();
            fmenua.Show();
            this.Close();
        }
    }
}
