using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Reservation.Repositories
{
    public class LogRecordRepository : BaseRepository, ILogRecordRepository
    {
        public LogRecordRepository(ReservationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LogRecord>> ListAsync()
        {
            return await _context.LogRecords.ToListAsync();
        }
    }
}