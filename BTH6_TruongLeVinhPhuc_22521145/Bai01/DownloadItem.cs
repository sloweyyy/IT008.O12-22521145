using System;
using System.ComponentModel;
using System.Net;

namespace Bai01
{
    public class DownloadItem
    {
        public string FileName { get; set; }
        public string DownloadUrl { get; set; }
        public string SavePath { get; set; }
        public DownloadStatus Status { get; set; }
        public int Progress { get; set; }

        private WebClient webClient;

        public DownloadItem(string downloadUrl, string savePath)
        {
            DownloadUrl = downloadUrl;
            SavePath = savePath;
            FileName = System.IO.Path.GetFileName(downloadUrl);
            Status = DownloadStatus.Pending;
            Progress = 0;
        }

        public void StartDownload()
        {
            webClient = new WebClient();
            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            webClient.DownloadFileAsync(new Uri(DownloadUrl), SavePath);
            Status = DownloadStatus.Downloading;
        }

        public void StopDownload()
        {
            try
            {
                if (webClient != null)
                {
                    webClient.CancelAsync();
                    webClient.Dispose();
                    webClient = null;
                    Status = DownloadStatus.Stopped;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during WebClient disposal: {ex.Message}");
            }
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Progress = e.ProgressPercentage;
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Status = DownloadStatus.Stopped;
            }
            else if (e.Error != null)
            {
                Status = DownloadStatus.Error;
                Console.WriteLine($"Download failed: {e.Error.Message}");
            }
            else
            {
                Status = DownloadStatus.Completed;
            }
        }

        // Download ProgressChanged










        // DownloadFileCompleted

        // CancelAsync

    }

    public enum DownloadStatus
    {
        Pending,
        Downloading,
        Paused,
        Completed,
        Stopped,
        Error
    }
}
