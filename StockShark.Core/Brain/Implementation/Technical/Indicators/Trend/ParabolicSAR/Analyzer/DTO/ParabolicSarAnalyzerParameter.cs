using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.ParabolicSAR.Analyzer.DTO
{
    internal class ParabolicSarAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public double[] SarValues { get; set; } = [];
    }
}
