namespace Erronka_Interfazak
{
    partial class FInzidentziak
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
            dgvInzidentziak = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvInzidentziak).BeginInit();
            SuspendLayout();
            //
            // dgvInzidentziak
            //
            dgvInzidentziak.AllowUserToAddRows = false;
            dgvInzidentziak.AllowUserToDeleteRows = false;
            dgvInzidentziak.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInzidentziak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInzidentziak.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInzidentziak.Location = new Point(12, 12);
            dgvInzidentziak.Name = "dgvInzidentziak";
            dgvInzidentziak.ReadOnly = true;
            dgvInzidentziak.RowHeadersWidth = 51;
            dgvInzidentziak.Size = new Size(776, 426);
            dgvInzidentziak.TabIndex = 0;
            //
            // FInzidentziak
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvInzidentziak);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FInzidentziak";
            Text = "Inzidentziak - Ikusi";
            Load += FInzidentziak_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInzidentziak).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvInzidentziak;
    }
}
