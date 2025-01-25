using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.DescendingTriangle.Analyzer.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.DescendingTriangle.Analyzer
{
    public class DescendingTriangleAnalyzer : ITechnicalAnalyzer<DescendingTriangleAnalyzerResult, DescendingTriangleAnalyzerParameter>
    {
        public DescendingTriangleAnalyzerResult Analyze(DescendingTriangleAnalyzerParameter parameter)
        {
            DescendingTriangleAnalyzerResult result = new();

            if (!parameter.IsDescendingTriangle)
            {
                result.SignalScore = Config.MaxRange / 2;
                return result;  // Neutral score if no pattern detected
            }
            // Scale the score to fit within the 0-100 range
            double signalScore = Math.Round(parameter.DescendingTriangleScore);

            // Ensure the score is within the valid range
            if (signalScore < 0)
                signalScore = 0;
            else if (signalScore > Config.MaxRange)
                signalScore = Config.MaxRange;

            result.SignalScore = signalScore;

            return result;
        }
    }
}
