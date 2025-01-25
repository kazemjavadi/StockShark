using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.SymmetricalTriangle.PatternFinder.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.SymmetricalTriangle.PatternFinder
{
    public class SymmetricalTrianglePatternFinder : ITechnicalPatternFinder<SymmetricalTrianglePatternFinderResult, SymmetricalTrianglePatternFinderParameter>
    {
        public SymmetricalTrianglePatternFinderResult Recognize(SymmetricalTrianglePatternFinderParameter parameter)
        {
            SymmetricalTrianglePatternFinderResult result = new();

            if (parameter.Prices.Length < 5) // A Symmetrical Triangle pattern needs at least 5 data points
            {
                result.IsDescendingTriangle = false;
                result.DescendingTriangleScore = 0;
                return result;
            }

            double maxScore = Config.MaxRange;

            double maxDistance = 0.02; // Maximum distance between the trendlines
            double maxSlopeDifference = 0.02; // Maximum difference in slopes between the trendlines

            bool isSymmetricalTriangle = false;
            double score = 0.0;

            for (int i = parameter.Period; i < parameter.Prices.Length - parameter.Period - 1; i++)
            {
                // Find potential support line points
                double supportPoint1 = parameter.Prices[i];
                double supportPoint2 = parameter.Prices[i + parameter.Period];

                // Find potential resistance line points
                double resistancePoint1 = parameter.Prices[i];
                double resistancePoint2 = parameter.Prices[i - parameter.Period];

                // Calculate the slopes of the lines
                double supportSlope = (supportPoint2 - supportPoint1) / parameter.Period;
                double resistanceSlope = (resistancePoint2 - resistancePoint1) / parameter.Period;

                // Check if the pattern fits the Symmetrical Triangle characteristics
                if (Math.Abs(supportSlope - resistanceSlope) <= maxSlopeDifference &&
                    Math.Abs(supportPoint1 - resistancePoint1) / supportPoint1 <= maxDistance &&
                    Math.Abs(supportPoint2 - resistancePoint2) / supportPoint2 <= maxDistance)
                {
                    isSymmetricalTriangle = true;

                    // Calculate a score based on how closely the pattern fits a Symmetrical Triangle
                    double slopeScore = (1 - Math.Abs(supportSlope - resistanceSlope) / maxSlopeDifference) * maxScore; // Score closer to 100 if slopes are similar
                    double distanceScore = (1 - (Math.Abs(supportPoint1 - resistancePoint1) / supportPoint1 + Math.Abs(supportPoint2 - resistancePoint2) / supportPoint2) / (2 * maxDistance)) * maxScore; // Score closer to 100 if distances are smaller

                    // Combine scores (you can adjust weights as needed)
                    score = (slopeScore + distanceScore) / 2.0;
                    break;
                }
            }

            result.IsDescendingTriangle = isSymmetricalTriangle;
            result.DescendingTriangleScore = score;

            return result;
        }
    }
}
