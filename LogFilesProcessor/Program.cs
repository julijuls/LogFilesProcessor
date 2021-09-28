using CsvHelper;
using LogFilesProcessor.CSVMappers;
using LogFilesProcessor.Models;
using LogFilesProcessor.Services;
using LogsBL.Helpers;
using LogsBL.Interfaces;
using LogsDAL.Entities;
using LogsDAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LogFilesProcessor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configurationFile = File.ReadAllText("appsettings.json");

            var configuration = JsonConvert.DeserializeObject<AppSettings>(configurationFile);


            Console.WriteLine("Start CSV File Reading..");

            LogFileProcessorService _logService = new();

            var resultData = await _logService.ReadCSVFile(configuration.LogsCsvFilePath);
            Console.WriteLine("File read succsessfully!");

            Console.WriteLine("Start to write file in DB..");

            ServiceCollection serviceCollection = new();

            serviceCollection.RegisterLogsBlDependencies(
                new LogsBLDIConfig
                {
                    LogsDBContextConnectionString = configuration.ConnectionStrings["LogsDbContext"]
                });

            var serviceProvider = serviceCollection.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();

            var logsRepository = scope.ServiceProvider.GetService<ILogsService>();

            await logsRepository.CreateBulk(resultData);

            Console.WriteLine("table in DB,check it");
            Console.ReadKey();
        }
    }


}
