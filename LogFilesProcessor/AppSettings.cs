using System.Collections.Generic;

namespace LogFilesProcessor
{
    public class AppSettings
    {
        public IDictionary<string, string> ConnectionStrings { get; set; }
        public string LogsCsvFilePath { get; set; }
    }
}
