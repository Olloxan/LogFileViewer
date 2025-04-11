namespace LogFileViewer
{
    public class FileItem
    {
        public string? FileName { get; set; }
        public string? FileSize { get; set; }
        public string? LastModified { get; set; }
        public string? FullPath { get; set; }
        public bool HasErrors { get; set; }
    }
} 