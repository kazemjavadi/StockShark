using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.SupportAndResistanceLevels.ResistanceLevel.Calculator.DTO
{
    internal class ResistanceLevelCalculatorParameter : ITechnicalCalculatorParameter
    {
        public double[] ClosingPrices { get; set; } = [];
        public int Period { get; set; }
    }
}
