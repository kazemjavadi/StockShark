using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Sideways.Analyzer.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Sideways.Analyzer
{
    internal class SidewaysAnalyzer : ITechnicalAnalyzer<SidewaysAnalyzerResult, SidewaysAnalyzerParameter>
    {
        public SidewaysAnalyzerResult Analyze(SidewaysAnalyzerParameter parameter)
        {
            if (parameter.Prices.Length < parameter.Period)
            {
                throw new ArgumentException("Period must be less than or equal to the number of prices.");
            }

            // Calculate sideways score based on price range and volatility
            double sidewaysScore = CalculateSidewaysScore(parameter.Prices, parameter.Period);

            // Scale the sideways score to a signal score ranging from 0 to 100
            double signalScore = sidewaysScore * Config.MaxRange;

            return new SidewaysAnalyzerResult { SignalScore = signalScore };
        }

        private static double CalculateSidewaysScore(double[] prices, int period)
        {
            // Calculate the range (high and low) over the specified period
            double highestPrice = double.MinValue;
            double lowestPrice = double.MaxValue;

            for (int i = 0; i < period; i++)
            {
                if (prices[i] > highestPrice)
                {
                    highestPrice = prices[i];
                }
                if (prices[i] < lowestPrice)
                {
                    lowestPrice = prices[i];
                }
            }

            // Calculate the average price over the period
            double averagePrice = CalculateAveragePrice(prices, period);

            // Calculate the price range and volatility
            double priceRange = highestPrice - lowestPrice;
            double volatility = CalculateVolatility(prices, period);

            // Calculate the sideways score based on range and volatility
            double sidewaysScore = 1 - priceRange / (2 * volatility);

            // Ensure the sideways score is within the range [0, 1]
            sidewaysScore = Math.Max(0, Math.Min(1, sidewaysScore));

            return sidewaysScore;
        }

        private static double CalculateAveragePrice(double[] prices, int period)
        {
            double total = 0;
            for (int i = 0; i < period; i++)
            {
                total += prices[i];
            }
            return total / period;
        }

        private static double CalculateVolatility(double[] prices, int period)
        {
            // Calculate the standard deviation of prices over the period as a measure of volatility
            double averagePrice = CalculateAveragePrice(prices, period);
            double sumSquaredDeviations = 0;

            for (int i = 0; i < period; i++)
            {
                double deviation = prices[i] - averagePrice;
                sumSquaredDeviations += deviation * deviation;
            }

            double variance = sumSquaredDeviations / period;
            double volatility = Math.Sqrt(variance);

            return volatility;
        }
    }
}
