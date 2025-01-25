using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volume.VPT.Indicator.DTO
{
    internal class VptIndicatorParameter : ITechnicalIndicatorParameter
    {
        public double[] ClosingPrices { get; set; } = [];
        public long[] Volumes { get; set; } = [];
    }
}
