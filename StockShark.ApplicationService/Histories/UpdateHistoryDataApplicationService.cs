using StockShark.ApplicationService.Base;
using StockShark.Contracts.Histories.EternalServices;
using StockShark.Contracts.Histories.Repositories;
using StockShark.Contracts.Shares.Repository;
using StockShark.Core.Entities;

namespace StockShark.ApplicationService.Histories
{
    public class UpdateHistoryDataApplicationService : IApplicationService<UpdateHistoryDataInput, UpdateHistoryOutput>
    {
        private readonly IHistoryExternalService _historyExternalService;
        private readonly IHistoryRepository _historyRepository;
        private readonly IShareRepository _shareRepository;

        public UpdateHistoryDataApplicationService(IHistoryExternalService historyExternalService,
            IHistoryRepository historyRepository,
            IShareRepository shareRepository)
        {
            this._historyExternalService = historyExternalService;
            this._historyRepository = historyRepository;
            this._shareRepository = shareRepository;
        }

        public async Task<UpdateHistoryOutput> Execute(UpdateHistoryDataInput input)
        {
            foreach (var symbol in input.Symbols)
            {
                var shareInfo = await _shareRepository.GetShareBySymbol(new() { Symbol = symbol });

                if (shareInfo == null) continue; //don't continue

                var shareHistory = await _historyRepository.GetHistoryByShareId(new() { ShareId = shareInfo.Id });

                var latestHistory = await _historyExternalService.GetHistory(new() { From = input.From, To = input.To, Symbol = symbol });

                if (string.IsNullOrWhiteSpace(latestHistory)) continue; //don't continue

                if (shareHistory == null)
                {
                    History history = new History()
                    {
                        ShareId = shareInfo.Id,
                        HistoryJson = latestHistory
                    };

                    await _historyRepository.AddAsync(history);
                }
                else
                {
                    shareHistory.HistoryJson = latestHistory;
                    shareHistory.LastModifiedDateTime = DateTime.Now;
                }
            }

            await _historyRepository.SaveChangesAsync();
            return new();
        }
    }
}
