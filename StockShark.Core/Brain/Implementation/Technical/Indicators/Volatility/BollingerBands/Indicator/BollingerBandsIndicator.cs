using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Volatility.BollingerBands.Indicator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volatility.BollingerBands.Indicator
{
    internal class BollingerBandsIndicator : ITechnicalIndicator<BollingerBandsIndicatorResult, BollingerBandsIndicatorParameter>
    {
        public BollingerBandsIndicatorResult Calculate(BollingerBandsIndicatorParameter parameter)
        {
            List<double> middleBand = [];
            List<double> upperBand = [];
            List<double> lowerBand = [];

            // Calculate the middle band (Simple Moving Average)
            for (int i = parameter.Period - 1; i < parameter.ClosingPrices.Length; i++)
            {
                double sma = CalculateSMA(parameter.ClosingPrices.ToList().GetRange(i - parameter.Period + 1, parameter.Period).ToArray());
                middleBand.Add(sma);
            }

            // Calculate upper and lower bands
            for (int i = 0; i < middleBand.Count; i++)
            {
                double sumSquaredDeviations = 0;

                // Calculate standard deviation
                for (int j = i; j < i + parameter.Period; j++)
                {
                    sumSquaredDeviations += (parameter.ClosingPrices[j] - middleBand[i]) * (parameter.ClosingPrices[j] - middleBand[i]);
                }
                double stdDeviation = Math.Sqrt((double)(sumSquaredDeviations / parameter.Period));

                // Calculate upper and lower bands
                upperBand.Add(middleBand[i] + parameter.NumStandardDeviations * stdDeviation);
                lowerBand.Add(middleBand[i] - parameter.NumStandardDeviations * stdDeviation);
            }

            return new BollingerBandsIndicatorResult { MiddleBand = [.. middleBand], UpperBand = [.. upperBand], LowerBand = [.. lowerBand] };
        }

        public static double CalculateSMA(double[] prices)
        {
            double sum = 0;
            foreach (var price in prices)
            {
                sum += price;
            }
            return sum / prices.Length;
        }
    }
}
