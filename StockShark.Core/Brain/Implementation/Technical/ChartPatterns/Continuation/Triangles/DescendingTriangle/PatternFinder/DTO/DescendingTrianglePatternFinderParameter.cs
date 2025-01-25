using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.DescendingTriangle.PatternFinder.DTO
{
    public class DescendingTrianglePatternFinderParameter : ITechnicalPatternFinderParameter
    {
        public double[] Prices { get; set; } = [];
        public int Period { get; set; }
    }
}
