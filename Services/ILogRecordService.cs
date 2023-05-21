using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservation.Services
{
    public interface ILogRecordService
    {
        Task<IEnumerable<LogRecord>> ListAsync();
    }
}