using Caliburn.Micro;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace LogFileViewer
{
    public class MainViewModel : PropertyChangedBase, IMain
    {
        private string _selectedFolderPath;
        public string SelectedFolderPath
        {
            get => _selectedFolderPath;
            set
            {
                _selectedFolderPath = value;
                NotifyOfPropertyChange(() => SelectedFolderPath);
            }
        }

        private ObservableCollection<FileItem> _logFiles;
        public ObservableCollection<FileItem> LogFiles
        {
            get => _logFiles;
            set
            {
                _logFiles = value;
                NotifyOfPropertyChange(() => LogFiles);
            }
        }

        private FileItem _selectedLogFile;
        public FileItem SelectedLogFile
        {
            get => _selectedLogFile;
            set
            {
                if (_selectedLogFile != value)
                {
                    _selectedLogFile = value;
                    NotifyOfPropertyChange(() => SelectedLogFile);
                    if (_selectedLogFile != null)
                    {
                        // TODO: Load and display the selected log file's contents
                        System.Diagnostics.Debug.WriteLine($"Selected log file: {_selectedLogFile.FileName}");
                    }
                }
            }
        }

        public MainViewModel()
        {
            LogFiles = new ObservableCollection<FileItem>();
            //LogFiles.Add(new FileItem
            //{
            //    FileName = "application.log",
            //    FileSize = "1.2 MB",
            //    LastModified = "2024-03-24 12:30 PM",
            //    FullPath = "Kn�llerup",
            //    HasErrors = false
            //});
            LoadLogFiles("F:\\Logtest\\logs");
        }

        public void SelectFolder()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select a folder containing log files";
                dialog.UseDescriptionForTitle = true;
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SelectedFolderPath = dialog.SelectedPath;
                    LoadLogFiles(SelectedFolderPath);
                }
            }
        }

        private void LoadLogFiles(string folderPath)
        {
            try
            {
                LogFiles.Clear();
                var logFiles = Directory.GetFiles(folderPath, "*.log", SearchOption.TopDirectoryOnly);

                foreach (var file in logFiles)
                {
                    var fileInfo = new FileInfo(file);
                    var fileItem = new FileItem
                    {
                        FileName = fileInfo.Name,
                        FileSize = FormatFileSize(fileInfo.Length),
                        LastModified = FormatLastModified(fileInfo.LastWriteTime),
                        FullPath = fileInfo.FullName,
                        HasErrors = ContainsErrors(fileInfo) // You can implement your own logic here
                    };

                    LogFiles.Add(fileItem);
                }
            }
            catch (Exception ex)
            {
                // TODO: Proper error handling
                System.Windows.MessageBox.Show($"Error loading log files: {ex.Message}");
            }
        }

        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            double size = bytes;

            while (size >= 1024 && order < sizes.Length - 1)
            {
                order++;
                size = size / 1024;
            }

            return $"{size:0.##} {sizes[order]}";
        }

        private string FormatLastModified(DateTime lastWriteTime)
        {
            if (lastWriteTime.Date == DateTime.Today)
                return $"Today {lastWriteTime:HH:mm}";
            if (lastWriteTime.Date == DateTime.Today.AddDays(-1))
                return $"Yesterday {lastWriteTime:HH:mm}";
            return lastWriteTime.ToString("yyyy-MM-dd HH:mm");
        }

        private bool ContainsErrors(FileInfo file)
        {
            // TODO: Implement your logic to determine if a log file contains errors
            // For now, we'll return false
            return false;
        }
    }
} 