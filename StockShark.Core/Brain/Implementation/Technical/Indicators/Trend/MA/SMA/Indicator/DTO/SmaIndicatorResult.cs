using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.SMA.Indicator.DTO
{
    internal class SmaIndicatorResult : ITechnicalIndicatorResult
    {
        public double[] Result { get; set; } = [];
    }
}
