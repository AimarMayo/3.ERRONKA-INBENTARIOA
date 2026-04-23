using System.Drawing;
using System.Windows.Forms;

namespace Erronka_Interfazak
{
    public static class Galdera
    {
        public static DialogResult Galdetu(string mezua, string izenburua)
        {
            using Form form = new Form();
            form.Text = izenburua;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.ClientSize = new Size(420, 160);
            form.BackColor = Color.White;

            Label lbl = new Label();
            lbl.Text = mezua;
            lbl.Location = new Point(20, 20);
            lbl.Size = new Size(380, 70);
            lbl.Font = new Font("Segoe UI", 10f);
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            form.Controls.Add(lbl);

            Button butBai = new Button();
            butBai.Text = "BAI";
            butBai.DialogResult = DialogResult.Yes;
            butBai.Location = new Point(90, 110);
            butBai.Size = new Size(100, 35);
            butBai.BackColor = SystemColors.Highlight;
            butBai.ForeColor = Color.White;
            butBai.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            butBai.FlatStyle = FlatStyle.Flat;
            butBai.FlatAppearance.BorderSize = 0;
            form.Controls.Add(butBai);

            Button butEz = new Button();
            butEz.Text = "EZ";
            butEz.DialogResult = DialogResult.No;
            butEz.Location = new Point(230, 110);
            butEz.Size = new Size(100, 35);
            butEz.BackColor = Color.White;
            butEz.ForeColor = SystemColors.Highlight;
            butEz.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            butEz.FlatStyle = FlatStyle.Flat;
            form.Controls.Add(butEz);

            form.AcceptButton = butBai;
            form.CancelButton = butEz;

            return form.ShowDialog();
        }
    }
}
