using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.MACD.Indicator.DTO
{
    public class MacdIndicatorResult : ITechnicalIndicatorResult
    {
        public double[] MacdLine { get; set; } = [];
        public double[] SignalLine { get; set; } = [];
        public double[] Histogram { get; set; } = [];
    }
}
