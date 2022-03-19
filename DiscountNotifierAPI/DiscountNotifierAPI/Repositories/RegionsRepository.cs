using System.Collections.Generic;
using System.Threading.Tasks;
using DiscountNotifierAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscountNotifierAPI.Repositories
{
    public interface IRegionsRepository
    {
        Task<IEnumerable<Region>> GetRegions();
        Task<Region> GetRegion(int regionId);
    }

    public class RegionsRepository : IRegionsRepository
    {
        private readonly AppDbContext _appDbContext;    

        public RegionsRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<Region> GetRegion(int regionId)
        {
            return await _appDbContext.Regions.FirstOrDefaultAsync(r => r.RegionId == regionId);
        }

        public async Task<IEnumerable<Region>> GetRegions()
        {
            return await _appDbContext.Regions.ToListAsync();
        }
    }
}
