using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.SMA.Analyzer.DTO
{
    internal class SmaAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public double[] ClosingPrices { get; set; } = [];
        public double[] SmaData { get; set; } = [];
        public int Period { get; set; }
    }
}
