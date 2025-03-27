using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileViewer
{
    class LogItem
    {
        /// <summary>
        /// LogFilename
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// LogFilesize and Modification Date
        /// </summary>
        public string Description { get; set; }

        //Todo: Adding logic to create a description that converts
        // Filename to Title
        // Size and LastModified to a Description that has the form:
        // Size: 1.2 MB | Modiefied: Today 21:30
        // Size: 842 KB | Modiefied: Yesterday 06:03
        // Size: 156 KB | Modiefied: 2024-03-24 10:15 
        
    }
}
