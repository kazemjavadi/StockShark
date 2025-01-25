using StockShark.Core.Brain.Base.Technical;
namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.DescendingTriangle.Analyzer.DTO
{
    public class DescendingTriangleAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public bool IsDescendingTriangle { get; set; }
        public double DescendingTriangleScore { get; set; }
    }
}
