using System;
using CsvHelper.Configuration.Attributes;

namespace LogFilesProcessor.Models
{
    public class Logs
    {

        [Name("ip")]
        public string Ip { get; set; }
        [Name("date")]
        public string Date { get; set; }
        [Name("time")]
        public string Time { get; set; }
        [Name("zone")]
        public string Zone { get; set; }
        [Name("cik")]
        public string Cik { get; set; }
        [Name("accession")]
        public string Accession { get; set; }
        [Name("extention")]
        public string Extention { get; set; }
        [Name("code")]
        public string Code { get; set; }
        [Name("size")]
        public string Size { get; set; }
        [Name("idx")]
        public string Idx { get; set; }
        [Name("norefer")]
        public string Norefer { get; set; }
        [Name("noagent")]
        public string Noagent { get; set; }
        [Name("find")]
        public string Find { get; set; }
        [Name("crawler")]
        public string Crawler { get; set; }
        [Name("browser")]
        public string Browser { get; set; }
    }
}
