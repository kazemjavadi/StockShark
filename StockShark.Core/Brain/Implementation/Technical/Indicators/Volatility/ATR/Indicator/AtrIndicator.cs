using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Volatility.ATR.Indicator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volatility.ATR.Indicator
{
    internal class AtrIndicator : ITechnicalIndicator<AtrIndicatorResult, AtrIndicatorParameter>
    {
        public AtrIndicatorResult Calculate(AtrIndicatorParameter parameter)
        {
            List<double> atrValues = [];

            // Calculate the first ATR as the SMA of the True Range over the first 'period' days
            double firstATR = CalculateSMATrueRange(parameter.HighPrices, parameter.LowPrices, parameter.Period);
            atrValues.Add(firstATR);

            // Calculate subsequent ATR values using the formula
            for (int i = parameter.Period; i < parameter.HighPrices.Length; i++)
            {
                double previousATR = atrValues[i - parameter.Period];
                double currentTrueRange = CalculateTrueRange(parameter.HighPrices[i], parameter.LowPrices[i], parameter.HighPrices[i - 1], parameter.LowPrices[i - 1]);
                double currentATR = (previousATR * (parameter.Period - 1) + currentTrueRange) / parameter.Period;
                atrValues.Add(currentATR);
            }

            return new AtrIndicatorResult { AtrValues = [.. atrValues] };
        }


        private static double CalculateTrueRange(double currentHigh, double currentLow, double previousHigh, double previousLow)
        {
            double trueRange = Math.Max(currentHigh - currentLow,
                                         Math.Max(Math.Abs(currentHigh - previousLow),
                                                  Math.Abs(currentLow - previousLow)));
            return trueRange;
        }

        private static double CalculateSMATrueRange(double[] highPrices, double[] lowPrices, int period)
        {
            double sumTrueRange = 0;

            // Calculate sum of True Range over the first 'period' days
            for (int i = 1; i <= period; i++)
            {
                sumTrueRange += CalculateTrueRange(highPrices[i], lowPrices[i], highPrices[i - 1], lowPrices[i - 1]);
            }

            // Calculate SMA of True Range
            double smaTrueRange = sumTrueRange / period;
            return smaTrueRange;
        }
    }
}
