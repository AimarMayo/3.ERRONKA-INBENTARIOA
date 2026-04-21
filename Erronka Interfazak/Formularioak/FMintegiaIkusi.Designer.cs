namespace Erronka_Interfazak
{
    partial class FMintegiaIkusi
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
            dgvMintegiak = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMintegiak).BeginInit();
            SuspendLayout();
            //
            // dgvMintegiak
            //
            dgvMintegiak.AllowUserToAddRows = false;
            dgvMintegiak.AllowUserToDeleteRows = false;
            dgvMintegiak.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMintegiak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMintegiak.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMintegiak.Location = new Point(12, 12);
            dgvMintegiak.Name = "dgvMintegiak";
            dgvMintegiak.ReadOnly = true;
            dgvMintegiak.RowHeadersWidth = 51;
            dgvMintegiak.Size = new Size(776, 426);
            dgvMintegiak.TabIndex = 0;
            //
            // FMintegiaIkusi
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvMintegiak);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FMintegiaIkusi";
            Text = "Mintegia - Ikusi";
            Load += FMintegiaIkusi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMintegiak).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMintegiak;
    }
}
