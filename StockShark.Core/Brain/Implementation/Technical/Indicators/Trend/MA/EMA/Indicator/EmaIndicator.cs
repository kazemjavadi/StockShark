using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.EMA.Indicator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.EMA.Indicator
{
    public class EmaIndicator : ITechnicalIndicator<EmaIndicatorResult, EmaIndicatorParameter>
    {
        public EmaIndicatorResult Calculate(EmaIndicatorParameter parameter)
        {
            List<double> emaValues = [];

            if (parameter.ClosingPrices.Length < parameter.Period || parameter.Period <= 0)
            {
                throw new ArgumentException("Invalid period or insufficient data points.");
            }

            double smoothingFactor = 2 / (parameter.Period + 1);

            // Calculate the initial SMA (Simple Moving Average) as the sum of the first 'period' closing prices divided by 'period'
            double sum = 0;
            for (int i = 0; i < parameter.Period; i++)
            {
                sum += parameter.ClosingPrices[i];
            }
            double initialSMA = sum / parameter.Period;

            emaValues.Add(initialSMA);

            // Calculate subsequent EMA values using the formula: EMA = (Closing price - Previous EMA) * smoothing factor + Previous EMA
            for (int i = parameter.Period; i < parameter.ClosingPrices.Length; i++)
            {
                double ema = (parameter.ClosingPrices[i] - emaValues[i - parameter.Period]) * smoothingFactor + emaValues[i - parameter.Period];
                emaValues.Add(ema);
            }

            return new EmaIndicatorResult { EmaValues = emaValues.ToArray() };
        }
    }
}
