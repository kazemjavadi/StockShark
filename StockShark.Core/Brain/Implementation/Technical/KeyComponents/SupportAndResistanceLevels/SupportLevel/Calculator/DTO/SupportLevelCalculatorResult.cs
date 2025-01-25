using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.SupportAndResistanceLevels.SupportLevel.Calculator.DTO
{
    internal class SupportLevelCalculatorResult : ITechnicalCalculatorResult
    {
        public double[] SupportLevels { get; set; } = [];
    }
}
