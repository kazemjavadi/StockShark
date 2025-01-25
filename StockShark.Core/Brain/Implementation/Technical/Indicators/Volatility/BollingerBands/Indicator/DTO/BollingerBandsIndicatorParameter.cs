using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volatility.BollingerBands.Indicator.DTO
{
    internal class BollingerBandsIndicatorParameter : ITechnicalIndicatorParameter
    {
        public double[] ClosingPrices { get; set; } = [];
        public int Period { get; set; }
        public int NumStandardDeviations { get; set; }
    }
}
