namespace Erronka_Interfazak
{
    partial class FLangileaEzabatu
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
            lblizenburua = new Label();
            panDatuak = new Panel();
            lblid = new Label();
            txtid = new TextBox();
            butbilatu = new Button();
            butezabatu = new Button();
            butatzera = new Button();
            panEmaitza = new Panel();
            lblemaitza = new Label();
            panela.SuspendLayout();
            panDatuak.SuspendLayout();
            panEmaitza.SuspendLayout();
            SuspendLayout();
            //
            // panela
            //
            panela.BackColor = Color.White;
            panela.Controls.Add(lblizenburua);
            panela.Controls.Add(panDatuak);
            panela.Dock = DockStyle.Fill;
            panela.Location = new Point(0, 0);
            panela.Name = "panela";
            panela.Size = new Size(1317, 772);
            panela.TabIndex = 0;
            //
            // lblizenburua
            //
            lblizenburua.AutoSize = true;
            lblizenburua.BackColor = SystemColors.Highlight;
            lblizenburua.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblizenburua.ForeColor = Color.White;
            lblizenburua.Location = new Point(245, 50);
            lblizenburua.Name = "lblizenburua";
            lblizenburua.Size = new Size(340, 45);
            lblizenburua.TabIndex = 0;
            lblizenburua.Text = "LANGILEA EZABATU";
            //
            // panDatuak
            //
            panDatuak.BackColor = SystemColors.Highlight;
            panDatuak.Controls.Add(panEmaitza);
            panDatuak.Controls.Add(lblid);
            panDatuak.Controls.Add(txtid);
            panDatuak.Controls.Add(butbilatu);
            panDatuak.Controls.Add(butezabatu);
            panDatuak.Controls.Add(butatzera);
            panDatuak.Location = new Point(110, 112);
            panDatuak.Name = "panDatuak";
            panDatuak.Size = new Size(580, 270);
            panDatuak.TabIndex = 1;
            //
            // lblid
            //
            lblid.AutoSize = true;
            lblid.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblid.ForeColor = Color.Black;
            lblid.Location = new Point(20, 23);
            lblid.Name = "lblid";
            lblid.Size = new Size(34, 25);
            lblid.TabIndex = 0;
            lblid.Text = "ID:";
            //
            // txtid
            //
            txtid.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtid.Location = new Point(73, 20);
            txtid.Name = "txtid";
            txtid.Size = new Size(310, 31);
            txtid.TabIndex = 1;
            //
            // butbilatu
            //
            butbilatu.BackColor = Color.White;
            butbilatu.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butbilatu.ForeColor = SystemColors.Highlight;
            butbilatu.Location = new Point(400, 18);
            butbilatu.Name = "butbilatu";
            butbilatu.Size = new Size(155, 35);
            butbilatu.TabIndex = 2;
            butbilatu.Text = "BILATU";
            butbilatu.UseVisualStyleBackColor = false;
            butbilatu.Click += butbilatu_Click;
            //
            // butezabatu
            //
            butezabatu.BackColor = Color.White;
            butezabatu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butezabatu.ForeColor = SystemColors.Highlight;
            butezabatu.Location = new Point(20, 175);
            butezabatu.Name = "butezabatu";
            butezabatu.Size = new Size(250, 50);
            butezabatu.TabIndex = 4;
            butezabatu.Text = "EZABATU";
            butezabatu.UseVisualStyleBackColor = false;
            butezabatu.Click += butezabatu_Click;
            //
            // butatzera
            //
            butatzera.BackColor = Color.White;
            butatzera.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butatzera.ForeColor = SystemColors.Highlight;
            butatzera.Location = new Point(305, 175);
            butatzera.Name = "butatzera";
            butatzera.Size = new Size(250, 50);
            butatzera.TabIndex = 5;
            butatzera.Text = "ATZERA";
            butatzera.UseVisualStyleBackColor = false;
            butatzera.Click += butatzera_Click;
            //
            // panEmaitza
            //
            panEmaitza.BackColor = Color.White;
            panEmaitza.BorderStyle = BorderStyle.FixedSingle;
            panEmaitza.Controls.Add(lblemaitza);
            panEmaitza.Location = new Point(20, 89);
            panEmaitza.Name = "panEmaitza";
            panEmaitza.Size = new Size(535, 40);
            panEmaitza.TabIndex = 3;
            //
            // lblemaitza
            //
            lblemaitza.Dock = DockStyle.Fill;
            lblemaitza.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblemaitza.ForeColor = Color.Black;
            lblemaitza.Location = new Point(0, 0);
            lblemaitza.Name = "lblemaitza";
            lblemaitza.Size = new Size(533, 38);
            lblemaitza.TabIndex = 0;
            lblemaitza.TextAlign = ContentAlignment.MiddleCenter;
            //
            // FLangileaEzabatu
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1317, 772);
            Controls.Add(panela);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FLangileaEzabatu";
            Text = "FLangileaEzabatu";
            WindowState = FormWindowState.Maximized;
            panela.ResumeLayout(false);
            panela.PerformLayout();
            panDatuak.ResumeLayout(false);
            panDatuak.PerformLayout();
            panEmaitza.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panela;
        private Label lblizenburua;
        private Panel panDatuak;
        private Label lblid;
        private TextBox txtid;
        private Button butbilatu;
        private Button butezabatu;
        private Button butatzera;
        private Panel panEmaitza;
        private Label lblemaitza;
    }
}
