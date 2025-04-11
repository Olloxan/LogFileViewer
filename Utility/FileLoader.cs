using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace LogFileViewer
{
    internal class FileLoader
    {
        internal async static Task<ObservableCollection<LogItem>> GetLogItems(string fileName)
        {
            if(!File.Exists(fileName))
                throw new FileNotFoundException($"File {fileName} not found");

            string[] lines = await File.ReadAllLinesAsync(fileName);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true
            };
            var collection = new ObservableCollection<LogItem>();

            // check for Message or error and Deserialize into a Logmessage or 
            // log error item
            // There is a chatgpt chat for that
            foreach (string line in lines)
            {
                string temp = line.Substring(0, line.Length - 1);
                var knille = JsonSerializer.Deserialize<LogItem>(temp, options);
                if (knille != null)
                    collection.Add(knille);
            }
            
            return collection;
        }
    }
}
