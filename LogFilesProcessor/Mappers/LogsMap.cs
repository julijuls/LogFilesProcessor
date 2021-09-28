using CsvHelper.Configuration;
using LogFilesProcessor.Models;

namespace LogFilesProcessor.CSVMappers
{
    public class LogsMap : ClassMap<Logs>
    {
        public LogsMap()
        {
            Map(x => x.Ip).Name("ip");
            Map(x => x.Date).Name("date");
            Map(x => x.Time).Name("time");
            Map(x => x.Size).Name("size");
            Map(x => x.Code).Name("code");

        }
    }
}
