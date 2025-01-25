using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.EMA.Indicator.DTO
{
    public class EmaIndicatorResult : ITechnicalIndicatorResult
    {
        public double[] EmaValues { get; set; } = [];
    }
}
