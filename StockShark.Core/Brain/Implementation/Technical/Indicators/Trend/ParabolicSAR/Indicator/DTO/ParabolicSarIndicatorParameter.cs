using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.ParabolicSAR.Indicator.DTO
{
    internal class ParabolicSARIndicatorParameter : ITechnicalIndicatorParameter
    {
        public double[] HighPrices { get; set; } = [];
        public double[] LowPrices { get; set; } = [];
        public double AccelerationFactor { get; set; }
        public double MaxAccelerationFactor { get; set; }
    }
}
