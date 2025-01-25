using StockShark.Contracts.Base;

namespace StockShark.Contracts.Histories.EternalServices
{
    public interface IHistoryExternalService
    {
        Task<string?> GetHistory(GetHistoryExternalServiceQuery query);
    }
}
