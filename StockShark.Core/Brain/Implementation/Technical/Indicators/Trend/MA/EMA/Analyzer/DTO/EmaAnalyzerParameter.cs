using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.EMA.Analyzer.DTO
{
    public class EmaAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public double[] EmaValues { get; set; } = [];
    }
}
