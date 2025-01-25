using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volatility.ATR.Indicator.DTO
{
    internal class AtrIndicatorResult : ITechnicalIndicatorResult
    {
        public double[] AtrValues { get; set; } = [];
    }
}
