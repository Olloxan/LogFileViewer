using Caliburn.Micro;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows;

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

        public MainViewModel()
        {
            
        }

        public void SelectFolder()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select a folder containing log files";
                dialog.UseDescriptionForTitle = true; // This property is available in .NET 5+ for a better UX
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SelectedFolderPath = dialog.SelectedPath;
                    // TODO: Load log files from the selected folder
                }
            }
        }
    }
} 