using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Erronka_Interfazak
{
    public partial class FMenua : Form
    {
        public FMenua()
        {
            InitializeComponent();
            this.Load += FMenua_Load;
        }

        private void EzarriRolEskubideak()
        {
            switch (Saioa.Rola)
            {
                case "Mintegiburua":
                    aDMINISTRARIAToolStripMenuItem.Enabled = false;
                    break;

                case "Irakaslea":
                    aRAZOAToolStripMenuItem.Enabled = false;
                    aDMINISTRARIAToolStripMenuItem.Enabled = false;
                    gehituToolStripMenuItem.Enabled = false;
                    aldatuToolStripMenuItem.Enabled = false;
                    ezabatuToolStripMenuItem.Enabled = false;
                    break;
            }
        }

        private void KargatuErabiltzaileaDatuak()
        {
            try
            {
                DBKonexioa.konektatu();

                string query = @"SELECT e.IZENA, e.ROLA, m.IZENA AS MINTEGIA_IZENA
                                 FROM ERABILTZAILEA e
                                 LEFT JOIN MINTEGIA m ON m.ID_MINTEGIA = e.ID_MINTEGIA
                                 WHERE e.EMAILA = @emaila";

                using MySqlCommand cmd = new MySqlCommand(query, DBKonexioa.con);
                cmd.Parameters.AddWithValue("@emaila", Saioa.Emaila);
                using MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblerabiltzailepertsonala.Text = reader["IZENA"].ToString();
                    lblpostuaerabiltzailea.Text = reader["ROLA"].ToString();
                    int mintegiaOrdinal = reader.GetOrdinal("MINTEGIA_IZENA");
                    lblmintegiaerabiltzailea.Text = reader.IsDBNull(mintegiaOrdinal)
                        ? ""
                        : reader["MINTEGIA_IZENA"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea datuak kargatzean: " + ex.Message, "Errorea",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Bordes redondeados ────────────────────────────────────────────────

        private void FMenua_Load(object? sender, EventArgs e)
        {
            KargatuErabiltzaileaDatuak();
            EzarriRolEskubideak();
            EzarriErtzBiribila(panPerfilFondo, 14);
            EzarriErtzBiribila(picAlboIrudia, 12);
            EzarriErtzBiribila(picargazkia, 10);
            //EzarriErtzBiribila(lblAvatar, 30); // zirkulua

            panPerfilFondo.Paint += (s, ev) =>
                MarraztuErtza(ev.Graphics, panPerfilFondo.Width, panPerfilFondo.Height, 14,
                              Color.FromArgb(120, 190, 255));

            picAlboIrudia.Paint += (s, ev) =>
                MarraztuErtza(ev.Graphics, picAlboIrudia.Width, picAlboIrudia.Height, 12,
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

        public void MostrarMenua()
        {
            panmenua.Controls.Clear();
            panmenua.Controls.Add(panbarralaterala);
            panmenua.Controls.Add(picFondoNagusia);
        }

        private void ezabatuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panmenua.Controls.Clear();
            FEzabatu f = new FEzabatu();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panmenua.Controls.Add(f);
            f.Show();
        }

        private void konponduToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panmenua.Controls.Clear();
            FKonpondu f = new FKonpondu();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panmenua.Controls.Add(f);
            f.Show();
        }

        private void konpondutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panmenua.Controls.Clear();
            FKonponduta f = new FKonponduta();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panmenua.Controls.Add(f);
            f.Show();
        }

        private void langileakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panmenua.Controls.Clear();
            FLangileaGehitu f = new FLangileaGehitu();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panmenua.Controls.Add(f);
            f.Show();
        }

        private void langileakKenduToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panmenua.Controls.Clear();
            FLangileaEzabatu f = new FLangileaEzabatu();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panmenua.Controls.Add(f);
            f.Show();
        }

        private void mintegiaGehituToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panmenua.Controls.Clear();
            FMintegiaGehitu f = new FMintegiaGehitu();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panmenua.Controls.Add(f);
            f.Show();
        }

        private void mintegiaKenduToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panmenua.Controls.Clear();
            FMintegiaEzabatu f = new FMintegiaEzabatu();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panmenua.Controls.Add(f);
            f.Show();
        }

        private void ikusiToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panmenua.Controls.Clear();
            FInzidentziak f = new FInzidentziak();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panmenua.Controls.Add(f);
            f.Show();
        }

        private void langileakGehituToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panmenua.Controls.Clear();
            FLangileakIkusi f = new FLangileakIkusi();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panmenua.Controls.Add(f);
            f.Show();
        }

        private void mintegiaGehituToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panmenua.Controls.Clear();
            FMintegiaIkusi f = new FMintegiaIkusi();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panmenua.Controls.Add(f);
            f.Show();
        }

        private void inzidentziaEzabatuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panmenua.Controls.Clear();
            FInzidentziaEzabatu f = new FInzidentziaEzabatu();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panmenua.Controls.Add(f);
            f.Show();
        }

        private void ezabatuakIkusiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panmenua.Controls.Clear();
            FEzabatuakIkusi f = new FEzabatuakIkusi();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panmenua.Controls.Add(f);
            f.Show();
        }

        private void langileaAldatuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panmenua.Controls.Clear();
            FLangileaAldatu f = new FLangileaAldatu();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panmenua.Controls.Add(f);
            f.Show();
        }
    }
}
