using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volatility.BollingerBands.Indicator.DTO
{
    internal class BollingerBandsIndicatorResult : ITechnicalIndicatorResult
    {
        public double[] MiddleBand { get; set; } = [];
        public double[] UpperBand { get; set; } = [];
        public double[] LowerBand { get; set; } = [];
    }
}
