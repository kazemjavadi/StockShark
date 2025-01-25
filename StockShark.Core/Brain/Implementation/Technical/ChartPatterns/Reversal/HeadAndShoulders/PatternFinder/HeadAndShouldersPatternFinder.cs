using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.HeadAndShoulders.PatternFinder.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.HeadAndShoulders.PatternFinder
{
    internal class HeadAndShouldersPatternFinder : ITechnicalPatternFinder<HeadAndShouldersPatternFinderResult, HeadAndShouldersPatternFinderParameter>
    {
        public HeadAndShouldersPatternFinderResult Recognize(HeadAndShouldersPatternFinderParameter parameter)
        {
            HeadAndShouldersPatternFinderResult result = new();

            if (parameter.Prices.Length < 7) // A Head and Shoulders pattern needs at least 7 data points
            {
                result.IsHeadAndShoulders = false;
                result.HeadAndShouldersScore = 0;

                return result;
            }

            double maxScore = Config.MaxRange;

            double maxShoulderDepthPercentage = 0.05; // Maximum depth percentage between shoulders
            double minHeadHeightPercentage = 0.99; // Minimum percentage for head height
            double minNecklineBreakPercentage = 1.01; // Minimum percentage for neckline break

            bool isHeadAndShoulders = false;
            double score = 0.0;

            for (int i = parameter.Period; i < parameter.Prices.Length - parameter.Period - 2; i++)
            {
                // Left shoulder
                double shoulderLeft = parameter.Prices[i - parameter.Period];
                double headLeft = parameter.Prices[i - parameter.Period - 1];

                // Head
                double head = parameter.Prices[i];
                double shoulderRight = parameter.Prices[i + 1];

                // Right shoulder
                double headRight = parameter.Prices[i + 2];
                double shoulderRight2 = parameter.Prices[i + parameter.Period + 2];

                // Neckline
                double neckline = Math.Min(shoulderLeft, shoulderRight2);

                // Check if the pattern fits the Head and Shoulders characteristics
                if (head > headLeft && head > headRight &&
                    shoulderLeft < headLeft && shoulderRight < headRight &&
                    Math.Abs(shoulderLeft - shoulderRight) / Math.Max(shoulderLeft, shoulderRight) < maxShoulderDepthPercentage &&
                    head / Math.Max(headLeft, headRight) > minHeadHeightPercentage &&
                    parameter.Prices[i + parameter.Period + 1] > neckline * minNecklineBreakPercentage)
                {
                    isHeadAndShoulders = true;

                    // Calculate a score based on how closely the pattern fits a perfect Head and Shoulders
                    double shoulderDepthScore = (1 - Math.Abs(shoulderLeft - shoulderRight) / Math.Max(shoulderLeft, shoulderRight)) * maxScore; // Score closer to 100 if shoulders are equal
                    double headHeightScore = head / Math.Max(headLeft, headRight) * maxScore; // Higher score if head height is higher
                    double necklineBreakScore = (parameter.Prices[i + parameter.Period + 1] - neckline) / neckline * maxScore; // Higher score if neckline break is significant

                    // Combine scores (you can adjust weights as needed)
                    score = (shoulderDepthScore + headHeightScore + necklineBreakScore) / 3.0;
                    break;
                }
            }

            result.IsHeadAndShoulders = isHeadAndShoulders;
            result.HeadAndShouldersScore = score;

            return result;
        }
    }
}
