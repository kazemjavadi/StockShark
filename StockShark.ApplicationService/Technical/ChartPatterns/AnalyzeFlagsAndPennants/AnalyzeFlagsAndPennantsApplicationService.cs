using StockShark.ApplicationService.Base;
using StockShark.Contracts.Histories.Repositories;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.FlagsAndPennants.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.FlagsAndPennants.PatternFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShark.ApplicationService.Technical.ChartPatterns.AnalyzeFlagsAndPennants
{
    public class AnalyzeFlagsAndPennantsApplicationService : IApplicationService<AnalyzeFlagsAndPennantsInput, AnalyzeFlagsAndPennantsOutput>
    {
        private readonly FlagsAndPennantsPatternFinder _flagsAndPennantsPatternFinder;
        private readonly FlagsAndPennantsAnalyzer _flagsAndPennantsAnalyzer;
        private readonly IHistoryRepository _historyRepository;

        public AnalyzeFlagsAndPennantsApplicationService(FlagsAndPennantsPatternFinder flagsAndPennantsPatternFinder,
            FlagsAndPennantsAnalyzer flagsAndPennantsAnalyzer,
            IHistoryRepository historyRepository)
        {
            _flagsAndPennantsPatternFinder = flagsAndPennantsPatternFinder;
            _flagsAndPennantsAnalyzer = flagsAndPennantsAnalyzer;
            _historyRepository = historyRepository;
        }

        public async Task<AnalyzeFlagsAndPennantsOutput> Execute(AnalyzeFlagsAndPennantsInput input)
        {
            AnalyzeFlagsAndPennantsOutput result = new();

            var shareHistory = await _historyRepository.GetHistoryByShareSymbol(new() { Symbol = input.Symbol });

            if (shareHistory is null)
                return result;

            var patterFinderResult = _flagsAndPennantsPatternFinder.Recognize(new() { Period = input.Period, Prices = shareHistory.Close });
            var analyzerResult = _flagsAndPennantsAnalyzer.Analyze(new() { IsFlagsAndPennants = patterFinderResult.IsFlagsAndPennants, FlagsAndPennantsScore = patterFinderResult.FlagsAndPennantsScore });

            return new() { SignalScore = analyzerResult.SignalScore };

        }
    }
}
