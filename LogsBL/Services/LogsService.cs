using LogsBL.Interfaces;
using LogsDAL.Entities;
using LogsDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsBL.Services
{
    public class LogsService : ILogsService
    {
        private readonly ILogRepository _logRepository;

        public LogsService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task CreateBulk(IEnumerable<LogEntity> entity)
        {
            await _logRepository.CreateBulk(entity);
        }

        public async Task CreateBulkFromAsync(IAsyncEnumerable<LogEntity> entities)
        {
            var allIps = await entities.Select(entity =>
            {
                var ipSegments = entity.Ip
                .Split('.')
                .Take(3);
                return string.Join(".", ipSegments, "0");

        }).ToListAsync();



            var entitiesWithCountryCodes = await entities.Select(entity =>
            {
                return entity;
            })
                .ToListAsync();


            await _logRepository.CreateBulk(entitiesWithCountryCodes);
        }

        public async Task<List<ResultData>> TakeFiltered(int amount, DateTime from, DateTime to)
        {
            return await _logRepository.TakeFiltered(amount, from, to);
        }
    }
}
