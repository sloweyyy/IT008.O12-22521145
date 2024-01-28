using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bai03
{
    public partial class Form1 : Form
    {
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem detailToolStripMenuItem;
        private ToolStripComboBox DriveCb;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ColumnHeader FileName;
        private ToolStripMenuItem iconToolStripMenuItem;
        private ColumnHeader LastModified;
        private ListView listView1;
        private MenuStrip menuStrip1;
        private ColumnHeader Size;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripTextBox toolStripTextBox1;
        private ColumnHeader Type;
        private ToolStripMenuItem viewToolStripMenuItem;

        public Form1()
        {
            InitializeComponent();
            InitData();
            LoadData();
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            viewToolStripMenuItem = new ToolStripMenuItem();
            detailToolStripMenuItem = new ToolStripMenuItem();
            iconToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            DriveCb = new ToolStripComboBox();
            toolStrip1 = new ToolStrip();
            toolStripTextBox1 = new ToolStripTextBox();
            listView1 = new ListView();
            FileName = new ColumnHeader();
            Type = new ColumnHeader();
            Size = new ColumnHeader();
            LastModified = new ColumnHeader();
            toolStripButton1 = new ToolStripButton();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
      
            menuStrip1.GripMargin = new Padding(2, 2, 0, 2);
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[]
            {
                viewToolStripMenuItem,
                aboutToolStripMenuItem,
                exitToolStripMenuItem,
                DriveCb
            });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1243, 48);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                detailToolStripMenuItem,
                iconToolStripMenuItem
            });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(85, 40);
            viewToolStripMenuItem.Text = "View";
          
            detailToolStripMenuItem.Name = "detailToolStripMenuItem";
            detailToolStripMenuItem.Size = new Size(209, 44);
            detailToolStripMenuItem.Text = "Detail";
            detailToolStripMenuItem.Click += detailToolStripMenuItem_Click;
           
            iconToolStripMenuItem.Name = "iconToolStripMenuItem";
            iconToolStripMenuItem.Size = new Size(209, 44);
            iconToolStripMenuItem.Text = "Icon";
            iconToolStripMenuItem.Click += iconToolStripMenuItem_Click;
         
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(99, 40);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
          
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(71, 40);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
          
            DriveCb.Alignment = ToolStripItemAlignment.Right;
            DriveCb.Name = "DriveCb";
            DriveCb.Size = new Size(121, 40);
            DriveCb.Text = "C:\\";
            DriveCb.SelectedIndexChanged += DriveCb_SelectedIndexChanged;
            DriveCb.Click += DriveCb_Click;
           
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[]
            {
                toolStripButton1,
                toolStripTextBox1
            });
            toolStrip1.Location = new Point(0, 48);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1243, 50);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
          
            toolStripTextBox1.AutoSize = false;
            toolStripTextBox1.Font = new Font("Segoe UI", 9F);
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.ReadOnly = true;
            toolStripTextBox1.Size = new Size(550, 42);
            toolStripTextBox1.Text = "C:\\";
            toolStripTextBox1.TextChanged += toolStripTextBox1_TextChanged;
          
            listView1.Columns.AddRange(new[]
            {
                FileName,
                Type,
                Size,
                LastModified
            });
            listView1.Dock = DockStyle.Fill;
            listView1.HideSelection = false;
            listView1.Location = new Point(0, 98);
            listView1.Name = "listView1";
            listView1.Size = new Size(1243, 779);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
          
            FileName.Text = "File Name";
            FileName.Width = 200;
           
            Type.Text = "Type";
            
            Size.Text = "Size";
           
            LastModified.Text = "Last modified";
            LastModified.Width = 200;
            
            toolStripButton1.Image = Image.FromFile("../../Resources/up.png");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.RightToLeft = RightToLeft.Yes;
            toolStripButton1.Size = new Size(80, 44);
            toolStripButton1.Text = "Up";
            toolStripButton1.TextAlign = ContentAlignment.MiddleLeft;
            toolStripButton1.TextDirection = ToolStripTextDirection.Horizontal;
            toolStripButton1.Click += toolStripButton1_Click;
           
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1243, 877);
            Controls.Add(listView1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "File Explorer";
            Text = "File Explorer";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void InitData()
        {
            var allDrives = DriveInfo.GetDrives();
            foreach (var drive in allDrives) DriveCb.Items.Add(drive.Name);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void DriveCb_Click(object sender, EventArgs e)
        {
        }

        private void DriveCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = DriveCb.SelectedItem.ToString();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            listView1.Items.Clear();
            var directoryPath = toolStripTextBox1.Text;
            if (Directory.Exists(toolStripTextBox1.Text))
            {
                var files = Directory.GetFileSystemEntries(directoryPath);
                listView1.SmallImageList = new ImageList();
                listView1.LargeImageList = new ImageList();
                listView1.SmallImageList.Images.Add("Folder", Image.FromFile("../../Resources/folder.jpg"));
                listView1.LargeImageList.Images.Add("Folder", Image.FromFile("../../Resources/folder.jpg"));
                foreach (var filePath in files)
                {
                    var fileInfo = new FileInfo(filePath);
                    var item = new ListViewItem(Path.GetFileNameWithoutExtension(filePath));
                    item.ImageKey = fileInfo.Name;
                    var fileIcon = GetFileIcon(filePath);
                    if (fileIcon != null)
                    {
                        listView1.SmallImageList.Images.Add(fileInfo.Name, fileIcon.ToBitmap());
                        listView1.LargeImageList.Images.Add(fileInfo.Name, fileIcon.ToBitmap());
                    }
                    else
                    {
                        item.ImageKey = "Folder";
                    }

                    if (Directory.Exists(filePath))
                    {
                        item.SubItems.Add("<DIR>");
                        item.SubItems.Add("");
                    }
                    else
                    {
                        item.SubItems.Add(fileInfo.Extension);
                        item.SubItems.Add(fileInfo.Length.ToString());
                    }

                    item.SubItems.Add(fileInfo.LastWriteTime.ToString());
                    listView1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Thư mục không tồn tại.");
            }
        }

        private static Icon GetFileIcon(string filePath)
        {
            try
            {
                var fileIcon = Icon.ExtractAssociatedIcon(filePath);
                return fileIcon;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems != null)
            {
                var item = listView1.SelectedItems[0];
                string stradd;
                if (toolStripTextBox1.Text.Length <= 3) stradd = "";
                else stradd = "\\";
                var filepath = toolStripTextBox1.Text + stradd + item.SubItems[0].Text;
                if (item.SubItems[1].Text != "<DIR>")
                {
                    filepath += item.SubItems[1].Text;
                    Process.Start(filepath);
                }
                else
                {
                    toolStripTextBox1.Text = filepath;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text.Length <= 3) return;
            var str = toolStripTextBox1.Text;
            for (var i = str.Length - 1; i >= 0; i--)
                if (str[i] == '\\')
                {
                    if (i > 2) str = str.Substring(0, i);
                    else str = str.Substring(0, i + 1);
                    toolStripTextBox1.Text = str;
                    return;
                }
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void iconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var af = new AboutBox1();
            af.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}