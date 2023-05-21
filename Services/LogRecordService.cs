using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Reservation.Repositories;
using System.Threading.Tasks;

namespace Reservation.Services
{
    public class LogRecordService : ILogRecordService
    {
        private readonly ILogRecordRepository _logRecordRepository;

        public LogRecordService(ILogRecordRepository logRecordRepository)
        {
            _logRecordRepository = logRecordRepository;
        }
        
        public async Task<IEnumerable<LogRecord>> ListAsync()
        {
            return await _logRecordRepository.ListAsync();
        }
    }
}