using LogsBL.Interfaces;
using LogsDAL.Entities;
using LogsDAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogsAPI.Controllers
{
    [Route("api/logs")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogsService _logsService;

        public LogsController(ILogsService logsService)
        {
            _logsService = logsService;
        }

        [HttpGet]
        public async Task<List<ResultData>> Take(int amount, DateTime from, DateTime to)
        {

            return await _logsService.TakeFiltered(amount, from, to);
        }

    }
}
