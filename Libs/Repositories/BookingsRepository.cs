using Libs.EF;
using Libs.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface IBookingsRepository : IRepository<Bookings>
    {
        Task insertBooking(Bookings bookings);
        Task<List<Bookings>> searchTicket(string searchString);
    }
    public class BookingsRepository : RepositoryBase<Bookings>, IBookingsRepository
    {
        public BookingsRepository(ModelFlightContext dbContext) : base(dbContext)
        {
        }
        public async Task insertBooking(Bookings bookings)
        {
            await _dbContext.Bookings.AddAsync(bookings);
        }
        public async Task<List<Bookings>> searchTicket(string searchString)
        {
            return await _dbContext.Bookings.Where(m => m.Verification == searchString).Include(m => m.Flights).Include(m => m.Flights.Airports).Include(m => m.Flights.Airports1).Include(m => m.Passengers).Include(m => m.Seats).ToListAsync();
        }
    }
}
