using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Up.Analyzer.DTO
{
    internal class UpTrendAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public bool IsUptrend { get; set; }
        public double[] Prices { get; set; } = [];
        public int Period { get; set; }
    }
}
