using DemoMayBayCN.Areas.Admin.ModelView;
using Libs.EF;
using Libs.Entity;
using Libs.ModelViews;
using Libs.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Services
{
    public class AdminService
    {
        public IAirportsRepository airportsRepository;
        private ModelFlightContext modelFlightContext;
        public AdminService(ModelFlightContext context)
        {
            modelFlightContext = context;
            airportsRepository = new AirportsRepository(context);
        }
        public async Task SaveChange()
        {
            await modelFlightContext.SaveChangesAsync();
        }
        public async Task<PageList<Airports>> GetAll(PagingParameters pagingParameters)
        {
            return await airportsRepository.GetAll(pagingParameters);
        }
        public async Task<PageList<Airports>> SearchAirport(string keySearch, PagingParameters pagingParameters)
        {
            return await airportsRepository.SearchAirport(keySearch, pagingParameters);
        }
        public async Task<Airports?> GetAirport(int id)
        {
            return await airportsRepository.GetAirport(id);
        }
        public async Task addAirport(Airports airports)
        {
            await airportsRepository.AddAirport(airports);
            await SaveChange();
        }
        public async Task DeleteAirport(int id)
        {
            await airportsRepository.DeleteAirport(id);
            await SaveChange();
        }
    }
}
