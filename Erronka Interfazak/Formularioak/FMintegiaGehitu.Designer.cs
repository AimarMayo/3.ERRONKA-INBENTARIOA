namespace Erronka_Interfazak
{
    partial class FMintegiaGehitu : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panela = new Panel();
            lblTitulua = new Label();
            panDatuak = new Panel();
            lblIzena = new Label();
            txtIzena = new TextBox();
            butGehitu = new Button();
            butAtzera = new Button();
            panela.SuspendLayout();
            panDatuak.SuspendLayout();
            SuspendLayout();
            //
            // panela
            //
            panela.BackColor = Color.White;
            panela.Controls.Add(lblTitulua);
            panela.Controls.Add(panDatuak);
            panela.Dock = DockStyle.Fill;
            panela.Location = new Point(0, 0);
            panela.Name = "panela";
            panela.Size = new Size(1317, 772);
            panela.TabIndex = 0;
            //
            // lblTitulua
            //
            lblTitulua.AutoSize = true;
            lblTitulua.BackColor = SystemColors.Highlight;
            lblTitulua.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulua.ForeColor = Color.White;
            lblTitulua.Location = new Point(245, 50);
            lblTitulua.Name = "lblTitulua";
            lblTitulua.Size = new Size(330, 45);
            lblTitulua.TabIndex = 0;
            lblTitulua.Text = "MINTEGIA GEHITU";
            //
            // panDatuak
            //
            panDatuak.BackColor = SystemColors.Highlight;
            panDatuak.BorderStyle = BorderStyle.FixedSingle;
            panDatuak.Controls.Add(lblIzena);
            panDatuak.Controls.Add(txtIzena);
            panDatuak.Controls.Add(butGehitu);
            panDatuak.Controls.Add(butAtzera);
            panDatuak.Location = new Point(110, 112);
            panDatuak.Name = "panDatuak";
            panDatuak.Size = new Size(500, 150);
            panDatuak.TabIndex = 1;
            //
            // lblIzena
            //
            lblIzena.AutoSize = true;
            lblIzena.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIzena.ForeColor = Color.Black;
            lblIzena.Location = new Point(20, 23);
            lblIzena.Name = "lblIzena";
            lblIzena.Size = new Size(57, 25);
            lblIzena.TabIndex = 0;
            lblIzena.Text = "Izena:";
            //
            // txtIzena
            //
            txtIzena.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIzena.Location = new Point(160, 20);
            txtIzena.Name = "txtIzena";
            txtIzena.Size = new Size(310, 31);
            txtIzena.TabIndex = 1;
            //
            // butGehitu
            //
            butGehitu.BackColor = Color.White;
            butGehitu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butGehitu.ForeColor = SystemColors.Highlight;
            butGehitu.Location = new Point(20, 80);
            butGehitu.Name = "butGehitu";
            butGehitu.Size = new Size(210, 50);
            butGehitu.TabIndex = 2;
            butGehitu.Text = "GEHITU";
            butGehitu.UseVisualStyleBackColor = false;
            butGehitu.Click += butGehitu_Click;
            //
            // butAtzera
            //
            butAtzera.BackColor = Color.White;
            butAtzera.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butAtzera.ForeColor = SystemColors.Highlight;
            butAtzera.Location = new Point(252, 80);
            butAtzera.Name = "butAtzera";
            butAtzera.Size = new Size(218, 50);
            butAtzera.TabIndex = 3;
            butAtzera.Text = "ATZERA";
            butAtzera.UseVisualStyleBackColor = false;
            butAtzera.Click += butAtzera_Click;
            //
            // FMintegiaGehitu
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1317, 772);
            Controls.Add(panela);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FMintegiaGehitu";
            Text = "FMintegiaGehitu";
            WindowState = FormWindowState.Maximized;
            panela.ResumeLayout(false);
            panela.PerformLayout();
            panDatuak.ResumeLayout(false);
            panDatuak.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panela;
        private Label lblTitulua;
        private Panel panDatuak;
        private Label lblIzena;
        private TextBox txtIzena;
        private Button butGehitu;
        private Button butAtzera;
    }
}
