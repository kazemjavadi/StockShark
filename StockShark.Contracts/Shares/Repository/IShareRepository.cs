using StockShark.Contracts.Base;
using StockShark.Core.Entities;

namespace StockShark.Contracts.Shares.Repository
{
    public interface IShareRepository : BaseRepository<Share>
    {
        public Task<GetShareBySymbolResult?> GetShareBySymbol(GetShareBySymbolQuery query);
    }
}
