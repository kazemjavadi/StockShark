using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Other.IchimokuCloud.Indicator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Other.IchimokuCloud.Indicator;

internal class IchimokuCloudIndicator : ITechnicalIndicator<IchimokuCloudIndicatorResult, IchimokuCloudIndicatorParameter>
{
    public IchimokuCloudIndicatorResult Calculate(IchimokuCloudIndicatorParameter parameter)
    {
        if (parameter.Prices == null || parameter.Prices.Length < 52)
            throw new ArgumentException("At least 52 prices are required to calculate Ichimoku Cloud.");

        int period9 = parameter.Period < 9 ? parameter.Period : 9;
        int period26 = parameter.Period < 26 ? parameter.Period : 26;
        int period52 = parameter.Period < 52 ? parameter.Period : 52;

        double tenkanSen = (parameter.Prices.TakeLast(period9).Max() + parameter.Prices.TakeLast(period9).Min()) / 2;
        double kijunSen = (parameter.Prices.TakeLast(period26).Max() + parameter.Prices.TakeLast(period26).Min()) / 2;
        double senkouSpanA = (tenkanSen + kijunSen) / 2;
        double senkouSpanB = (parameter.Prices.TakeLast(period52).Max() + parameter.Prices.TakeLast(period52).Min()) / 2;
        double chikouSpan = parameter.Prices.ElementAt(parameter.Prices.Length - period26);

        double currentPrice = parameter.Prices.Last();


        return new IchimokuCloudIndicatorResult
        {
            TenkanSen = tenkanSen,
            KijunSen = kijunSen,
            SenkouSpanA = senkouSpanA,
            SenkouSpanB = senkouSpanB,
            ChikouSpan = chikouSpan,
            CurrentPrice = currentPrice,
        };
    }
}
