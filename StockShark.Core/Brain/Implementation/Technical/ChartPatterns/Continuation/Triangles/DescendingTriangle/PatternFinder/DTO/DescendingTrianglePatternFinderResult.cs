using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.DescendingTriangle.PatternFinder.DTO
{
    public class DescendingTrianglePatternFinderResult : ITechnicalPatternFinderResult
    {
        public bool IsDescendingTriangle { get; set; }
        public double DescendingTriangleScore { get; set; }
    }
}
