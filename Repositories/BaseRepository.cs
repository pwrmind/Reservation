
namespace Reservation.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ReservationContext _context;

        public BaseRepository(ReservationContext context)
        {
            _context = context;
        }
    }
}