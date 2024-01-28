namespace Bai02
{
    partial class Bai2
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

        private MenuStrip menuStrip;
        private ToolStripMenuItem formatMenu;
        private ToolStripMenuItem formatBackgroundColor;



        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            components = new System.ComponentModel.Container();
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Text = "Bai2";

            menuStrip = new MenuStrip();
            formatMenu = new ToolStripMenuItem();
            formatMenu.Text = "Format";
            menuStrip.Items.Add(formatMenu);
            formatBackgroundColor = new ToolStripMenuItem();
            formatBackgroundColor.Click += new EventHandler(btn_format_background_color_Click);
            formatBackgroundColor.Text = "Color";
            formatMenu.DropDownItems.Add(formatBackgroundColor);
            Controls.Add(menuStrip);

        }

        #endregion
    }
}