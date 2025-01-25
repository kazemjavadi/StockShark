using StockShark.ApplicationService.Base;
using StockShark.Contracts.Histories.Repositories;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.FlagsAndPennants.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.FlagsAndPennants.PatternFinder;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.AscendingTriangle.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.AscendingTriangle.PatternFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShark.ApplicationService.Technical.ChartPatterns.AnalyzeAscendingTriangle
{
    public class AnalyzeAscendingTriangleApplicationService : IApplicationService<AnalyzeAscendingTriangleInput, AnalyzeAscendingTriangleOutput>
    {
        private readonly AscendingTrianglePatternFinder _ascendingTrianglePatternFinder;
        private readonly AscendingTriangleAnalyzer _ascendingTriangleAnalyzer;
        private readonly IHistoryRepository _historyRepository;

        public AnalyzeAscendingTriangleApplicationService(AscendingTrianglePatternFinder ascendingTrianglePatternFinder,
            AscendingTriangleAnalyzer ascendingTriangleAnalyzer,
            IHistoryRepository historyRepository)
        {
            _ascendingTrianglePatternFinder = ascendingTrianglePatternFinder;
            _ascendingTriangleAnalyzer = ascendingTriangleAnalyzer;
            _historyRepository = historyRepository;
        }

        public async Task<AnalyzeAscendingTriangleOutput> Execute(AnalyzeAscendingTriangleInput input)
        {
            AnalyzeAscendingTriangleOutput result = new();

            var shareHistory = await _historyRepository.GetHistoryByShareSymbol(new() { Symbol = input.Symbol });

            if (shareHistory is null)
                return result;

            var patterFinderResult = _ascendingTrianglePatternFinder.Recognize(new() { Period = input.Period, Prices = shareHistory.Close });
            var analyzerResult = _ascendingTriangleAnalyzer.Analyze(new() { IsAscendingTriangle = patterFinderResult.IsAscendingTriangle, AscendingTriangleScore = patterFinderResult.AscendingTriangleScore });

            return new() { SignalScore = analyzerResult.SignalScore };

        }
    }
}
