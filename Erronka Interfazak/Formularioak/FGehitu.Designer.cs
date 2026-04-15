namespace Erronka_Interfazak
{
    partial class FGehitu : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panela = new Panel();
            lblsartu = new Label();
            panDatuak = new Panel();
            lblMarka = new Label();
            txtMarka = new TextBox();
            lblKokalekua = new Label();
            txtKokalekua = new TextBox();
            lblErosteData = new Label();
            dtpErosteData = new DateTimePicker();
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
            butsartu = new Button();
            panela.SuspendLayout();
            panDatuak.SuspendLayout();
            panOrdenagailua.SuspendLayout();
            panInprimagailua.SuspendLayout();
            SuspendLayout();
            // 
            // panela
            // 
            panela.BackColor = Color.White;
            panela.Controls.Add(lblsartu);
            panela.Controls.Add(panDatuak);
            panela.Dock = DockStyle.Fill;
            panela.Location = new Point(0, 0);
            panela.Name = "panela";
            panela.Size = new Size(1317, 772);
            panela.TabIndex = 0;
            panela.Paint += panela_Paint;
            // 
            // lblsartu
            // 
            lblsartu.AutoSize = true;
            lblsartu.BackColor = SystemColors.Highlight;
            lblsartu.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblsartu.ForeColor = Color.White;
            lblsartu.Location = new Point(245, 50);
            lblsartu.Name = "lblsartu";
            lblsartu.Size = new Size(266, 45);
            lblsartu.TabIndex = 0;
            lblsartu.Text = "GAILUA GEHITU";
            // 
            // panDatuak
            // 
            panDatuak.BackColor = SystemColors.Highlight;
            panDatuak.BorderStyle = BorderStyle.FixedSingle;
            panDatuak.Controls.Add(lblMarka);
            panDatuak.Controls.Add(txtMarka);
            panDatuak.Controls.Add(lblKokalekua);
            panDatuak.Controls.Add(txtKokalekua);
            panDatuak.Controls.Add(lblErosteData);
            panDatuak.Controls.Add(dtpErosteData);
            panDatuak.Controls.Add(lblGailuMota);
            panDatuak.Controls.Add(rbOrdenagailua);
            panDatuak.Controls.Add(rbInprimagailua);
            panDatuak.Controls.Add(panOrdenagailua);
            panDatuak.Controls.Add(panInprimagailua);
            panDatuak.Controls.Add(butsartu);
            panDatuak.Location = new Point(110, 112);
            panDatuak.Name = "panDatuak";
            panDatuak.Size = new Size(580, 425);
            panDatuak.TabIndex = 1;
            // 
            // lblMarka
            // 
            lblMarka.AutoSize = true;
            lblMarka.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMarka.ForeColor = Color.Black;
            lblMarka.Location = new Point(20, 23);
            lblMarka.Name = "lblMarka";
            lblMarka.Size = new Size(65, 25);
            lblMarka.TabIndex = 0;
            lblMarka.Text = "Marka:";
            // 
            // txtMarka
            // 
            txtMarka.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMarka.Location = new Point(180, 20);
            txtMarka.Name = "txtMarka";
            txtMarka.Size = new Size(375, 31);
            txtMarka.TabIndex = 1;
            // 
            // lblKokalekua
            // 
            lblKokalekua.AutoSize = true;
            lblKokalekua.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKokalekua.ForeColor = Color.Black;
            lblKokalekua.Location = new Point(20, 68);
            lblKokalekua.Name = "lblKokalekua";
            lblKokalekua.Size = new Size(96, 25);
            lblKokalekua.TabIndex = 2;
            lblKokalekua.Text = "Kokalekua:";
            // 
            // txtKokalekua
            // 
            txtKokalekua.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtKokalekua.Location = new Point(180, 65);
            txtKokalekua.Name = "txtKokalekua";
            txtKokalekua.Size = new Size(375, 31);
            txtKokalekua.TabIndex = 3;
            // 
            // lblErosteData
            // 
            lblErosteData.AutoSize = true;
            lblErosteData.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblErosteData.ForeColor = Color.Black;
            lblErosteData.Location = new Point(20, 113);
            lblErosteData.Name = "lblErosteData";
            lblErosteData.Size = new Size(107, 25);
            lblErosteData.TabIndex = 4;
            lblErosteData.Text = "Eroste Data:";
            // 
            // dtpErosteData
            // 
            dtpErosteData.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpErosteData.Format = DateTimePickerFormat.Short;
            dtpErosteData.Location = new Point(180, 110);
            dtpErosteData.Name = "dtpErosteData";
            dtpErosteData.Size = new Size(375, 31);
            dtpErosteData.TabIndex = 5;
            // 
            // lblGailuMota
            // 
            lblGailuMota.AutoSize = true;
            lblGailuMota.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGailuMota.ForeColor = Color.Black;
            lblGailuMota.Location = new Point(20, 158);
            lblGailuMota.Name = "lblGailuMota";
            lblGailuMota.Size = new Size(102, 25);
            lblGailuMota.TabIndex = 8;
            lblGailuMota.Text = "Gailu Mota:";
            // 
            // rbOrdenagailua
            // 
            rbOrdenagailua.AutoSize = true;
            rbOrdenagailua.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbOrdenagailua.ForeColor = Color.Black;
            rbOrdenagailua.Location = new Point(180, 155);
            rbOrdenagailua.Name = "rbOrdenagailua";
            rbOrdenagailua.Size = new Size(139, 29);
            rbOrdenagailua.TabIndex = 9;
            rbOrdenagailua.Text = "Ordenagailua";
            rbOrdenagailua.UseVisualStyleBackColor = true;
            rbOrdenagailua.CheckedChanged += rbOrdenagailua_CheckedChanged;
            // 
            // rbInprimagailua
            // 
            rbInprimagailua.AutoSize = true;
            rbInprimagailua.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbInprimagailua.ForeColor = Color.Black;
            rbInprimagailua.Location = new Point(345, 155);
            rbInprimagailua.Name = "rbInprimagailua";
            rbInprimagailua.Size = new Size(141, 29);
            rbInprimagailua.TabIndex = 10;
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
            panOrdenagailua.Location = new Point(20, 197);
            panOrdenagailua.Name = "panOrdenagailua";
            panOrdenagailua.Size = new Size(540, 140);
            panOrdenagailua.TabIndex = 11;
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
            panInprimagailua.Location = new Point(20, 197);
            panInprimagailua.Name = "panInprimagailua";
            panInprimagailua.Size = new Size(540, 65);
            panInprimagailua.TabIndex = 12;
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
            // butsartu
            // 
            butsartu.BackColor = Color.White;
            butsartu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butsartu.ForeColor = SystemColors.Highlight;
            butsartu.Location = new Point(105, 363);
            butsartu.Name = "butsartu";
            butsartu.Size = new Size(370, 50);
            butsartu.TabIndex = 20;
            butsartu.Text = "SARTU";
            butsartu.UseVisualStyleBackColor = false;
            butsartu.Click += butsartu_Click;
            // 
            // FGehitu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1317, 772);
            Controls.Add(panela);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FGehitu";
            Text = "FGehitu";
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
        private Label lblsartu;
        private Panel panDatuak;
        private Label lblMarka;
        private TextBox txtMarka;
        private Label lblKokalekua;
        private TextBox txtKokalekua;
        private Label lblErosteData;
        private DateTimePicker dtpErosteData;
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
        private Button butsartu;
    }
}
