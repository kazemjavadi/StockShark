using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volatility.ATR.Analyzer.DTO
{
    internal class AtrAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public double[] AtrValues { get; set; } = [];
    }
}
