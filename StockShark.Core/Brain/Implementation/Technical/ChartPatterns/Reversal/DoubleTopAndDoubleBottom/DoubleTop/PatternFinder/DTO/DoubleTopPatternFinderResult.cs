using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.DoubleTopAndDoubleBottom.DoubleTop.PatternFinder.DTO
{
    internal class DoubleTopPatternFinderResult : ITechnicalPatternFinderResult
    {
        public bool IsDoubleTop { get; set; }
        public double DoubleTopScore { get; set; }
    }
}
