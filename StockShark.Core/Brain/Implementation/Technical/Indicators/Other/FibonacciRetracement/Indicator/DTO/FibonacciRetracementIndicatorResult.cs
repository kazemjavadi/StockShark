using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Other.FibonacciRetracement.Indicator.DTO
{
    internal class FibonacciRetracementIndicatorResult : ITechnicalIndicatorResult
    {
        public Dictionary<string, double> Levels { get; set; } = [];
        public double CurrentPrice { get; set; }
        public double RetracementScore { get; set; }
    }
}
