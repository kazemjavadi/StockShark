using StockShark.Core.Brain.Base.Technical;
namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.SymmetricalTriangle.Analyzer.DTO
{
    public class SymmetricalTriangleAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public bool IsSymmetricalTriangle { get; set; }
        public double SymmetricalTriangleScore { get; set; }
    }
}
