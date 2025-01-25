using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volume.OBV.Indicator.DTO
{
    internal class ObvIndicatorParameter : ITechnicalIndicatorParameter
    {
        public double[] ClosingPrices { get; set; } = [];
        public long[] Volumes { get; set; } = [];
    }
}
