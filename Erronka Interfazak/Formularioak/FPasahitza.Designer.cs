namespace Erronka_Interfazak
{
    partial class FPasahitza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPasahitza));
            lblpasahitzaaldatu = new Label();
            lblerabiltzailea = new Label();
            txtErabiltzaileIzena = new TextBox();
            txtPasahitzBerria = new TextBox();
            lblPasahitzBerria = new Label();
            butaldatu = new Button();
            picpasahitza = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picpasahitza).BeginInit();
            SuspendLayout();
            // 
            // lblpasahitzaaldatu
            // 
            lblpasahitzaaldatu.AutoSize = true;
            lblpasahitzaaldatu.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblpasahitzaaldatu.Location = new Point(122, 28);
            lblpasahitzaaldatu.Name = "lblpasahitzaaldatu";
            lblpasahitzaaldatu.Size = new Size(312, 46);
            lblpasahitzaaldatu.TabIndex = 0;
            lblpasahitzaaldatu.Text = "PASAHITZ BERRIA";
            // 
            // lblerabiltzailea
            // 
            lblerabiltzailea.AutoSize = true;
            lblerabiltzailea.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblerabiltzailea.Location = new Point(122, 110);
            lblerabiltzailea.Name = "lblerabiltzailea";
            lblerabiltzailea.Size = new Size(190, 25);
            lblerabiltzailea.TabIndex = 1;
            lblerabiltzailea.Text = "Sartu erabiltzaile izena:";
            // 
            // txtErabiltzaileIzena
            // 
            txtErabiltzaileIzena.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtErabiltzaileIzena.Location = new Point(122, 138);
            txtErabiltzaileIzena.Name = "txtErabiltzaileIzena";
            txtErabiltzaileIzena.Size = new Size(335, 31);
            txtErabiltzaileIzena.TabIndex = 2;
            // 
            // txtPasahitzBerria
            // 
            txtPasahitzBerria.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPasahitzBerria.Location = new Point(122, 210);
            txtPasahitzBerria.Name = "txtPasahitzBerria";
            txtPasahitzBerria.Size = new Size(335, 31);
            txtPasahitzBerria.TabIndex = 4;
            // 
            // lblPasahitzBerria
            // 
            lblPasahitzBerria.AutoSize = true;
            lblPasahitzBerria.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPasahitzBerria.Location = new Point(122, 182);
            lblPasahitzBerria.Name = "lblPasahitzBerria";
            lblPasahitzBerria.Size = new Size(177, 25);
            lblPasahitzBerria.TabIndex = 3;
            lblPasahitzBerria.Text = "Sartu pasahitz berria:";
            // 
            // butaldatu
            // 
            butaldatu.BackColor = SystemColors.Highlight;
            butaldatu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butaldatu.ForeColor = SystemColors.Control;
            butaldatu.Location = new Point(122, 275);
            butaldatu.Name = "butaldatu";
            butaldatu.Size = new Size(335, 54);
            butaldatu.TabIndex = 5;
            butaldatu.Text = "ALDATU";
            butaldatu.UseVisualStyleBackColor = false;
            butaldatu.Click += butaldatu_Click;
            // 
            // picpasahitza
            // 
            picpasahitza.Image = (Image)resources.GetObject("picpasahitza.Image");
            picpasahitza.Location = new Point(507, 110);
            picpasahitza.Name = "picpasahitza";
            picpasahitza.Size = new Size(253, 219);
            picpasahitza.SizeMode = PictureBoxSizeMode.Zoom;
            picpasahitza.TabIndex = 6;
            picpasahitza.TabStop = false;
            // 
            // FPasahitza
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(picpasahitza);
            Controls.Add(butaldatu);
            Controls.Add(txtPasahitzBerria);
            Controls.Add(lblPasahitzBerria);
            Controls.Add(txtErabiltzaileIzena);
            Controls.Add(lblerabiltzailea);
            Controls.Add(lblpasahitzaaldatu);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FPasahitza";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FPasahitza";
            Load += FPasahitza_Load;
            ((System.ComponentModel.ISupportInitialize)picpasahitza).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblpasahitzaaldatu;
        private Label lblerabiltzailea;
        private TextBox txtErabiltzaileIzena;
        private TextBox txtPasahitzBerria;
        private Label lblPasahitzBerria;
        private Button butaldatu;
        private PictureBox picpasahitza;
    }
}