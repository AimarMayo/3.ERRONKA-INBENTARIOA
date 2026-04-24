namespace Erronka_Interfazak
{
    partial class FSarrera
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSarrera));
            pansarrera = new Panel();
            butitxi = new Button();
            butsartu = new Button();
            txtpasahitza = new TextBox();
            lblpasahitza = new Label();
            txtemaila = new TextBox();
            lblEmaila = new Label();
            lblsaioahasi = new Label();
            pansarrera.SuspendLayout();
            SuspendLayout();
            // 
            // pansarrera
            // 
            pansarrera.Controls.Add(butitxi);
            pansarrera.Controls.Add(butsartu);
            pansarrera.Controls.Add(txtpasahitza);
            pansarrera.Controls.Add(lblpasahitza);
            pansarrera.Controls.Add(txtemaila);
            pansarrera.Controls.Add(lblEmaila);
            pansarrera.Controls.Add(lblsaioahasi);
            pansarrera.Dock = DockStyle.Fill;
            pansarrera.Location = new Point(0, 0);
            pansarrera.Name = "pansarrera";
            pansarrera.Size = new Size(800, 450);
            pansarrera.TabIndex = 0;
            // 
            // butitxi
            // 
            butitxi.BackColor = Color.Gray;
            butitxi.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butitxi.ForeColor = SystemColors.Control;
            butitxi.Location = new Point(382, 287);
            butitxi.Name = "butitxi";
            butitxi.Size = new Size(178, 57);
            butitxi.TabIndex = 8;
            butitxi.Text = "ITXI";
            butitxi.UseVisualStyleBackColor = false;
            butitxi.Click += butitxi_Click;
            // 
            // butsartu
            // 
            butsartu.BackColor = SystemColors.Highlight;
            butsartu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butsartu.ForeColor = SystemColors.Control;
            butsartu.Location = new Point(190, 287);
            butsartu.Name = "butsartu";
            butsartu.Size = new Size(178, 57);
            butsartu.TabIndex = 7;
            butsartu.Text = "SARRERA";
            butsartu.UseVisualStyleBackColor = false;
            butsartu.Click += butsartu_Click;
            // 
            // txtpasahitza
            // 
            txtpasahitza.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtpasahitza.Location = new Point(190, 218);
            txtpasahitza.Name = "txtpasahitza";
            txtpasahitza.Size = new Size(370, 31);
            txtpasahitza.TabIndex = 6;
            // 
            // lblpasahitza
            // 
            lblpasahitza.AutoSize = true;
            lblpasahitza.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblpasahitza.Location = new Point(190, 190);
            lblpasahitza.Name = "lblpasahitza";
            lblpasahitza.Size = new Size(88, 25);
            lblpasahitza.TabIndex = 5;
            lblpasahitza.Text = "Pasahitza:";
            // 
            // txtemaila
            // 
            txtemaila.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtemaila.Location = new Point(190, 134);
            txtemaila.Name = "txtemaila";
            txtemaila.Size = new Size(370, 31);
            txtemaila.TabIndex = 4;
            // 
            // lblEmaila
            // 
            lblEmaila.AutoSize = true;
            lblEmaila.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmaila.Location = new Point(190, 106);
            lblEmaila.Name = "lblEmaila";
            lblEmaila.Size = new Size(67, 25);
            lblEmaila.TabIndex = 3;
            lblEmaila.Text = "Emaila:";
            // 
            // lblsaioahasi
            // 
            lblsaioahasi.AutoSize = true;
            lblsaioahasi.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblsaioahasi.Location = new Point(278, 29);
            lblsaioahasi.Name = "lblsaioahasi";
            lblsaioahasi.Size = new Size(212, 46);
            lblsaioahasi.TabIndex = 0;
            lblsaioahasi.Text = "SAIOA HASI";
            // 
            // FSarrera
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pansarrera);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FSarrera";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SARRERA";

            pansarrera.ResumeLayout(false);
            pansarrera.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pansarrera;
        private TextBox txtpasahitza;
        private Label lblpasahitza;
        private TextBox txtemaila;
        private Label lblEmaila;
        private Label lblsaioahasi;
        private Button butsartu;
        private Button butitxi;
    }
}
