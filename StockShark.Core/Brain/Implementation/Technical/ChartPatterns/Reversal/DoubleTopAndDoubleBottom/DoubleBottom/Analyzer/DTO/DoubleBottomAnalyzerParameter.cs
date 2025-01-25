using StockShark.Core.Brain.Base.Technical;
namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.DoubleTopAndDoubleBottom.DoubleBottom.Analyzer.DTO
{
    internal class DoubleBottomAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public bool IsDoubleBottom { get; set; }
        public double DoubleBottomScore { get; set; }
    }
}
