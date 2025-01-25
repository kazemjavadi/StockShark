using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.DoubleTopAndDoubleBottom.DoubleBottom.PatternFinder.DTO
{
    internal class DoubleBottomPatternFinderParameter : ITechnicalPatternFinderParameter
    {
        public double[] Prices { get; set; } = [];
        public int Period { get; set; }
    }
}
