using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Up.Calculator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Up.Calculator
{
    internal class UpTrendCalculator : ITechnicalCalculator<UpTrendCalculatorResult, UpTrendCalculatorParameter>
    {
        public UpTrendCalculatorResult Calculate(UpTrendCalculatorParameter parameter)
        {
            UpTrendCalculatorResult result = new();

            if (parameter.Prices.Length < parameter.Period)
            {
                throw new ArgumentException("Period must be less than or equal to the number of prices.");
            }

            // Check if prices are increasing over the specified period
            for (int i = 1; i <= parameter.Period; i++)
            {
                if (parameter.Prices[parameter.Prices.Length - i] <= parameter.Prices[parameter.Prices.Length - i - 1])
                {
                    result.IsUpTrend = false;
                    return result; // Not an uptrend if any price in the period is not increasing
                }
            }

            result.IsUpTrend = true;
            return result; // Indicates an uptrend if all prices in the period are increasing
        }
    }
}
