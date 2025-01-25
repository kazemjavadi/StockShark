using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Down.Calculator.DTO
{
    internal class DownTrendCalculatorParameter : ITechnicalCalculatorParameter
    {
        public double[] ClosingPrices { get; set; } = [];
        public int Period { get; set; }
    }
}
