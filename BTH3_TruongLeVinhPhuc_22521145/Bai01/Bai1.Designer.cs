namespace Bai01
{
    partial class Bai1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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


        private System.Windows.Forms.Button btn_change_background_color;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bai 1";
            this.btn_change_background_color = new System.Windows.Forms.Button();
            this.btn_change_background_color.Location = new System.Drawing.Point(350, 200);
            this.btn_change_background_color.Size = new System.Drawing.Size(100, 50);
            this.btn_change_background_color.Text = "Doi mau";
            this.btn_change_background_color.Click += new System.EventHandler(this.btn_change_background_color_Click);
            this.btn_change_background_color.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.Controls.Add(this.btn_change_background_color);

        }

       
    }
}