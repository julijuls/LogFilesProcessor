using LogsDAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogsDAL.Interfaces
{
    public interface ILogRepository
    {
        Task<IEnumerable<LogEntity>> GetAll();

        Task<LogEntity> Create(LogEntity entity);
        Task<List<ResultData>> TakeFiltered(int amount, DateTime from, DateTime to);
        Task CreateBulk(IEnumerable<LogEntity> entity);

      

    }
}
