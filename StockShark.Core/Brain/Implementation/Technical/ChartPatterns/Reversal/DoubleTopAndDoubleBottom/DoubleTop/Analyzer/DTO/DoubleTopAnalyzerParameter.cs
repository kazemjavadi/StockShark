using StockShark.Core.Brain.Base.Technical;
namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.DoubleTopAndDoubleBottom.DoubleTop.Analyzer.DTO
{
    internal class DoubleTopAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public bool IsDoubleTop { get; set; }
        public double DoubleTopScore { get; set; }
    }
}
