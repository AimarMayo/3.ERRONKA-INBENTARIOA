using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Erronka_Interfazak
{
    public partial class FMenua : Form
    {
        public FMenua()
        {
            InitializeComponent();
            this.Load += FMenua_Load;
        }

        // ── Bordes redondeados ────────────────────────────────────────────────

        private void FMenua_Load(object? sender, EventArgs e)
        {
            EzarriErtzBiribila(panPerfilFondo, 14);
            EzarriErtzBiribila(pictureBox1, 12);
            EzarriErtzBiribila(picargazkia, 10);
            //EzarriErtzBiribila(lblAvatar, 30); // zirkulua

            panPerfilFondo.Paint += (s, ev) =>
                MarraztuErtza(ev.Graphics, panPerfilFondo.Width, panPerfilFondo.Height, 14,
                              Color.FromArgb(120, 190, 255));

            pictureBox1.Paint += (s, ev) =>
                MarraztuErtza(ev.Graphics, pictureBox1.Width, pictureBox1.Height, 12,
                              Color.FromArgb(120, 190, 255));
        }

        private static void EzarriErtzBiribila(Control ctrl, int erradio)
        {
            int r = erradio * 2;
            var path = new GraphicsPath();
            path.AddArc(0, 0, r, r, 180, 90);
            path.AddArc(ctrl.Width - r, 0, r, r, 270, 90);
            path.AddArc(ctrl.Width - r, ctrl.Height - r, r, r, 0, 90);
            path.AddArc(0, ctrl.Height - r, r, r, 90, 90);
            path.CloseFigure();
            ctrl.Region = new Region(path);
        }

        private static void MarraztuErtza(Graphics g, int w, int h, int erradio, Color kolorea)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int r = erradio * 2;
            var path = new GraphicsPath();
            path.AddArc(1, 1, r, r, 180, 90);
            path.AddArc(w - r - 1, 1, r, r, 270, 90);
            path.AddArc(w - r - 1, h - r - 1, r, r, 0, 90);
            path.AddArc(1, h - r - 1, r, r, 90, 90);
            path.CloseFigure();
            using var pen = new Pen(kolorea, 1.5f);
            g.DrawPath(pen, path);
        }

        // ── Gertaerak ─────────────────────────────────────────────────────────

        private void aRAZOAToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void menstriMenua_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }

        private void lblerabiltzailepertsonala_Click(object sender, EventArgs e) { }

        private void irtenSarreraraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSarrera fsarrera = new FSarrera();
            fsarrera.Show();
            this.Close();
        }

        private void irtenInbentariotikToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aDMINISTRARIAToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void gehituToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FGehitu());
        }

        private void ikusiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FIkusi());
        }

        private void aldatuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FAldatu());
        }

        private void AbrirFormEnPanel(Form f)
        {
            panmenua.Controls.Clear();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panmenua.Controls.Add(f);
            f.Show();
        }
    }
}
