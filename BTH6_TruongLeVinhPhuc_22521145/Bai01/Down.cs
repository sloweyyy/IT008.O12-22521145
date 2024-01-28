using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Bai01
{
    public partial class DownForm : Form
    {
        private Button button1;
        private Button button2;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label label1;
        private Label label2;
        private TextBox Savetb;
        private TextBox URLtb;

        public DownForm()
        {
            InitializeComponent();
        }

        public string Url { get; set; }
        public string savePath { get; set; }

        private void InitializeComponent()
        {
            label1 = new Label();
            URLtb = new TextBox();
            Savetb = new TextBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            SuspendLayout();

            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(40, 58);
            label1.Name = "label1";
            label1.Size = new Size(77, 31);
            label1.TabIndex = 0;
            label1.Text = "URL:";

            URLtb.Location = new Point(160, 58);
            URLtb.Multiline = true;
            URLtb.Name = "URLtb";
            URLtb.Size = new Size(551, 31);
            URLtb.TabIndex = 1;
            URLtb.TextChanged += URLtb_TextChanged;

            Savetb.Location = new Point(160, 135);
            Savetb.Multiline = true;
            Savetb.Name = "Savetb";
            Savetb.Size = new Size(503, 31);
            Savetb.TabIndex = 3;
            Savetb.TextChanged += Savetb_TextChanged;

            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(40, 135);
            label2.Name = "label2";
            label2.Size = new Size(114, 31);
            label2.TabIndex = 2;
            label2.Text = "Save to:";

            button1.Location = new Point(669, 135);
            button1.Name = "button1";
            button1.Size = new Size(42, 31);
            button1.TabIndex = 4;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;

            button2.Location = new Point(550, 208);
            button2.Name = "button2";
            button2.Size = new Size(161, 43);
            button2.TabIndex = 5;
            button2.Text = "Download";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;

            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(725, 263);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Savetb);
            Controls.Add(label2);
            Controls.Add(URLtb);
            Controls.Add(label1);
            Name = "Download Form";
            Text = "Download Form";
            ResumeLayout(false);
            PerformLayout();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                savePath = Path.Combine(folderBrowserDialog1.SelectedPath, Path.GetFileName(Url));
                Savetb.Text = savePath;
            }
        }

        private void URLtb_TextChanged(object sender, EventArgs e)
        {
            Url = URLtb.Text;
        }

        private void Savetb_TextChanged(object sender, EventArgs e)
        {
            savePath = Savetb.Text;
        }
    }
}