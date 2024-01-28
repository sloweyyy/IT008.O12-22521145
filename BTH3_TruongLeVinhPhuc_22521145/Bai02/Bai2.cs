namespace Bai02
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }


        private void btn_format_background_color_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            this.BackColor = colorDialog.Color;
        }

    }
}