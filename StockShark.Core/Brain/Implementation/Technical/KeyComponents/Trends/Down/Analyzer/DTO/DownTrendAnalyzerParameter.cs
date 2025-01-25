using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Down.Analyzer.DTO
{
    internal class DownTrendAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public double[] Prices { get; set; } = [];
        public bool IsDowntrend { get; set; }
        public int Period { get; set; }
    }
}
