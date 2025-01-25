using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.DescendingTriangle.PatternFinder.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.DescendingTriangle.PatternFinder
{
    public class DescendingTrianglePatternFinder : ITechnicalPatternFinder<DescendingTrianglePatternFinderResult, DescendingTrianglePatternFinderParameter>
    {
        public DescendingTrianglePatternFinderResult Recognize(DescendingTrianglePatternFinderParameter parameter)
        {
            DescendingTrianglePatternFinderResult result = new();

            if (parameter.Prices.Length < 5) // A Descending Triangle pattern needs at least 5 data points
            {
                result.IsDescendingTriangle = false;
                result.DescendingTriangleScore = Config.MaxRange / 2;
                return result;
            }

            double maxScore = Config.MaxRange;

            double maxSupportDistance = 0.02; // Maximum distance between points and the support line
            double maxTrendlineSlope = -0.02; // Maximum slope for the descending trendline

            bool isDescendingTriangle = false;
            double score = 0.0;

            for (int i = parameter.Period; i < parameter.Prices.Length - parameter.Period - 1; i++)
            {
                // Find potential support line points
                double supportPoint1 = parameter.Prices[i];
                double supportPoint2 = parameter.Prices[i + parameter.Period];

                // Find potential descending trendline points
                double trendlinePoint1 = parameter.Prices[i - parameter.Period];
                double trendlinePoint2 = parameter.Prices[i + 1];

                // Calculate the slopes of the lines
                double supportSlope = (supportPoint2 - supportPoint1) / parameter.Period;
                double trendlineSlope = (trendlinePoint2 - trendlinePoint1) / (parameter.Period + 1);

                // Check if the pattern fits the Descending Triangle characteristics
                if (supportSlope > maxTrendlineSlope &&
                    Math.Abs(trendlineSlope) <= Math.Abs(supportSlope) &&
                    Math.Abs(supportPoint1 - parameter.Prices[i + parameter.Period - 1]) / supportPoint1 <= maxSupportDistance)
                {
                    isDescendingTriangle = true;

                    // Calculate a score based on how closely the pattern fits a Descending Triangle
                    double supportDistanceScore = (1 - Math.Abs(supportPoint1 - parameter.Prices[i + parameter.Period - 1]) / supportPoint1) * maxScore; // Score closer to 100 if distance to support line is smaller
                    double trendlineSlopeScore = Math.Abs(trendlineSlope / maxTrendlineSlope) * maxScore; // Score closer to 100 if trendline slope is closer to maximum allowed slope

                    // Combine scores (you can adjust weights as needed)
                    score = (supportDistanceScore + trendlineSlopeScore) / 2.0;
                    break;
                }
            }

            result.IsDescendingTriangle = isDescendingTriangle;
            result.DescendingTriangleScore = score;

            return result;
        }
    }
}
