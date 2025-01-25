using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Other.FibonacciRetracement.Indicator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Other.FibonacciRetracement.Indicator;

internal class FibonacciRetracementIndicator : ITechnicalIndicator<FibonacciRetracementIndicatorResult, FibonacciRetracementIndicatorParameter>
{
    public FibonacciRetracementIndicatorResult Calculate(FibonacciRetracementIndicatorParameter parameter)
    {
        if (parameter.Prices == null || parameter.Prices.Length < parameter.Period)
            throw new ArgumentException($"At least {parameter.Period} prices are required to calculate Fibonacci retracement levels.");

        double high = parameter.Prices.TakeLast(parameter.Period).Max();
        double low = parameter.Prices.TakeLast(parameter.Period).Min();
        double range = high - low;

        var levels = new Dictionary<string, double>
        {
            { "0%", high },
            { "23.6%", high - range * 0.236 },
            { "38.2%", high - range * 0.382 },
            { "50%", high - range * 0.5 },
            { "61.8%", high - range * 0.618 },
            { "100%", low }
        };

        double currentPrice = parameter.Prices.Last();

        return new FibonacciRetracementIndicatorResult
        {
            Levels = levels,
            CurrentPrice = currentPrice,
        };
    }
}
