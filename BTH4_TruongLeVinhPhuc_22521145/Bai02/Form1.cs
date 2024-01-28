using System;
using System.Windows.Forms;

namespace Bai02
{
    public partial class Form1 : Form
    {
        private Label label1;
        private System.Windows.Forms.Timer timer1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void InitializeComponent()
        {

            this.ClientSize = new System.Drawing.Size(500, 200);

            label1 = new Label();
            label1.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy hh:mm:ss tt");

            label1.AutoSize = true;
            label1.AutoSize = false;
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label1.Dock = DockStyle.Fill;
            Controls.Add(label1);
            StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Simple Clock";
            this.Load += new System.EventHandler(this.Form1_Load);


        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy hh:mm:ss tt");
        }
    }
}
