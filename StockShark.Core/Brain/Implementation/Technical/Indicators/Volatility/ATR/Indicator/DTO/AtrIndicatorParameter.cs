using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volatility.ATR.Indicator.DTO
{
    internal class AtrIndicatorParameter : ITechnicalIndicatorParameter
    {
        public double[] HighPrices { get; set; } = [];
        public double[] LowPrices { get; set; } = [];
        public int Period { get; set; }
    }
}
