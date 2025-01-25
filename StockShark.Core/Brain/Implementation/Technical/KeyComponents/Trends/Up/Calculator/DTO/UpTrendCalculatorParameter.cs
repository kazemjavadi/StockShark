using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Up.Calculator.DTO
{
    internal class UpTrendCalculatorParameter : ITechnicalCalculatorParameter
    {
        public double[] Prices { get; set; } = [];
        public int Period { get; set; }
    }
}
