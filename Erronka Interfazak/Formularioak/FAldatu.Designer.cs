namespace Erronka_Interfazak
{
    partial class FAldatu
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
            lblaldatu = new Label();
            panDatuak = new Panel();
            lblId = new Label();
            txtId = new TextBox();
            butBilatu = new Button();
            lblMarka = new Label();
            txtMarka = new TextBox();
            lblKokalekua = new Label();
            txtKokalekua = new TextBox();
            lblErosteData = new Label();
            dtpErosteData = new DateTimePicker();
            lblMintegia = new Label();
            lblMintegiaBalio = new Label();
            cmbMintegia = new ComboBox();
            lblGailuMota = new Label();
            rbOrdenagailua = new RadioButton();
            rbInprimagailua = new RadioButton();
            panOrdenagailua = new Panel();
            lblRam = new Label();
            txtRam = new TextBox();
            lblRom = new Label();
            txtRom = new TextBox();
            lblCpu = new Label();
            txtCpu = new TextBox();
            panInprimagailua = new Panel();
            lblKoloretakua = new Label();
            rbKoloretakuaBai = new RadioButton();
            rbKoloretakuaEz = new RadioButton();
            butaldatu = new Button();
            butatzera = new Button();
            panela.SuspendLayout();
            panDatuak.SuspendLayout();
            panOrdenagailua.SuspendLayout();
            panInprimagailua.SuspendLayout();
            SuspendLayout();
            //
            // panela
            //
            panela.BackColor = Color.White;
            panela.Controls.Add(lblaldatu);
            panela.Controls.Add(panDatuak);
            panela.Dock = DockStyle.Fill;
            panela.Location = new Point(0, 0);
            panela.Name = "panela";
            panela.Size = new Size(1317, 772);
            panela.TabIndex = 0;
            //
            // lblaldatu
            //
            lblaldatu.AutoSize = true;
            lblaldatu.BackColor = SystemColors.Highlight;
            lblaldatu.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblaldatu.ForeColor = Color.White;
            lblaldatu.Location = new Point(245, 50);
            lblaldatu.Name = "lblaldatu";
            lblaldatu.Size = new Size(275, 45);
            lblaldatu.TabIndex = 0;
            lblaldatu.Text = "GAILUA ALDATU";
            //
            // panDatuak
            //
            panDatuak.BackColor = SystemColors.Highlight;
            panDatuak.BorderStyle = BorderStyle.FixedSingle;
            panDatuak.Controls.Add(lblId);
            panDatuak.Controls.Add(txtId);
            panDatuak.Controls.Add(butBilatu);
            panDatuak.Controls.Add(lblMarka);
            panDatuak.Controls.Add(txtMarka);
            panDatuak.Controls.Add(lblKokalekua);
            panDatuak.Controls.Add(txtKokalekua);
            panDatuak.Controls.Add(lblErosteData);
            panDatuak.Controls.Add(dtpErosteData);
            panDatuak.Controls.Add(lblMintegia);
            panDatuak.Controls.Add(lblMintegiaBalio);
            panDatuak.Controls.Add(cmbMintegia);
            panDatuak.Controls.Add(lblGailuMota);
            panDatuak.Controls.Add(rbOrdenagailua);
            panDatuak.Controls.Add(rbInprimagailua);
            panDatuak.Controls.Add(panOrdenagailua);
            panDatuak.Controls.Add(panInprimagailua);
            panDatuak.Controls.Add(butaldatu);
            panDatuak.Controls.Add(butatzera);
            panDatuak.Location = new Point(110, 112);
            panDatuak.Name = "panDatuak";
            panDatuak.Size = new Size(580, 535);
            panDatuak.TabIndex = 1;
            //
            // lblId
            //
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblId.ForeColor = Color.Black;
            lblId.Location = new Point(20, 13);
            lblId.Name = "lblId";
            lblId.Size = new Size(34, 25);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            //
            // txtId
            //
            txtId.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtId.Location = new Point(180, 10);
            txtId.Name = "txtId";
            txtId.Size = new Size(240, 31);
            txtId.TabIndex = 1;
            //
            // butBilatu
            //
            butBilatu.BackColor = Color.White;
            butBilatu.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butBilatu.ForeColor = SystemColors.Highlight;
            butBilatu.Location = new Point(435, 8);
            butBilatu.Name = "butBilatu";
            butBilatu.Size = new Size(120, 35);
            butBilatu.TabIndex = 2;
            butBilatu.Text = "BILATU";
            butBilatu.UseVisualStyleBackColor = false;
            //
            // lblMarka
            //
            lblMarka.AutoSize = true;
            lblMarka.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMarka.ForeColor = Color.Black;
            lblMarka.Location = new Point(20, 78);
            lblMarka.Name = "lblMarka";
            lblMarka.Size = new Size(65, 25);
            lblMarka.TabIndex = 3;
            lblMarka.Text = "Marka:";
            //
            // txtMarka
            //
            txtMarka.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMarka.Location = new Point(180, 75);
            txtMarka.Name = "txtMarka";
            txtMarka.Size = new Size(375, 31);
            txtMarka.TabIndex = 4;
            //
            // lblKokalekua
            //
            lblKokalekua.AutoSize = true;
            lblKokalekua.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKokalekua.ForeColor = Color.Black;
            lblKokalekua.Location = new Point(20, 123);
            lblKokalekua.Name = "lblKokalekua";
            lblKokalekua.Size = new Size(96, 25);
            lblKokalekua.TabIndex = 5;
            lblKokalekua.Text = "Kokalekua:";
            //
            // txtKokalekua
            //
            txtKokalekua.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtKokalekua.Location = new Point(180, 120);
            txtKokalekua.Name = "txtKokalekua";
            txtKokalekua.Size = new Size(375, 31);
            txtKokalekua.TabIndex = 6;
            //
            // lblErosteData
            //
            lblErosteData.AutoSize = true;
            lblErosteData.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblErosteData.ForeColor = Color.Black;
            lblErosteData.Location = new Point(20, 168);
            lblErosteData.Name = "lblErosteData";
            lblErosteData.Size = new Size(107, 25);
            lblErosteData.TabIndex = 7;
            lblErosteData.Text = "Eroste Data:";
            //
            // dtpErosteData
            //
            dtpErosteData.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpErosteData.Format = DateTimePickerFormat.Short;
            dtpErosteData.Location = new Point(180, 165);
            dtpErosteData.Name = "dtpErosteData";
            dtpErosteData.Size = new Size(375, 31);
            dtpErosteData.TabIndex = 8;
            //
            // lblMintegia
            //
            lblMintegia.AutoSize = true;
            lblMintegia.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMintegia.ForeColor = Color.Black;
            lblMintegia.Location = new Point(20, 213);
            lblMintegia.Name = "lblMintegia";
            lblMintegia.Size = new Size(85, 25);
            lblMintegia.TabIndex = 14;
            lblMintegia.Text = "Mintegia:";
            //
            // lblMintegiaBalio
            //
            lblMintegiaBalio.AutoSize = true;
            lblMintegiaBalio.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMintegiaBalio.ForeColor = Color.White;
            lblMintegiaBalio.Location = new Point(180, 213);
            lblMintegiaBalio.Name = "lblMintegiaBalio";
            lblMintegiaBalio.Size = new Size(0, 25);
            lblMintegiaBalio.TabIndex = 15;
            //
            // cmbMintegia
            //
            cmbMintegia.BackColor = Color.White;
            cmbMintegia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMintegia.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMintegia.Location = new Point(180, 210);
            cmbMintegia.Name = "cmbMintegia";
            cmbMintegia.Size = new Size(375, 33);
            cmbMintegia.TabIndex = 16;
            cmbMintegia.Visible = false;
            //
            // lblGailuMota
            //
            lblGailuMota.AutoSize = true;
            lblGailuMota.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGailuMota.ForeColor = Color.Black;
            lblGailuMota.Location = new Point(20, 258);
            lblGailuMota.Name = "lblGailuMota";
            lblGailuMota.Size = new Size(102, 25);
            lblGailuMota.TabIndex = 9;
            lblGailuMota.Text = "Gailu Mota:";
            //
            // rbOrdenagailua
            //
            rbOrdenagailua.AutoSize = true;
            rbOrdenagailua.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbOrdenagailua.ForeColor = Color.Black;
            rbOrdenagailua.Location = new Point(180, 255);
            rbOrdenagailua.Name = "rbOrdenagailua";
            rbOrdenagailua.Size = new Size(139, 29);
            rbOrdenagailua.TabIndex = 10;
            rbOrdenagailua.Text = "Ordenagailua";
            rbOrdenagailua.UseVisualStyleBackColor = true;
            rbOrdenagailua.CheckedChanged += rbOrdenagailua_CheckedChanged;
            //
            // rbInprimagailua
            //
            rbInprimagailua.AutoSize = true;
            rbInprimagailua.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbInprimagailua.ForeColor = Color.Black;
            rbInprimagailua.Location = new Point(345, 255);
            rbInprimagailua.Name = "rbInprimagailua";
            rbInprimagailua.Size = new Size(141, 29);
            rbInprimagailua.TabIndex = 11;
            rbInprimagailua.Text = "Inprimagailua";
            rbInprimagailua.UseVisualStyleBackColor = true;
            rbInprimagailua.CheckedChanged += rbInprimagailua_CheckedChanged;
            //
            // panOrdenagailua
            //
            panOrdenagailua.BackColor = Color.White;
            panOrdenagailua.BorderStyle = BorderStyle.FixedSingle;
            panOrdenagailua.Controls.Add(lblRam);
            panOrdenagailua.Controls.Add(txtRam);
            panOrdenagailua.Controls.Add(lblRom);
            panOrdenagailua.Controls.Add(txtRom);
            panOrdenagailua.Controls.Add(lblCpu);
            panOrdenagailua.Controls.Add(txtCpu);
            panOrdenagailua.Location = new Point(20, 297);
            panOrdenagailua.Name = "panOrdenagailua";
            panOrdenagailua.Size = new Size(540, 140);
            panOrdenagailua.TabIndex = 12;
            panOrdenagailua.Visible = false;
            //
            // lblRam
            //
            lblRam.AutoSize = true;
            lblRam.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRam.ForeColor = Color.Black;
            lblRam.Location = new Point(10, 13);
            lblRam.Name = "lblRam";
            lblRam.Size = new Size(55, 25);
            lblRam.TabIndex = 0;
            lblRam.Text = "RAM:";
            //
            // txtRam
            //
            txtRam.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRam.Location = new Point(130, 10);
            txtRam.Name = "txtRam";
            txtRam.Size = new Size(395, 31);
            txtRam.TabIndex = 1;
            //
            // lblRom
            //
            lblRom.AutoSize = true;
            lblRom.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRom.ForeColor = Color.Black;
            lblRom.Location = new Point(10, 53);
            lblRom.Name = "lblRom";
            lblRom.Size = new Size(57, 25);
            lblRom.TabIndex = 2;
            lblRom.Text = "ROM:";
            //
            // txtRom
            //
            txtRom.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRom.Location = new Point(130, 50);
            txtRom.Name = "txtRom";
            txtRom.Size = new Size(395, 31);
            txtRom.TabIndex = 3;
            //
            // lblCpu
            //
            lblCpu.AutoSize = true;
            lblCpu.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCpu.ForeColor = Color.Black;
            lblCpu.Location = new Point(10, 93);
            lblCpu.Name = "lblCpu";
            lblCpu.Size = new Size(49, 25);
            lblCpu.TabIndex = 4;
            lblCpu.Text = "CPU:";
            //
            // txtCpu
            //
            txtCpu.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCpu.Location = new Point(130, 90);
            txtCpu.Name = "txtCpu";
            txtCpu.Size = new Size(395, 31);
            txtCpu.TabIndex = 5;
            //
            // panInprimagailua
            //
            panInprimagailua.BackColor = Color.White;
            panInprimagailua.BorderStyle = BorderStyle.FixedSingle;
            panInprimagailua.Controls.Add(lblKoloretakua);
            panInprimagailua.Controls.Add(rbKoloretakuaBai);
            panInprimagailua.Controls.Add(rbKoloretakuaEz);
            panInprimagailua.Location = new Point(20, 297);
            panInprimagailua.Name = "panInprimagailua";
            panInprimagailua.Size = new Size(540, 65);
            panInprimagailua.TabIndex = 13;
            panInprimagailua.Visible = false;
            //
            // lblKoloretakua
            //
            lblKoloretakua.AutoSize = true;
            lblKoloretakua.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKoloretakua.Location = new Point(10, 18);
            lblKoloretakua.Name = "lblKoloretakua";
            lblKoloretakua.Size = new Size(114, 25);
            lblKoloretakua.TabIndex = 0;
            lblKoloretakua.Text = "Koloretakua?";
            //
            // rbKoloretakuaBai
            //
            rbKoloretakuaBai.AutoSize = true;
            rbKoloretakuaBai.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbKoloretakuaBai.Location = new Point(155, 15);
            rbKoloretakuaBai.Name = "rbKoloretakuaBai";
            rbKoloretakuaBai.Size = new Size(56, 29);
            rbKoloretakuaBai.TabIndex = 1;
            rbKoloretakuaBai.Text = "Bai";
            rbKoloretakuaBai.UseVisualStyleBackColor = true;
            //
            // rbKoloretakuaEz
            //
            rbKoloretakuaEz.AutoSize = true;
            rbKoloretakuaEz.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbKoloretakuaEz.Location = new Point(240, 15);
            rbKoloretakuaEz.Name = "rbKoloretakuaEz";
            rbKoloretakuaEz.Size = new Size(50, 29);
            rbKoloretakuaEz.TabIndex = 2;
            rbKoloretakuaEz.Text = "Ez";
            rbKoloretakuaEz.UseVisualStyleBackColor = true;
            //
            // butaldatu
            //
            butaldatu.BackColor = Color.White;
            butaldatu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butaldatu.ForeColor = SystemColors.Highlight;
            butaldatu.Location = new Point(20, 473);
            butaldatu.Name = "butaldatu";
            butaldatu.Size = new Size(250, 50);
            butaldatu.TabIndex = 20;
            butaldatu.Text = "ALDATU";
            butaldatu.UseVisualStyleBackColor = false;
            //
            // butatzera
            //
            butatzera.BackColor = Color.White;
            butatzera.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butatzera.ForeColor = SystemColors.Highlight;
            butatzera.Location = new Point(290, 473);
            butatzera.Name = "butatzera";
            butatzera.Size = new Size(250, 50);
            butatzera.TabIndex = 21;
            butatzera.Text = "ATZERA";
            butatzera.UseVisualStyleBackColor = false;
            butatzera.Click += butatzera_Click_1;
            //
            // FAldatu
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1317, 772);
            Controls.Add(panela);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FAldatu";
            Text = "FAldatu";
            WindowState = FormWindowState.Maximized;
            panela.ResumeLayout(false);
            panela.PerformLayout();
            panDatuak.ResumeLayout(false);
            panDatuak.PerformLayout();
            panOrdenagailua.ResumeLayout(false);
            panOrdenagailua.PerformLayout();
            panInprimagailua.ResumeLayout(false);
            panInprimagailua.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panela;
        private Label lblaldatu;
        private Panel panDatuak;
        private Label lblId;
        private TextBox txtId;
        private Button butBilatu;
        private Label lblMarka;
        private TextBox txtMarka;
        private Label lblKokalekua;
        private TextBox txtKokalekua;
        private Label lblErosteData;
        private DateTimePicker dtpErosteData;
        private Label lblMintegia;
        private Label lblMintegiaBalio;
        private ComboBox cmbMintegia;
        private Label lblGailuMota;
        private RadioButton rbOrdenagailua;
        private RadioButton rbInprimagailua;
        private Panel panOrdenagailua;
        private Label lblRam;
        private TextBox txtRam;
        private Label lblRom;
        private TextBox txtRom;
        private Label lblCpu;
        private TextBox txtCpu;
        private Panel panInprimagailua;
        private Label lblKoloretakua;
        private RadioButton rbKoloretakuaBai;
        private RadioButton rbKoloretakuaEz;
        private Button butaldatu;
        private Button butatzera;
    }
}
