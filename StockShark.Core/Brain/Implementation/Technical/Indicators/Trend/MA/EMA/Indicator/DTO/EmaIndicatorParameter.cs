using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.EMA.Indicator.DTO
{
    public class EmaIndicatorParameter : ITechnicalIndicatorParameter
    {
        public double[] ClosingPrices { get; set; } = [];
        public int Period { get; set; }
    }
}
