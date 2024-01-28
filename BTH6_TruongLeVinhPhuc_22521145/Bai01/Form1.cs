using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Bai01
{
    public partial class Form1 : Form

    {
        private BackgroundWorker backgroundWorker1;
        private readonly BindingList<DownloadItem> downloadList = new BindingList<DownloadItem>();
        private ColumnHeader FileName;
        private ListView listView1;
        private ColumnHeader Progress;
        private ColumnHeader Size;
        private ColumnHeader Speed;
        private ColumnHeader Status;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ColumnHeader URL;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            var resources = new ComponentResourceManager(typeof(Form1));
            backgroundWorker1 = new BackgroundWorker();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            listView1 = new ListView();
            FileName = new ColumnHeader();
            Size = new ColumnHeader();
            Progress = new ColumnHeader();
            Speed = new ColumnHeader();
            Status = new ColumnHeader();
            URL = new ColumnHeader();
            toolStrip1.SuspendLayout();
            SuspendLayout();
           
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[]
            {
                toolStripButton1,
                toolStripButton2
            });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1781, 42);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
        
            toolStripButton1.Image = Image.FromFile("../../plus.png");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(256, 36);
            toolStripButton1.Text = "Add new download";
            toolStripButton1.Click += toolStripButton1_Click;
         
            toolStripButton2.Image = Image.FromFile("../../forbidden.png");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(210, 36);
            toolStripButton2.Text = "Stop download";
            toolStripButton2.Click += toolStripButton2_Click;
          
            listView1.Columns.AddRange(new[]
            {
                FileName,
                Size,
                Progress,
                Speed,
                Status,
                URL
            });
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.HideSelection = false;
            listView1.Location = new Point(0, 42);
            listView1.Name = "listView1";
            listView1.Size = new Size(1781, 594);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
           
            FileName.Text = "File Name";
            FileName.Width = 150;
           
            Size.Text = "Size";
            Size.Width = 120;
            
            Progress.Text = "Progress";
            Progress.Width = 130;
            
            Speed.Text = "Speed";
            Speed.Width = 100;
            
            Status.Text = "Status";
           
            URL.Text = "URL";
            URL.Width = 250;
         
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1781, 636);
            Controls.Add(listView1);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (var addUrlForm = new DownForm())
            {
                if (addUrlForm.ShowDialog() == DialogResult.OK)
                {
                    var url = addUrlForm.Url;
                    var savePath = addUrlForm.savePath;
                    AddDownload(url, savePath);
                }
            }
        }

        private void AddDownload(string url, string path)
        {
            var downloadItem = new DownloadItem(url, path);
            downloadItem.PropertyChanged += Item_PropertyChanged;
            downloadList.Add(downloadItem);
            downloadItem.StartDownload();
            string[] data =
            {
                downloadItem.FileName, downloadItem.BytesDownloaded + "/" + downloadItem.TotalBytesToReceive,
                downloadItem.Progress + "%", $"{downloadItem.Speed:0.##} KB/s", downloadItem.Status, downloadItem.Url
            };
            var newItem = new ListViewItem(data);
            newItem.Tag = downloadItem;
            listView1.Items.Add(newItem);
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var changedItem = sender as DownloadItem;
            if (changedItem != null)
                UpdateListViewItem(changedItem);
        }

        private void UpdateListViewItem(DownloadItem item)
        {
            foreach (ListViewItem listViewItem in listView1.Items)
            {
                var listItem = listViewItem.Tag as DownloadItem;
                if (listItem != null && listItem.FileName == item.FileName)
                {
                    listViewItem.SubItems[1].Text = item.BytesDownloaded + "/" + item.TotalBytesToReceive;
                    listViewItem.SubItems[2].Text = item.Progress + "%";
                    listViewItem.SubItems[3].Text = $"{item.Speed:0.##} KB/s";
                    listViewItem.SubItems[4].Text = item.Status;
                    break;
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                for (var i = 0; i < listView1.SelectedIndices.Count; i++)
                    downloadList[listView1.SelectedIndices[i]].CancelDownload();
        }
    }

    public class DownloadItem : INotifyPropertyChanged
    {
        private long bytesDownloaded;
        private int progress;
        private double speed;
        private string status;
        private readonly Stopwatch stopwatch = new Stopwatch();
        private long totalBytesToReceive;
        private WebClient webClient;

        public DownloadItem(string url, string pathToSave)
        {
            Url = url;
            FileName = Path.GetFileName(url);
            Status = "Waiting";
            Progress = 0;
            IsDownloading = false;
            PathToSave = pathToSave;
        }

        public long BytesDownloaded
        {
            get => bytesDownloaded;
            set
            {
                bytesDownloaded = value;
                OnPropertyChanged(nameof(BytesDownloaded));
            }
        }

        public long TotalBytesToReceive
        {
            get => totalBytesToReceive;
            set
            {
                totalBytesToReceive = value;
                OnPropertyChanged(nameof(TotalBytesToReceive));
            }
        }

        public string Url { get; }
        public string FileName { get; set; }

        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public int Progress
        {
            get => progress;
            set
            {
                progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        public string PathToSave { get; set; }
        public bool IsDownloading { get; private set; }

        public double Speed
        {
            get => speed;
            set
            {
                speed = value;
                OnPropertyChanged(nameof(Speed));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void StartDownload()
        {
            stopwatch.Restart();
            webClient = new WebClient();
            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            webClient.DownloadFileAsync(new Uri(Url), PathToSave);
            IsDownloading = true;
            Status = "Downloading";
        }

        public void CancelDownload()
        {
            if (webClient != null)
            {
                webClient.CancelAsync();
                Status = "Canceled";
                IsDownloading = false;
            }
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Speed = e.BytesReceived / stopwatch.Elapsed.TotalSeconds / 1024;
            BytesDownloaded = e.BytesReceived;
            TotalBytesToReceive = e.TotalBytesToReceive;
            Progress = e.ProgressPercentage;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress)));
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                Status = "Canceled";
            else if (e.Error != null)
                Status = $"Error: {e.Error.Message}";
            else
                Status = "Completed";
            IsDownloading = false;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}