using StockShark.ApplicationService.Base;
using StockShark.Contracts.Histories.Repositories;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.FlagsAndPennants.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.FlagsAndPennants.PatternFinder;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.AscendingTriangle.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.AscendingTriangle.PatternFinder;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.DescendingTriangle.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.DescendingTriangle.PatternFinder;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.SymmetricalTriangle.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.SymmetricalTriangle.PatternFinder;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.MACD.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.MACD.Indicator;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.MACD.Indicator.DTO;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.RSI.Indicator;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.RSI.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.EMA.Indicator;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.EMA.Indicator.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockShark.ApplicationService.Technical.Indicators.Momentum.Momentum;

namespace StockShark.ApplicationService.Technical.Indicators.Momentum.Momentumz
{
    public class CalculateRSIApplicationService : IApplicationService<AnalyzeRSIInput, AnalyzeRSIOutput>
    {
        private readonly RsiIndicator _indicator;
        private readonly RsiAnalyzer _analyzer;
        private readonly IHistoryRepository _historyRepository;

        public CalculateRSIApplicationService(RsiIndicator indicator,
            RsiAnalyzer analyzer,
            IHistoryRepository historyRepository)
        {
            _indicator = indicator;
            _analyzer = analyzer;
            _historyRepository = historyRepository;
        }

        public async Task<AnalyzeRSIOutput> Execute(AnalyzeRSIInput input)
        {
            AnalyzeRSIOutput result = new();

            var shareHistory = await _historyRepository.GetHistoryByShareSymbol(new() { Symbol = input.Symbol });

            if (shareHistory is null)
                return result;

            var indicatorResult = _indicator.Calculate(new()
            {
                HistoricalClosingPrices = shareHistory.Close,
                LookbackPeriod = input.LookbackPeriod
            });

            var analyzerResult = _analyzer.Analyze(new() { RsiValues = indicatorResult.Rsi});

            return new() { SignalScore = analyzerResult.SignalScore };

        }
    }
}
