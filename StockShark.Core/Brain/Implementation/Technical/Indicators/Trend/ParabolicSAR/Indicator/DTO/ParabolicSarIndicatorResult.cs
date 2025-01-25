using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.ParabolicSAR.Indicator.DTO
{
    internal class ParabolicSARIndicatorResult : ITechnicalIndicatorResult
    {
        public double[] SarValues { get; set; } = [];
    }
}
