namespace Erronka_Interfazak
{
    partial class FLangileakIkusi
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
            dgvLangileak = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLangileak).BeginInit();
            SuspendLayout();
            //
            // dgvLangileak
            //
            dgvLangileak.AllowUserToAddRows = false;
            dgvLangileak.AllowUserToDeleteRows = false;
            dgvLangileak.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLangileak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLangileak.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLangileak.Location = new Point(12, 12);
            dgvLangileak.Name = "dgvLangileak";
            dgvLangileak.ReadOnly = true;
            dgvLangileak.RowHeadersWidth = 51;
            dgvLangileak.Size = new Size(776, 426);
            dgvLangileak.TabIndex = 0;
            //
            // FLangileakIkusi
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvLangileak);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FLangileakIkusi";
            Text = "Langileak - Ikusi";
            Load += FLangileakIkusi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLangileak).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvLangileak;
    }
}
