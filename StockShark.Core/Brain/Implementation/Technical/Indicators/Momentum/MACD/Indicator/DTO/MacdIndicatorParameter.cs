using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.MACD.Indicator.DTO
{
    public class MacdIndicatorParameter : ITechnicalIndicatorParameter
    {
        public double[] ClosingPrices { get; set; } = [];
        public int ShortEMAPeriod { get; set; } = 12;
        public int LongEMAPeriod { get; set; } = 26;
        public int SignalEMAPeriod { get; set; } = 9;
    }
}
