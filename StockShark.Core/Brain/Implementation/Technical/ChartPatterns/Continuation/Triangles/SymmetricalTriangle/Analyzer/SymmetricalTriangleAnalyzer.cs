using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.SymmetricalTriangle.Analyzer.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.SymmetricalTriangle.Analyzer
{
    public class SymmetricalTriangleAnalyzer : ITechnicalAnalyzer<SymmetricalTriangleAnalyzerResult, SymmetricalTriangleAnalyzerParameter>
    {
        public SymmetricalTriangleAnalyzerResult Analyze(SymmetricalTriangleAnalyzerParameter parameter)
        {
            SymmetricalTriangleAnalyzerResult result = new();

            if (!parameter.IsSymmetricalTriangle)
            {
                result.SignalScore = Config.MaxRange / 2;
                return result;  // Neutral score if no pattern detected
            }
            // Scale the score to fit within the 0-100 range
            double signalScore = Math.Round(parameter.SymmetricalTriangleScore);

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
