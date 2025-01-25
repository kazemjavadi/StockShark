using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.FlagsAndPennants.PatternFinder.DTO
{
    public class FlagsAndPennantsPatternFinderResult : ITechnicalPatternFinderResult
    {
        public bool IsFlagsAndPennants { get; set; }
        public double FlagsAndPennantsScore { get; set; }
    }
}
