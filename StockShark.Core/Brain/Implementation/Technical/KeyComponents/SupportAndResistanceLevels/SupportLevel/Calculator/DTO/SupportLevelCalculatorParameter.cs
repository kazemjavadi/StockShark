using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.SupportAndResistanceLevels.SupportLevel.Calculator.DTO
{
    internal class SupportLevelCalculatorParameter : ITechnicalCalculatorParameter
    {
        public double[] ClosingPrices { get; set; } = [];
        public int Period { get; set; }
    }
}
