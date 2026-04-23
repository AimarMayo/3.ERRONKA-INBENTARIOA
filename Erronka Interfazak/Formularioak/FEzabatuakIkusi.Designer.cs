namespace Erronka_Interfazak
{
    partial class FEzabatuakIkusi
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
            dgvEzabatuak = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvEzabatuak).BeginInit();
            SuspendLayout();
            //
            // dgvEzabatuak
            //
            dgvEzabatuak.AllowUserToAddRows = false;
            dgvEzabatuak.AllowUserToDeleteRows = false;
            dgvEzabatuak.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEzabatuak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEzabatuak.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEzabatuak.Location = new Point(12, 12);
            dgvEzabatuak.Name = "dgvEzabatuak";
            dgvEzabatuak.ReadOnly = true;
            dgvEzabatuak.RowHeadersWidth = 51;
            dgvEzabatuak.Size = new Size(776, 426);
            dgvEzabatuak.TabIndex = 0;
            //
            // FEzabatuakIkusi
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvEzabatuak);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FEzabatuakIkusi";
            Text = "Ezabatutako Gailuak";
            Load += FEzabatuakIkusi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEzabatuak).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEzabatuak;
    }
}
