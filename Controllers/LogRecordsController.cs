using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reservation.Services;

namespace Reservation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogRecordsController : ControllerBase
    {
        private readonly ILogRecordService _logRecordService;
        
        public LogRecordsController(ILogRecordService logRecordService)
        {
            _logRecordService = logRecordService;   
        }

        [HttpGet]
        public async Task<IEnumerable<LogRecord>> GetAllAsync()
        {
            return await _logRecordService.ListAsync();;
        }
    }
}
