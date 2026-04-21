namespace Erronka_Interfazak
{
    public partial class FSarrera : Form
    {
        public FSarrera()
        {
            InitializeComponent();
        }

        private void butsartu_Click(object sender, EventArgs e)
        {
            FPasahitza fpasahitza = new FPasahitza();
            fpasahitza.Show();
            this.Close();
        }

        private void FSarrera_Load(object sender, EventArgs e)
        {

        }
    }
}
