using StockShark.ApplicationService.Base;
using StockShark.Contracts.Histories.Repositories;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.FlagsAndPennants.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.FlagsAndPennants.PatternFinder;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.AscendingTriangle.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.AscendingTriangle.PatternFinder;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.DescendingTriangle.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.DescendingTriangle.PatternFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShark.ApplicationService.Technical.ChartPatterns.DescendingTriangle
{
    public class AnalyzeDescendingTriangleApplicationService : IApplicationService<AnalyzeDescendingTriangleInput, AnalyzeDescendingTriangleOutput>
    {
        private readonly DescendingTrianglePatternFinder _descendingTrianglePatternFinder;
        private readonly DescendingTriangleAnalyzer descendingTriangleAnalyzer;
        private readonly IHistoryRepository _historyRepository;

        public AnalyzeDescendingTriangleApplicationService(DescendingTrianglePatternFinder descendingTrianglePatternFinder,
            DescendingTriangleAnalyzer descendingTriangleAnalyzer,
            IHistoryRepository historyRepository)
        {
            _descendingTrianglePatternFinder = descendingTrianglePatternFinder;
            this.descendingTriangleAnalyzer = descendingTriangleAnalyzer;
            _historyRepository = historyRepository;
        }

        public async Task<AnalyzeDescendingTriangleOutput> Execute(AnalyzeDescendingTriangleInput input)
        {
            AnalyzeDescendingTriangleOutput result = new();

            var shareHistory = await _historyRepository.GetHistoryByShareSymbol(new() { Symbol = input.Symbol });

            if (shareHistory is null)
                return result;

            var patterFinderResult = _descendingTrianglePatternFinder.Recognize(new() { Period = input.Period, Prices = shareHistory.Close });
            var analyzerResult = descendingTriangleAnalyzer.Analyze(new() { IsDescendingTriangle = patterFinderResult.IsDescendingTriangle, DescendingTriangleScore = patterFinderResult.DescendingTriangleScore });

            return new() { SignalScore = analyzerResult.SignalScore };

        }
    }
}
