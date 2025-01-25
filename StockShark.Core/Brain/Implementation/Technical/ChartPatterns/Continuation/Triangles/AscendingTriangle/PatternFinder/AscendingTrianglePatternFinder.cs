using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.AscendingTriangle.PatternFinder.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.AscendingTriangle.PatternFinder
{
    public class AscendingTrianglePatternFinder : ITechnicalPatternFinder<AscendingTrianglePatternFinderResult, AscendingTrianglePatternFinderParameter>
    {
        public AscendingTrianglePatternFinderResult Recognize(AscendingTrianglePatternFinderParameter parameter)
        {
            AscendingTrianglePatternFinderResult result = new();

            if (parameter.Prices.Length < parameter.Period) // Ensure there are enough data points
            {
                result.IsAscendingTriangle = false;
                result.AscendingTriangleScore = 0;
                return result;
            }

            int maxScore = Config.MaxRange;
            int score = 0;
            bool isAscendingTriangle = false;

            for (int i = parameter.Period; i < parameter.Prices.Length - parameter.Period; i++)
            {
                double supportStart = parameter.Prices[i - parameter.Period];
                double resistance = parameter.Prices[i];
                double supportEnd = parameter.Prices[i + parameter.Period];

                // Detect the ascending support line and horizontal resistance line
                bool isSupportAscending = supportEnd > supportStart;
                bool isResistanceHorizontal = Math.Abs(resistance - parameter.Prices[i + 1]) < 0.01 * resistance; // Horizontal resistance within 1%

                if (isSupportAscending && isResistanceHorizontal)
                {
                    isAscendingTriangle = true;

                    // Calculate a score based on how closely the pattern fits a perfect ascending triangle
                    double supportSlopeScore = (supportEnd - supportStart) / supportStart; // Higher score if support line is steeply ascending
                    double resistanceFlatnessScore = 1 - Math.Abs(resistance - parameter.Prices[i + 1]) / resistance; // Higher score if resistance is very flat

                    // Combine scores (you can adjust weights as needed)
                    score = (int)((supportSlopeScore + resistanceFlatnessScore) / 2.0 * maxScore);
                    break;
                }
            }

            result.IsAscendingTriangle = isAscendingTriangle;
            result.AscendingTriangleScore = score;
            return result;
        }
    }
}
