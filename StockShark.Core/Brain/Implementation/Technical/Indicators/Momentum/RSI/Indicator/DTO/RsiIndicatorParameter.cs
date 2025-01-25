using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.RSI.Indicator.DTO
{
    public class RsiIndicatorParameter : ITechnicalIndicatorParameter
    {
        public double[] HistoricalClosingPrices { get; set; } = [];
        public int LookbackPeriod { get; set; } = 14;
    }
}
