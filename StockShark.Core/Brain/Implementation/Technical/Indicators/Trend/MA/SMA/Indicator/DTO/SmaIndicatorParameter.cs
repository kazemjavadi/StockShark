using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.SMA.Indicator.DTO
{
    internal class SmaIndicatorParameter : ITechnicalIndicatorParameter
    {
        public Dictionary<DateTime, double> StockData { get; set; } = [];
        public int Period { get; set; }
    }
}
