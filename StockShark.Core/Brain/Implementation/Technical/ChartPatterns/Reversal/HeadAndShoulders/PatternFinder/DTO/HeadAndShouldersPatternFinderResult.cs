using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.HeadAndShoulders.PatternFinder.DTO
{
    internal class HeadAndShouldersPatternFinderResult : ITechnicalPatternFinderResult
    {
        public bool IsHeadAndShoulders { get; set; }
        public double HeadAndShouldersScore { get; set; }
    }
}
