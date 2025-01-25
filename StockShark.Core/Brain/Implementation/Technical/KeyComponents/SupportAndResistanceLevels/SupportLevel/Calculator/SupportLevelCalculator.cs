using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.KeyComponents.SupportAndResistanceLevels.SupportLevel.Calculator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.SupportAndResistanceLevels.SupportLevel.Calculator
{
    internal class SupportLevelCalculator : ITechnicalCalculator<SupportLevelCalculatorResult, SupportLevelCalculatorParameter>
    {
        public SupportLevelCalculatorResult Calculate(SupportLevelCalculatorParameter parameter)
        {
            List<double> supportLevels = [];

            for (int i = 0; i <= parameter.ClosingPrices.Length - parameter.Period; i++)
            {
                double[] periodPrices = parameter.ClosingPrices.Skip(i).Take(parameter.Period).ToArray();
                double lowestLow = periodPrices.Min();
                supportLevels.Add(lowestLow);
            }

            return new SupportLevelCalculatorResult { SupportLevels = [.. supportLevels] };
        }
    }
}
