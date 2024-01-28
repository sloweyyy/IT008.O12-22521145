
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Bai01
{
    public partial class Form1 : Form
    {
        public List<MySprite> listSprites;
        private Timer timer1;
        public Form1()
        {
            InitializeComponent();
            timer1 = new Timer();
            timer1.Interval = 100;
            timer1.Tick += timer1_Tick;
            timer1.Start();

            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            this.ResumeLayout(false);


        }



        private void Form1_Load(object sender, EventArgs e)
        {
            listSprites = new List<MySprite>();
            Bitmap[] bitmaps = new Bitmap[6];
            bitmaps[0] = Properties.Resources._1;
            bitmaps[1] = Properties.Resources._2;
            bitmaps[2] = Properties.Resources._3;
            bitmaps[3] = Properties.Resources._4;
            bitmaps[4] = Properties.Resources._5;
            bitmaps[5] = Properties.Resources._6;

            listSprites.Add(new MySprite(100, 100, 100, 100, 6));
            foreach (Bitmap bitmap in bitmaps)
            {
                listSprites[0].AddImage(bitmap);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (MySprite sprite in listSprites)
            {
                sprite.DrawSprite(g);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (MySprite sprite in listSprites)
            {
                sprite.Update(0.1f);
            }
            Invalidate();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }
    }

    public class MySprite
    {
        private float _height, _width;

        private float _x, _y;
        private int _nSprites;
        private List<Image> _listSprites;
        private int _iSprite;


        public MySprite(float x, float y, float width, float height, int nSprites)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _nSprites = nSprites;
            _iSprite = 0;
            _listSprites = new List<Image>();
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(_listSprites[_iSprite], _x, _y, _width, _height);
        }

        public void Update(float dt)
        {
            _iSprite = (_iSprite + 1) % _nSprites;
        }

        public void AddImage(Image image)
        {
            _listSprites.Add(image);
        }
    }
}
