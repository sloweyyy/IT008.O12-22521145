using System.ComponentModel;
using AxWMPLib;
using Timer = System.Windows.Forms.Timer;

namespace Bai03
{
    public partial class Form1 : Form
    {
        private AxWindowsMediaPlayer mediaPlayer;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem openMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private Label lblTimer;

        public Form1()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            mediaPlayer = new AxWindowsMediaPlayer();
            ((ISupportInitialize)(mediaPlayer)).BeginInit();
            Controls.Add(mediaPlayer);
            mediaPlayer.Dock = DockStyle.Fill;
            ((ISupportInitialize)(mediaPlayer)).EndInit();
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem("File");
            openMenuItem = new ToolStripMenuItem("Open");
            exitMenuItem = new ToolStripMenuItem("Exit");

            openMenuItem.Click += OpenMenuItem_Click;
            exitMenuItem.Click += ExitMenuItem_Click;

            fileMenu.DropDownItems.Add(openMenuItem);
            fileMenu.DropDownItems.Add(exitMenuItem);
            menuStrip.Items.Add(fileMenu);
            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);
            Size = new(1280, 720);
            Text = "Chương trình Windows Media Player";
            StartPosition = FormStartPosition.CenterScreen;

            lblTimer = new Label();
            lblTimer.Text =
                $"Hôm nay là ngày {DateTime.Now:dd/MM/yyyy} - Bây giờ là {DateTime.Now:HH:mm:ss}";
            lblTimer.Dock = DockStyle.Bottom;
            Controls.Add(lblTimer);
        }


        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Media Files|*.avi;*.mpeg;*.wav;*.midi;*.mp4;*.mp3";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        mediaPlayer.URL = openFileDialog.FileName;
                        mediaPlayer.Ctlcontrols.play();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening the media file: {ex.Message}", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}