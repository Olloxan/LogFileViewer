using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using Microsoft.Xaml.Behaviors.Media;

namespace LogFileViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class FileItem
    {
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string LastModified { get; set; }
    }

    public partial class MainView : Window
    {
        private ObservableCollection<FileItem> fileItems;

        public MainView()
        {
            InitializeComponent();
            
            // Initialize the collection
            fileItems = new ObservableCollection<FileItem>();
            
            // Add some sample items
            fileItems.Add(new FileItem 
            { 
                FileName = "application.log",
                FileSize = "1.2 MB",
                LastModified = "2024-03-24 12:30 PM"
            });
            fileItems.Add(new FileItem 
            { 
                FileName = "system.log",
                FileSize = "842 KB",
                LastModified = "2024-03-24 11:45 AM"
            });
            fileItems.Add(new FileItem 
            { 
                FileName = "error.log",
                FileSize = "156 KB",
                LastModified = "2024-03-24 10:15 AM"
            });

            // Set the ListView's ItemsSource
            
            filesListView.ItemsSource = fileItems;
        }

       

        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}