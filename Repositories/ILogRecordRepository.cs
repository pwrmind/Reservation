using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservation.Repositories
{
    public interface ILogRecordRepository
    {
         Task<IEnumerable<LogRecord>> ListAsync();
    }
}