namespace Erronka_Interfazak
{
    partial class FLangileaAldatu : Form
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
            lblId = new Label();
            txtId = new TextBox();
            butBilatu = new Button();
            lblIzena = new Label();
            txtIzena = new TextBox();
            lblEmaila = new Label();
            txtEmaila = new TextBox();
            lblRola = new Label();
            cmbRola = new ComboBox();
            lblMintegia = new Label();
            cmbMintegia = new ComboBox();
            butAldatu = new Button();
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
            lblTitulua.Size = new Size(320, 45);
            lblTitulua.TabIndex = 0;
            lblTitulua.Text = "LANGILEA ALDATU";
            //
            // panDatuak
            //
            panDatuak.BackColor = SystemColors.Highlight;
            panDatuak.BorderStyle = BorderStyle.FixedSingle;
            panDatuak.Controls.Add(lblId);
            panDatuak.Controls.Add(txtId);
            panDatuak.Controls.Add(butBilatu);
            panDatuak.Controls.Add(lblIzena);
            panDatuak.Controls.Add(txtIzena);
            panDatuak.Controls.Add(lblEmaila);
            panDatuak.Controls.Add(txtEmaila);
            panDatuak.Controls.Add(lblRola);
            panDatuak.Controls.Add(cmbRola);
            panDatuak.Controls.Add(lblMintegia);
            panDatuak.Controls.Add(cmbMintegia);
            panDatuak.Controls.Add(butAldatu);
            panDatuak.Controls.Add(butAtzera);
            panDatuak.Location = new Point(110, 112);
            panDatuak.Name = "panDatuak";
            panDatuak.Size = new Size(500, 345);
            panDatuak.TabIndex = 1;
            //
            // lblId
            //
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblId.ForeColor = Color.Black;
            lblId.Location = new Point(20, 23);
            lblId.Name = "lblId";
            lblId.Size = new Size(34, 25);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            //
            // txtId
            //
            txtId.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtId.Location = new Point(160, 20);
            txtId.Name = "txtId";
            txtId.Size = new Size(200, 31);
            txtId.TabIndex = 1;
            //
            // butBilatu
            //
            butBilatu.BackColor = Color.White;
            butBilatu.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butBilatu.ForeColor = SystemColors.Highlight;
            butBilatu.Location = new Point(375, 18);
            butBilatu.Name = "butBilatu";
            butBilatu.Size = new Size(100, 35);
            butBilatu.TabIndex = 2;
            butBilatu.Text = "BILATU";
            butBilatu.UseVisualStyleBackColor = false;
            butBilatu.Click += butBilatu_Click;
            //
            // lblIzena
            //
            lblIzena.AutoSize = true;
            lblIzena.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIzena.ForeColor = Color.Black;
            lblIzena.Location = new Point(20, 68);
            lblIzena.Name = "lblIzena";
            lblIzena.Size = new Size(57, 25);
            lblIzena.TabIndex = 3;
            lblIzena.Text = "Izena:";
            //
            // txtIzena
            //
            txtIzena.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIzena.Location = new Point(160, 65);
            txtIzena.Name = "txtIzena";
            txtIzena.Size = new Size(310, 31);
            txtIzena.TabIndex = 4;
            //
            // lblEmaila
            //
            lblEmaila.AutoSize = true;
            lblEmaila.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmaila.ForeColor = Color.Black;
            lblEmaila.Location = new Point(20, 113);
            lblEmaila.Name = "lblEmaila";
            lblEmaila.Size = new Size(67, 25);
            lblEmaila.TabIndex = 5;
            lblEmaila.Text = "Emaila:";
            //
            // txtEmaila
            //
            txtEmaila.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmaila.Location = new Point(160, 110);
            txtEmaila.Name = "txtEmaila";
            txtEmaila.Size = new Size(310, 31);
            txtEmaila.TabIndex = 6;
            //
            // lblRola
            //
            lblRola.AutoSize = true;
            lblRola.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRola.ForeColor = Color.Black;
            lblRola.Location = new Point(20, 158);
            lblRola.Name = "lblRola";
            lblRola.Size = new Size(50, 25);
            lblRola.TabIndex = 7;
            lblRola.Text = "Rola:";
            //
            // cmbRola
            //
            cmbRola.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRola.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRola.Items.AddRange(new object[] { "Irakaslea", "Mintegiburua", "Administratzailea" });
            cmbRola.Location = new Point(160, 155);
            cmbRola.Name = "cmbRola";
            cmbRola.Size = new Size(310, 33);
            cmbRola.TabIndex = 8;
            //
            // lblMintegia
            //
            lblMintegia.AutoSize = true;
            lblMintegia.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMintegia.ForeColor = Color.Black;
            lblMintegia.Location = new Point(20, 203);
            lblMintegia.Name = "lblMintegia";
            lblMintegia.Size = new Size(80, 25);
            lblMintegia.TabIndex = 9;
            lblMintegia.Text = "Mintegia:";
            //
            // cmbMintegia
            //
            cmbMintegia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMintegia.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMintegia.Location = new Point(160, 200);
            cmbMintegia.Name = "cmbMintegia";
            cmbMintegia.Size = new Size(310, 33);
            cmbMintegia.TabIndex = 10;
            //
            // butAldatu
            //
            butAldatu.BackColor = Color.White;
            butAldatu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butAldatu.ForeColor = SystemColors.Highlight;
            butAldatu.Location = new Point(20, 270);
            butAldatu.Name = "butAldatu";
            butAldatu.Size = new Size(210, 50);
            butAldatu.TabIndex = 11;
            butAldatu.Text = "ALDATU";
            butAldatu.UseVisualStyleBackColor = false;
            butAldatu.Click += butAldatu_Click;
            //
            // butAtzera
            //
            butAtzera.BackColor = Color.White;
            butAtzera.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butAtzera.ForeColor = SystemColors.Highlight;
            butAtzera.Location = new Point(252, 270);
            butAtzera.Name = "butAtzera";
            butAtzera.Size = new Size(218, 50);
            butAtzera.TabIndex = 12;
            butAtzera.Text = "ATZERA";
            butAtzera.UseVisualStyleBackColor = false;
            butAtzera.Click += butAtzera_Click;
            //
            // FLangileaAldatu
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1317, 772);
            Controls.Add(panela);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FLangileaAldatu";
            Text = "FLangileaAldatu";
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
        private Label lblId;
        private TextBox txtId;
        private Button butBilatu;
        private Label lblIzena;
        private TextBox txtIzena;
        private Label lblEmaila;
        private TextBox txtEmaila;
        private Label lblRola;
        private ComboBox cmbRola;
        private Label lblMintegia;
        private ComboBox cmbMintegia;
        private Button butAldatu;
        private Button butAtzera;
    }
}
