using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscountNotifierAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscountNotifierAPI.Repositories
{
    public interface IBeaconsRepository
    {
        Task<IEnumerable<Beacon>> GetBeacons();
    }

    public class BeaconsRepository : IBeaconsRepository
    {
        private readonly AppDbContext _appDbContext;    

        public BeaconsRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Beacon>> GetBeacons()
        {
            return await _appDbContext.Beacons
                            .Include(b => b.AssociatedRegion)
                            .ToListAsync();
        }
    }
}
