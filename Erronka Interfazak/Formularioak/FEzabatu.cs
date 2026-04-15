using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Erronka_Interfazak
{
    public partial class FEzabatu : Form
    {
        public FEzabatu()
        {
            InitializeComponent();

            panela.Resize += (s, e) => ErdiratuKontrolak();
            this.Load += (s, e) => ErdiratuKontrolak();
            panDatuak.Paint += panDatuak_Paint;
            panDatuak.Resize += (s, e) => AplikatuBiribilak();
        }

        private void ErdiratuKontrolak()
        {
            int w = panela.ClientSize.Width;
            int h = panela.ClientSize.Height;

            panDatuak.Left = (w - panDatuak.Width) / 2;
            panDatuak.Top = (h - panDatuak.Height) / 2;

            lblizenburua.Left = (w - lblizenburua.Width) / 2;
            lblizenburua.Top = panDatuak.Top - lblizenburua.Height - 20;

            AplikatuBiribilak();
            AplikatuLabelBiribilak();
        }

        private void AplikatuLabelBiribilak()
        {
            int r = 10;
            int w = lblizenburua.Width;
            int h = lblizenburua.Height;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, r, r, 180, 90);
            path.AddArc(w - r, 0, r, r, 270, 90);
            path.AddArc(w - r, h - r, r, r, 0, 90);
            path.AddArc(0, h - r, r, r, 90, 90);
            path.CloseAllFigures();
            lblizenburua.Region = new Region(path);
        }

        private void AplikatuBiribilak()
        {
            int r = 10;
            int w = panDatuak.Width;
            int h = panDatuak.Height;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, r, r, 180, 90);
            path.AddArc(w - r, 0, r, r, 270, 90);
            path.AddArc(w - r, h - r, r, r, 0, 90);
            path.AddArc(0, h - r, r, r, 90, 90);
            path.CloseAllFigures();
            panDatuak.Region = new Region(path);
        }

        private void panDatuak_Paint(object? sender, PaintEventArgs e)
        {
            int r = 10;
            int w = panDatuak.Width - 1;
            int h = panDatuak.Height - 1;
            using GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, r, r, 180, 90);
            path.AddArc(w - r, 0, r, r, 270, 90);
            path.AddArc(w - r, h - r, r, r, 0, 90);
            path.AddArc(0, h - r, r, r, 90, 90);
            path.CloseAllFigures();
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(new Pen(SystemColors.Highlight, 2), path);
        }

        private void lblemaitza_Click(object sender, EventArgs e)
        {

        }
    }
}
