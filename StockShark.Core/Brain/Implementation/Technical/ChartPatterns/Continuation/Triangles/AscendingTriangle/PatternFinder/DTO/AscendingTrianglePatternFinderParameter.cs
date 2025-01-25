using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.AscendingTriangle.PatternFinder.DTO
{
    public class AscendingTrianglePatternFinderParameter : ITechnicalPatternFinderParameter
    {
        public double[] Prices { get; set; } = [];
        public int Period { get; set; }
    }
}
