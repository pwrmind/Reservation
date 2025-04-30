using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Reservation.Repositories;
using System.Threading.Tasks;

namespace Reservation.Services
{
    /// <summary>
    /// Service responsible for managing log records in the system.
    /// Handles the retrieval and storage of system activity logs.
    /// </summary>
    public class LogRecordService : ILogRecordService
    {
        private readonly ILogRecordRepository _logRecordRepository;

        /// <summary>
        /// Initializes a new instance of the LogRecordService
        /// </summary>
        /// <param name="logRecordRepository">The repository used for data access</param>
        public LogRecordService(ILogRecordRepository logRecordRepository)
        {
            _logRecordRepository = logRecordRepository;
        }
        
        /// <summary>
        /// Retrieves all log records from the system
        /// </summary>
        /// <returns>A collection of all log records</returns>
        public async Task<IEnumerable<LogRecord>> ListAsync()
        {
            return await _logRecordRepository.ListAsync();
        }
    }
}