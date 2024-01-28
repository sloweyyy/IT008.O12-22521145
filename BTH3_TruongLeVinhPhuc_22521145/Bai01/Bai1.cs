namespace Bai01
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        // button change background color
        // btn_change_background_color

        private void btn_change_background_color_Click(object sender, EventArgs e)
        {
            // random color
            var random = new Random();
            Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            this.BackColor = randomColor;
        }
    }
}