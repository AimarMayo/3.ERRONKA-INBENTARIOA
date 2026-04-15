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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
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
            lblpasahitzaaldatu.Click += lblpasahitzaaldatu_Click;
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
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(122, 138);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(335, 31);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(122, 210);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(335, 31);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(122, 182);
            label1.Name = "label1";
            label1.Size = new Size(177, 25);
            label1.TabIndex = 3;
            label1.Text = "Sartu pasahitz berria:";
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
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
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
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Button butaldatu;
        private PictureBox picpasahitza;
    }
}