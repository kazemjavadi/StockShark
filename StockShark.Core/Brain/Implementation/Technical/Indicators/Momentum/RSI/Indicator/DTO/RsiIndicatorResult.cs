using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.RSI.Indicator.DTO
{
    public class RsiIndicatorResult : ITechnicalIndicatorResult
    {
        public double[] Rsi { get; set; } = [];
    }
}
