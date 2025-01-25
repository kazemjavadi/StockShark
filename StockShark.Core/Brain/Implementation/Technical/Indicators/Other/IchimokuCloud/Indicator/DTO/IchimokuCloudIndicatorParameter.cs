using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Other.IchimokuCloud.Indicator.DTO
{
    internal class IchimokuCloudIndicatorParameter : ITechnicalIndicatorParameter
    {
        public double[] Prices { get; set; } = [];
        public int Period { get; set; }
    }
}
