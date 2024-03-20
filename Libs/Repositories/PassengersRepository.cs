using Libs.EF;
using Libs.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface IPassengerRepository : IRepository<Passengers>
    {
        Task insertPassenger(Passengers passengers);
    }
    public class PassengersRepository : RepositoryBase<Passengers>, IPassengerRepository
    {
        public PassengersRepository(ModelFlightContext dbContext) : base(dbContext)
        {
        }
        public async Task insertPassenger(Passengers passengers)
        {
            await _dbContext.AddAsync(passengers);
        }
    }
}
