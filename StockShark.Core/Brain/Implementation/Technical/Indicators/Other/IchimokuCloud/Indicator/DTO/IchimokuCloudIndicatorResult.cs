using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Other.IchimokuCloud.Indicator.DTO
{
    internal class IchimokuCloudIndicatorResult : ITechnicalIndicatorResult
    {
        public double TenkanSen { get; set; }
        public double KijunSen { get; set; }
        public double SenkouSpanA { get; set; }
        public double SenkouSpanB { get; set; }
        public double ChikouSpan { get; set; }
        public double CurrentPrice { get; set; }
    }
}
