using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.HeadAndShoulders.PatternFinder.DTO
{
    internal class HeadAndShouldersPatternFinderParameter : ITechnicalPatternFinderParameter
    {
        public double[] Prices { get; set; } = [];
        public int Period { get; set; }
    }
}
