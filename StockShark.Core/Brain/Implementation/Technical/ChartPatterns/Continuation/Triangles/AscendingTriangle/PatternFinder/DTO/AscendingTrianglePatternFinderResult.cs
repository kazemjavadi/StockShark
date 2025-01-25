using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.AscendingTriangle.PatternFinder.DTO
{
    public class AscendingTrianglePatternFinderResult : ITechnicalPatternFinderResult
    {
        public bool IsAscendingTriangle { get; set; }
        public double AscendingTriangleScore { get; set; }
    }
}
