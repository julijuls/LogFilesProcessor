using FastMember;
using LogsDAL.DBContext;
using LogsDAL.Entities;
using LogsDAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LogsDAL.Services
{
    public class LogRepository : ILogRepository
    {
        private readonly LogsDbContext _appDbContext;
    

        public LogRepository(LogsDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<LogEntity> Create(LogEntity entity)
        {
            var newEntity = await _appDbContext.AddAsync(entity);

            await _appDbContext.SaveChangesAsync();

            return newEntity.Entity;
        }

        public async Task<IEnumerable<LogEntity>> GetAll() => await _appDbContext.Logs.ToListAsync();

        public async Task<List<ResultData>> TakeFiltered(int amount, DateTime from, DateTime to) => await _appDbContext.Logs
            .Where(log => from <= log.DateTimeRequest && log.DateTimeRequest <= to)
            .GroupBy(log => log.Ip)
            .Select(group => new ResultData { IP = group.Key, Count = group.Count() })
            .OrderByDescending(data => data.Count)
            .Take(amount)
            .ToListAsync();

        public async Task CreateBulk(IEnumerable<LogEntity> entity)
        {
            await _appDbContext.AddRangeAsync(entity);

            await _appDbContext.SaveChangesAsync();
        }

        
        

        
    }
}
