using LogsDAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogsBL.Interfaces
{
    public interface ILogsService
    {
        Task<List<ResultData>> TakeFiltered(int amount, DateTime from, DateTime to);
        Task CreateBulk(IEnumerable<LogEntity> entity);
        Task CreateBulkFromAsync(IAsyncEnumerable<LogEntity> entities);

    }
}
