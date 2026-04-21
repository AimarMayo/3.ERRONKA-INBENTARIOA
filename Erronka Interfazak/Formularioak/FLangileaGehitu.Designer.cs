namespace Erronka_Interfazak
{
    partial class FLangileaGehitu : Form
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
            lblEmaila = new Label();
            txtEmaila = new TextBox();
            lblRola = new Label();
            cmbRola = new ComboBox();
            lblMintegia = new Label();
            cmbMintegia = new ComboBox();
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
            panela.Paint += panela_Paint;
            // 
            // lblTitulua
            // 
            lblTitulua.AutoSize = true;
            lblTitulua.BackColor = SystemColors.Highlight;
            lblTitulua.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulua.ForeColor = Color.White;
            lblTitulua.Location = new Point(245, 50);
            lblTitulua.Name = "lblTitulua";
            lblTitulua.Size = new Size(306, 45);
            lblTitulua.TabIndex = 0;
            lblTitulua.Text = "LANGILEA GEHITU";
            // 
            // panDatuak
            // 
            panDatuak.BackColor = SystemColors.Highlight;
            panDatuak.BorderStyle = BorderStyle.FixedSingle;
            panDatuak.Controls.Add(lblIzena);
            panDatuak.Controls.Add(txtIzena);
            panDatuak.Controls.Add(lblEmaila);
            panDatuak.Controls.Add(txtEmaila);
            panDatuak.Controls.Add(lblRola);
            panDatuak.Controls.Add(cmbRola);
            panDatuak.Controls.Add(lblMintegia);
            panDatuak.Controls.Add(cmbMintegia);
            panDatuak.Controls.Add(butGehitu);
            panDatuak.Controls.Add(butAtzera);
            panDatuak.Location = new Point(110, 112);
            panDatuak.Name = "panDatuak";
            panDatuak.Size = new Size(500, 300);
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
            // lblEmaila
            // 
            lblEmaila.AutoSize = true;
            lblEmaila.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmaila.ForeColor = Color.Black;
            lblEmaila.Location = new Point(20, 68);
            lblEmaila.Name = "lblEmaila";
            lblEmaila.Size = new Size(67, 25);
            lblEmaila.TabIndex = 2;
            lblEmaila.Text = "Emaila:";
            // 
            // txtEmaila
            // 
            txtEmaila.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmaila.Location = new Point(160, 65);
            txtEmaila.Name = "txtEmaila";
            txtEmaila.Size = new Size(310, 31);
            txtEmaila.TabIndex = 3;
            // 
            // lblRola
            // 
            lblRola.AutoSize = true;
            lblRola.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRola.ForeColor = Color.Black;
            lblRola.Location = new Point(20, 113);
            lblRola.Name = "lblRola";
            lblRola.Size = new Size(50, 25);
            lblRola.TabIndex = 4;
            lblRola.Text = "Rola:";
            // 
            // cmbRola
            // 
            cmbRola.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRola.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRola.Items.AddRange(new object[] { "Irakaslea", "Mintegiburua", "Administratzailea" });
            cmbRola.Location = new Point(160, 110);
            cmbRola.Name = "cmbRola";
            cmbRola.Size = new Size(310, 33);
            cmbRola.TabIndex = 5;
            //
            // lblMintegia
            //
            lblMintegia.AutoSize = true;
            lblMintegia.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMintegia.ForeColor = Color.Black;
            lblMintegia.Location = new Point(20, 158);
            lblMintegia.Name = "lblMintegia";
            lblMintegia.Size = new Size(80, 25);
            lblMintegia.TabIndex = 6;
            lblMintegia.Text = "Mintegia:";
            //
            // cmbMintegia
            //
            cmbMintegia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMintegia.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMintegia.Location = new Point(160, 155);
            cmbMintegia.Name = "cmbMintegia";
            cmbMintegia.Size = new Size(310, 33);
            cmbMintegia.TabIndex = 7;
            //
            // butGehitu
            //
            butGehitu.BackColor = Color.White;
            butGehitu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butGehitu.ForeColor = SystemColors.Highlight;
            butGehitu.Location = new Point(20, 225);
            butGehitu.Name = "butGehitu";
            butGehitu.Size = new Size(210, 50);
            butGehitu.TabIndex = 8;
            butGehitu.Text = "GEHITU";
            butGehitu.UseVisualStyleBackColor = false;
            butGehitu.Click += butGehitu_Click;
            //
            // butAtzera
            //
            butAtzera.BackColor = Color.White;
            butAtzera.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butAtzera.ForeColor = SystemColors.Highlight;
            butAtzera.Location = new Point(252, 225);
            butAtzera.Name = "butAtzera";
            butAtzera.Size = new Size(218, 50);
            butAtzera.TabIndex = 9;
            butAtzera.Text = "ATZERA";
            butAtzera.UseVisualStyleBackColor = false;
            butAtzera.Click += butAtzera_Click;
            // 
            // FLangileaGehitu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1317, 772);
            Controls.Add(panela);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FLangileaGehitu";
            Text = "FLangileaGehitu";
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
        private Label lblEmaila;
        private TextBox txtEmaila;
        private Label lblRola;
        private ComboBox cmbRola;
        private Label lblMintegia;
        private ComboBox cmbMintegia;
        private Button butGehitu;
        private Button butAtzera;
    }
}
