using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volume.VPT.Indicator.DTO
{
    internal class VptIndicatorResult : ITechnicalIndicatorResult
    {
        public double[] VptValues { get; set; } = [];
    }
}
