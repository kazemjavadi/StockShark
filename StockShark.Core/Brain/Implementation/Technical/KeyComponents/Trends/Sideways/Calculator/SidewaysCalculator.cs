using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Sideways.Calculator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Sideways.Calculator
{
    internal class SidewaysCalculator : ITechnicalCalculator<SidewaysCalculatorResult, SidewaysCalculatorParameter>
    {
        public SidewaysCalculatorResult Calculate(SidewaysCalculatorParameter parameter)
        {
            SidewaysCalculatorResult result = new();

            if (parameter.Prices.Length < parameter.Period)
            {
                throw new ArgumentException("Period must be less than or equal to the number of prices.");
            }

            // Calculate the range (high and low) over the specified period
            double highestPrice = double.MinValue;
            double lowestPrice = double.MaxValue;

            for (int i = 0; i < parameter.Period; i++)
            {
                if (parameter.Prices[i] > highestPrice)
                {
                    highestPrice = parameter.Prices[i];
                }
                if (parameter.Prices[i] < lowestPrice)
                {
                    lowestPrice = parameter.Prices[i];
                }
            }

            // Determine if the range (high - low) is below a certain threshold (e.g., 2% of the average price)
            double averagePrice = CalculateAveragePrice(parameter.Prices, parameter.Period);
            double priceRange = highestPrice - lowestPrice;
            double threshold = 0.02 * averagePrice; // Example threshold (adjust as needed)

            result.IsSideways = priceRange <= threshold;
            return result;
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
    }
}
