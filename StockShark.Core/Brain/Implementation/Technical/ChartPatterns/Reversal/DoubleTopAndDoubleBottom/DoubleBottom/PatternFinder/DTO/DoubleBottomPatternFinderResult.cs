using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.DoubleTopAndDoubleBottom.DoubleBottom.PatternFinder.DTO
{
    internal class DoubleBottomPatternFinderResult : ITechnicalPatternFinderResult
    {
        public bool IsDoubleBottom { get; set; }
        public double DoubleBottomScore { get; set; }
    }
}
