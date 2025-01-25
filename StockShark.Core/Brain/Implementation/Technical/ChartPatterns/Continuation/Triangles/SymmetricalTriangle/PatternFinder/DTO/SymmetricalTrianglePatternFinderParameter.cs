using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.SymmetricalTriangle.PatternFinder.DTO
{
    public class SymmetricalTrianglePatternFinderParameter : ITechnicalPatternFinderParameter
    {
        public double[] Prices { get; set; } = [];
        public int Period { get; set; }
    }
}
