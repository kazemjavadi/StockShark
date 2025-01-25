using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Down.Calculator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Down.Calculator
{
    internal class DownTrendCalculator : ITechnicalCalculator<DownTrendCalculatorResult, DownTrendCalculatorParameter>
    {
        public DownTrendCalculatorResult Calculate(DownTrendCalculatorParameter parameter)
        {
            DownTrendCalculatorResult result = new();

            if (parameter.ClosingPrices.Length < parameter.Period)
            {
                result.IsDownTrend = false;
                return result; // Not enough data to determine a trend
            }

            for (int i = 0; i < parameter.Period - 1; i++)
            {
                if (parameter.ClosingPrices[parameter.ClosingPrices.Length - 1 - i] >= parameter.ClosingPrices[parameter.ClosingPrices.Length - 2 - i])
                {
                    result.IsDownTrend = false;
                    return result; // Not a downtrend if any current price is not lower than the previous price
                }
            }

            result.IsDownTrend = true;
            return result; // All prices in the period are lower than the previous ones
        }
    }
}
