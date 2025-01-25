using Microsoft.EntityFrameworkCore;
using StockShark.Contracts.Histories.Repositories;
using StockShark.Core.Entities;
using StockShark.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StockShark.Repository.Histories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly StockSharkDbContext _dbContext;

        public HistoryRepository(StockSharkDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddAsync(History entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task<History?> GetHistoryByShareId(GetHistoryByShareIdQuery query)
        {
            return await _dbContext.Histories.Where(h => h.ShareId == query.ShareId)
                 .FirstOrDefaultAsync();
        }

        public async Task<GetHistoryResult?> GetHistoryByShareSymbol(GetHistoryByShareSymbolQuery query)
        {
            var shareId = await _dbContext.Shares.Where(s => s.Symbol == query.Symbol.Trim())
                .Select(s => s.Id).FirstOrDefaultAsync();

            var history = await _dbContext.Histories.Where(h => h.ShareId == shareId)
                 .FirstOrDefaultAsync();

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.PropertyNameCaseInsensitive = true;

            return JsonSerializer.Deserialize<GetHistoryResult>(history?.HistoryJson ?? string.Empty,jsonSerializerOptions);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
