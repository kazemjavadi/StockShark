using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.SupportAndResistanceLevels.ResistanceLevel.Calculator.DTO
{
    internal class ResistanceLevelCalculatorResult : ITechnicalCalculatorResult
    {
        public double[] ResistanceLevels { get; set; } = [];
    }
}
