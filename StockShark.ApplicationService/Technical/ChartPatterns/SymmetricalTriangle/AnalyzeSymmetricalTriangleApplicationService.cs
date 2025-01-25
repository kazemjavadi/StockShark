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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShark.ApplicationService.Technical.ChartPatterns.SymmetricalTriangle
{
    public class AnalyzeSymmetricalTriangleApplicationService : IApplicationService<AnalyzeSymmetricalTriangleInput, AnalyzeSymmetricalTriangleOutput>
    {
        private readonly SymmetricalTrianglePatternFinder _patternFinder;
        private readonly SymmetricalTriangleAnalyzer _analyzer;
        private readonly IHistoryRepository _historyRepository;

        public AnalyzeSymmetricalTriangleApplicationService(SymmetricalTrianglePatternFinder patternFinder,
            SymmetricalTriangleAnalyzer analyzer,
            IHistoryRepository historyRepository)
        {
            _patternFinder = patternFinder;
            _analyzer = analyzer;
            _historyRepository = historyRepository;
        }

        public async Task<AnalyzeSymmetricalTriangleOutput> Execute(AnalyzeSymmetricalTriangleInput input)
        {
            AnalyzeSymmetricalTriangleOutput result = new();

            var shareHistory = await _historyRepository.GetHistoryByShareSymbol(new() { Symbol = input.Symbol });

            if (shareHistory is null)
                return result;

            var patterFinderResult = _patternFinder.Recognize(new() { Period = input.Period, Prices = shareHistory.Close });
            var analyzerResult = _analyzer.Analyze(new() { IsSymmetricalTriangle = patterFinderResult.IsDescendingTriangle, SymmetricalTriangleScore = patterFinderResult.DescendingTriangleScore });

            return new() { SignalScore = analyzerResult.SignalScore };

        }
    }
}
