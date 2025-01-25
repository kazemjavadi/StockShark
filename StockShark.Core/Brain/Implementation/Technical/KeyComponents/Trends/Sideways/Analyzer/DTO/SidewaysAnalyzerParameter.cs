using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Sideways.Analyzer.DTO
{
    internal class SidewaysAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public double[] Prices { get; set; } = [];
        public int Period { get; set; }
    }
}
