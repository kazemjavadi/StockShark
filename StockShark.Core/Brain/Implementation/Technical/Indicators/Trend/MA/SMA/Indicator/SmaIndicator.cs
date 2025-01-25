using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.SMA.Indicator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.SMA.Indicator
{
    internal class SmaIndicator : ITechnicalIndicator<SmaIndicatorResult, SmaIndicatorParameter>
    {
        public SmaIndicatorResult Calculate(SmaIndicatorParameter parameter)
        {
            var closingPrices = parameter.StockData.Values.ToList();
            List<double> smaList = [];

            for (int i = 0; i <= closingPrices.Count - parameter.Period; i++)
            {
                double sma = closingPrices.Skip(i).Take(parameter.Period).Average();
                smaList.Add(sma);
            }

            return new SmaIndicatorResult { Result = [.. smaList] };
        }
    }
}
