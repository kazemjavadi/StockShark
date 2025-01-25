using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.SymmetricalTriangle.PatternFinder.DTO
{
    public class SymmetricalTrianglePatternFinderResult : ITechnicalPatternFinderResult
    {
        public bool IsDescendingTriangle { get; set; }
        public double DescendingTriangleScore { get; set; }
    }
}
