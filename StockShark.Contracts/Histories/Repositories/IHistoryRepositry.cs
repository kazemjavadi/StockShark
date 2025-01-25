using StockShark.Contracts.Base;
using StockShark.Core.Entities;

namespace StockShark.Contracts.Histories.Repositories
{
    public interface IHistoryRepository : BaseRepository<History>
    {
        Task<History?> GetHistoryByShareId(GetHistoryByShareIdQuery query);
        Task<GetHistoryResult?> GetHistoryByShareSymbol(GetHistoryByShareSymbolQuery query);
    }
}
