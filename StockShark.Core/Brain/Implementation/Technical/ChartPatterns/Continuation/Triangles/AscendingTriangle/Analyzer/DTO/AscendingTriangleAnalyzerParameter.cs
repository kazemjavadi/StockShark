using StockShark.Core.Brain.Base.Technical;
namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.AscendingTriangle.Analyzer.DTO
{
    public class AscendingTriangleAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public bool IsAscendingTriangle { get; set; }
        public double AscendingTriangleScore { get; set; }
    }
}
