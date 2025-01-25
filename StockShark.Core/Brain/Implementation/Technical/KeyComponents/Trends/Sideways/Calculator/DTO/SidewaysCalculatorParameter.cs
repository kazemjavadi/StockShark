using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Sideways.Calculator.DTO
{
    internal class SidewaysCalculatorParameter : ITechnicalCalculatorParameter
    {
        public double[] Prices { get; set; } = [];
        public int Period { get; set; }
    }
}
