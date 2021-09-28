using CsvHelper;
using LogFilesProcessor.CSVMappers;
using LogFilesProcessor.Models;
using LogsDAL.Entities;

using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogFilesProcessor.Services
{
    public class LogFileProcessorService
    {
        public async Task<IEnumerable<LogEntity>> ReadCSVFile(string location)
        {

            using var reader = new StreamReader(location, Encoding.Default);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Context.RegisterClassMap<LogsMap>();
            return await csv.GetRecordsAsync<Logs>()
                .Select(log => new LogEntity
                {
                    Ip = log.Ip,
                    DateTimeRequest = DateTime.TryParse(string.Join(" ", log.Date, log.Time), CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out var date) ? date : DateTime.MinValue,
                    Code = double.TryParse(log.Code, NumberStyles.Float, CultureInfo.InvariantCulture, out var code) ? code : default,
                    Size = double.TryParse(log.Size, NumberStyles.Float, CultureInfo.InvariantCulture, out var size) ? size : default,
                    //CountryCode = GetCountryCode(log.Ip)
                })
                .ToListAsync();
        }
        //private async Task<string> GetCountryCode(string ip)
        //{
        //    //string ip_res = ip.Split(".");
        //    ip = ip.Remove(ip.Length - 3) + "1";
        //    //string[] values = ip.Split('.');
        //    //string res=values[0]+"."+values[1]+"."+values[2]+".1" ;
        //    //string info = new WebClient().DownloadString("http://www.geoplugin.net/json.gp?ip=" + res);


        //    var client = new RestClient("http://www.geoplugin.net/");


        //    var request = new RestRequest("json.gp?ip=" + ip, DataFormat.Json);

        //    var response = await client.ExecuteAsync<CountryResponse>(request);

        //    return "UA";

        //}

    }
}
