using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.RSI.Analyzer.DTO
{
    public class RsiAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public double[] RsiValues { get; set; } = [];
    }
}
