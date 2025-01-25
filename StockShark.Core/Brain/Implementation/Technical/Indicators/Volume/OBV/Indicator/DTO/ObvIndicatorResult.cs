using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volume.OBV.Indicator.DTO
{
    internal class ObvIndicatorResult : ITechnicalIndicatorResult
    {
        public double[] ObvValues { get; set; } = [];
    }
}
