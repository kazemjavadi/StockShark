using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Other.FibonacciRetracement.Indicator.DTO
{
    internal class FibonacciRetracementIndicatorParameter : ITechnicalIndicatorParameter
    {
        public double[] Prices { get; set; } = [];
        public int Period { get; set; }
    }
}
