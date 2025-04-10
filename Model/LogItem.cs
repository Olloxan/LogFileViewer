using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileViewer
{
    public class LogItem
    {
        /// <summary>
        /// LogFilename
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// LogFilesize and Modification Date
        /// </summary>
        public string Module { get; set; }


        public string Message { get; set; }

        public string Error { get; set; }

        public string Exception { get; set; }

        
    }
}
