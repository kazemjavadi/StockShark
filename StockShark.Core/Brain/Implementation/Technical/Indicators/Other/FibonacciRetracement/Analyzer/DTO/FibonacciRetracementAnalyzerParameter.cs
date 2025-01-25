using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Other.FibonacciRetracement.Analyzer.DTO
{
    internal class FibonacciRetracementAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public Dictionary<string, double> Levels { get; set; } = [];
        public double CurrentPrice { get; set; }
    }
}
