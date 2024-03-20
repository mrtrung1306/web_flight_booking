using Libs.EF;
using Libs.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface IFlightsRepository : IRepository<Flights>
    {
        Task<List<Flights>> FindAirport(string departureCode, string arriveCode, string ngayden, int availableSeats);
        Task<List<Flights>> FlightSelection(int id);
        Task changeAvailableSeats(int flightId);
    }
    public class FlightsRepository : RepositoryBase<Flights>,IFlightsRepository
    {
        public FlightsRepository(ModelFlightContext dbcontext) : base(dbcontext)
        {
        }
        public async Task<List<Flights>> FindAirport(string departureCode, string arriveCode, string ngayden,int availableSeats)
        {
            DateTime departureDay = DateTime.ParseExact(ngayden, "dd/M/yyyy", CultureInfo.InvariantCulture);
            return await _dbContext.Flights.Where(m => m.Airports1.AirportCode.Contains(departureCode) && m.Airports.AirportCode.Contains(arriveCode)).Where(m =>m.DepartureDay == departureDay)
                                           .Where(m => m.AvailableSeats >= availableSeats).Include(m=>m.Airports).Include(m => m.Airports1)
                                           .Include(m => m.Fares).Include(m => m.Bookings).Include(m => m.Seats).AsSingleQuery().ToListAsync() ;
        }
        public async Task<List<Flights>> FlightSelection(int id)
        {
            return await _dbContext.Flights.Where(m => m.FlightID == id).Include(m => m.Airports).Include(m => m.Airports1).Include(m => m.Fares).Include(m => m.Bookings).Include(m => m.Seats).ToListAsync() ;
        }
        public async Task changeAvailableSeats(int flightId)
        {
            var flight = await _dbContext.Flights.FindAsync(flightId);
            if(flight != null)
            {
                flight.AvailableSeats--;
            }
            
        }
    }
}
