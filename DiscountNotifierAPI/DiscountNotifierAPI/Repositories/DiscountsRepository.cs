﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountNotifierAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscountNotifierAPI.Repositories
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<Discount>> GetDiscounts();
        Task<Discount> GetDiscount(int discountId);
        Task<IEnumerable<Discount>> GetDiscountsByRegion(int regionId);
    }

    public class DiscountsRepository : IDiscountRepository
    {
        private readonly AppDbContext _appDbContext;    

        public DiscountsRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<Discount> GetDiscount(int discountId)
        {
            return await _appDbContext.Discounts.FirstOrDefaultAsync(d => d.Id == discountId);
        }

        public async Task<IEnumerable<Discount>> GetDiscounts()
        {
            return await _appDbContext.Discounts.ToListAsync();
        }

        public async Task<IEnumerable<Discount>> GetDiscountsByRegion(int regionId)
        {
            return await _appDbContext.Discounts
                    .Where(d => d.RegionId == regionId)
                    .Include(d => d.AssociatedRegion)
                    .ToListAsync();
        }
    }
}