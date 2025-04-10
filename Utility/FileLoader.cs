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
            foreach (string line in lines)
            {
                string temp = line.Substring(0, line.Length - 1);
                collection.Add(JsonSerializer.Deserialize<LogItem>(temp, options));
            }
            
            return collection;
        }
    }
}
