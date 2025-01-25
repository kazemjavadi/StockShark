using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.KeyComponents.SupportAndResistanceLevels.ResistanceLevel.Calculator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.SupportAndResistanceLevels.ResistanceLevel.Calculator
{
    internal class ResistanceLevelCalculator : ITechnicalCalculator<ResistanceLevelCalculatorResult, ResistanceLevelCalculatorParameter>
    {
        public ResistanceLevelCalculatorResult Calculate(ResistanceLevelCalculatorParameter parameter)
        {
            List<double> resistanceLevels = [];

            for (int i = 0; i <= parameter.ClosingPrices.Length - parameter.Period; i++)
            {
                double[] periodPrices = parameter.ClosingPrices.Skip(i).Take(parameter.Period).ToArray();
                double highestHigh = periodPrices.Max();
                resistanceLevels.Add(highestHigh);
            }

            return new ResistanceLevelCalculatorResult { ResistanceLevels = [.. resistanceLevels] };
        }
    }
}
