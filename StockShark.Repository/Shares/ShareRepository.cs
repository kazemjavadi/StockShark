using Microsoft.EntityFrameworkCore;
using StockShark.Contracts.Shares.Repository;
using StockShark.Core.Entities;
using StockShark.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShark.Repository.Shares
{
    public class ShareRepository : IShareRepository
    {
        private readonly StockSharkDbContext _dbcontext;

        public ShareRepository(StockSharkDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public async Task AddAsync(Share entity)
        {
            await _dbcontext.AddAsync(entity);
        }

        public async Task<GetShareBySymbolResult?> GetShareBySymbol(GetShareBySymbolQuery query)
        {
            var result = await _dbcontext.Shares.Where(s => s.Symbol == query.Symbol)
                  .Select(i => new GetShareBySymbolResult { Id = i.Id }).FirstOrDefaultAsync();

            return result;
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
