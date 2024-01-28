using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai02
{
    public class Form1 : Form
    {
        private PictureBox ballPictureBox;
        private PictureBox basketPictureBox;
        private Timer gameTimer;
        private const int BallSpeed = 5;
        private const int BasketSpeed = 10;

        public Form1()
        {
            InitializeComponents();
            InitializeGame();
            this.Text = "Bai02";
        }

        private void InitializeComponents()
        {
            this.Size = new Size(400, 400);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
            this.BackColor = Color.Black;

            ballPictureBox = new PictureBox
            {
                Size = new Size(20, 20),
                BackColor = Color.Yellow,
                Location = new Point(140, 0)
            };
            System.Drawing.Drawing2D.GraphicsPath ballPath = new System.Drawing.Drawing2D.GraphicsPath();
            ballPath.AddEllipse(0, 0, ballPictureBox.Width, ballPictureBox.Height);
            ballPictureBox.Region = new Region(ballPath);
            this.Controls.Add(ballPictureBox);

            basketPictureBox = new PictureBox
            {
                Size = new Size(50, 20),
                BackColor = Color.Green,
                Location = new Point((this.ClientSize.Width - 50) / 2, this.ClientSize.Height - 30)
            };
            this.Controls.Add(basketPictureBox);

            gameTimer = new Timer
            {
                Interval = 20
            };
            gameTimer.Tick += GameTimer_Tick;
        }

        private void InitializeGame()
        {
            gameTimer.Start();
            this.KeyDown += MainForm_KeyDown;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            ballPictureBox.Top += BallSpeed;

            if (ballPictureBox.Bottom > this.ClientSize.Height || ballPictureBox.Bounds.IntersectsWith(basketPictureBox.Bounds))
            {
                gameTimer.Stop();

                if (ballPictureBox.Bounds.IntersectsWith(basketPictureBox.Bounds))
                {
                    Random rnd = new Random();
                    int randomX = rnd.Next(0, this.ClientSize.Width - ballPictureBox.Width);
                    ballPictureBox.Location = new Point(randomX, 0);
                }
                else
                {
                    MessageBox.Show("Game over!", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

                gameTimer.Start();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    basketPictureBox.Left = Math.Max(0, basketPictureBox.Left - BasketSpeed);
                    break;
                case Keys.Right:
                    basketPictureBox.Left = Math.Min(this.ClientSize.Width - basketPictureBox.Width, basketPictureBox.Left + BasketSpeed);
                    break;
            }
        }


    }
}