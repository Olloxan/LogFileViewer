namespace LogFileViewer
{
    public class LogItem
    {
        /// <summary>
        /// LogFilename
        /// </summary>
        public string? Time { get; set; } = string.Empty;

        /// <summary>
        /// LogFilesize and Modification Date
        /// </summary>
        public string? Module { get; set; } = string.Empty;

    }

    public class MessageLogItem : LogItem
    {
       
        public string? Message { get; set; } = string.Empty;    
                
    }

    public class ErrorLogItem : LogItem
    {
        public string? Error { get; set; } = string.Empty;

        public string? Exception { get; set; } = string.Empty;
    }
}
