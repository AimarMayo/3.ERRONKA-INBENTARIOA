namespace Erronka_Interfazak
{
    partial class FIkusi
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
            dgvGailuak = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvGailuak).BeginInit();
            SuspendLayout();
            // 
            // dgvGailuak
            // 
            dgvGailuak.AllowUserToAddRows = false;
            dgvGailuak.AllowUserToDeleteRows = false;
            dgvGailuak.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGailuak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGailuak.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGailuak.Location = new Point(12, 12);
            dgvGailuak.Name = "dgvGailuak";
            dgvGailuak.ReadOnly = true;
            dgvGailuak.RowHeadersWidth = 51;
            dgvGailuak.Size = new Size(776, 426);
            dgvGailuak.TabIndex = 0;
            // 
            // FIkusi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvGailuak);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FIkusi";
            Text = "Gailuak - Ikusi";
            Load += FIkusi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGailuak).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGailuak;
    }
}