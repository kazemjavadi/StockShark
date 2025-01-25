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
using StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.EMA.Indicator;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.EMA.Indicator.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShark.ApplicationService.Technical.Indicators.Momentum.Momentumz
{
    public class CalculateMACDApplicationService : IApplicationService<AnalyzeMACDInput, AnalyzeMACDOutput>
    {
        private readonly MacdIndicator _indicator;
        private readonly MacdAnalyzer _analyzer;
        private readonly IHistoryRepository _historyRepository;

        public CalculateMACDApplicationService(MacdIndicator indicator,
            MacdAnalyzer analyzer,
            IHistoryRepository historyRepository)
        {
            _indicator = indicator;
            _analyzer = analyzer;
            _historyRepository = historyRepository;
        }

        public async Task<AnalyzeMACDOutput> Execute(AnalyzeMACDInput input)
        {
            AnalyzeMACDOutput result = new();

            var shareHistory = await _historyRepository.GetHistoryByShareSymbol(new() { Symbol = input.Symbol });

            if (shareHistory is null)
                return result;

            var indicatorResult = _indicator.Calculate(new MacdIndicatorParameter() { ShortEMAPeriod = input.ShortEMAPeriod, 
                LongEMAPeriod = input.LongEMAPeriod, 
                SignalEMAPeriod = input.SignalEMAPeriod, 
                ClosingPrices = shareHistory.Close  });

            var analyzerResult = _analyzer.Analyze(new() { Histogram = indicatorResult.Histogram,
            MacdLine = indicatorResult.MacdLine,
            SignalLine = indicatorResult.SignalLine,
            HistogramAveragePeriod = input.HistogramAveragePeriod, 
            PositiveThreshold = input.PositiveThreshold,
            NegativeThreshold = input.NegativeThreshold});

            return new() { SignalScore = analyzerResult.SignalScore };

        }
    }
}
