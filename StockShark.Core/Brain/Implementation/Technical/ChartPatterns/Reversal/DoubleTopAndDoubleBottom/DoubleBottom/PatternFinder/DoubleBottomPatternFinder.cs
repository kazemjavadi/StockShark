using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.DoubleTopAndDoubleBottom.DoubleBottom.PatternFinder.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.DoubleTopAndDoubleBottom.DoubleBottom.PatternFinder
{
    internal class DoubleBottomPatternFinder : ITechnicalPatternFinder<DoubleBottomPatternFinderResult, DoubleBottomPatternFinderParameter>
    {
        public DoubleBottomPatternFinderResult Recognize(DoubleBottomPatternFinderParameter parameter)
        {
            DoubleBottomPatternFinderResult result = new();

            if (parameter.Prices.Length < 5) // A Double Bottom pattern needs at least 5 data points
            {
                result.IsDoubleBottom = false;
                result.DoubleBottomScore = 0;

                return result;
            }

            double maxScore = Config.MaxRange; // Adjusted scaling factor


            double minDepthPercentage = 0.05; // Minimum depth percentage between bottoms
            double minConfirmationPercentage = 1.01; // Minimum percentage for confirmation peak

            bool isDoubleBottom = false;
            double score = 0.0;

            for (int i = parameter.Period; i < parameter.Prices.Length - parameter.Period; i++)
            {
                // First bottom
                double bottom1 = parameter.Prices[i - parameter.Period];
                double peak1 = parameter.Prices[i - parameter.Period - 1];

                // Second bottom
                double bottom2 = parameter.Prices[i];
                double peak2 = parameter.Prices[i + 1];

                // Confirmation peak
                double confirmationPeak = parameter.Prices[i + parameter.Period + 1];

                // Check if the pattern fits the Double Bottom characteristics
                if (bottom1 < peak1 && bottom2 < peak2 &&
                    Math.Abs(bottom1 - bottom2) / Math.Min(bottom1, bottom2) < minDepthPercentage && // Ensure bottoms are within 5% of each other
                    confirmationPeak > Math.Max(peak1, peak2) * minConfirmationPercentage) // Confirmation peak should be higher than the previous peaks
                {
                    isDoubleBottom = true;

                    // Calculate a score based on how closely the pattern fits a perfect double bottom
                    double depthScore = (1 - Math.Abs(bottom1 - bottom2) / Math.Min(bottom1, bottom2)) * maxScore; // Score closer to 100 if bottoms are equal
                    double confirmationScore = (confirmationPeak - Math.Max(peak1, peak2)) / Math.Max(peak1, peak2) * maxScore; // Higher score if confirmation peak is higher

                    // Combine scores (you can adjust weights as needed)
                    score = (depthScore + confirmationScore) / 2.0;
                    break;
                }
            }

            result.IsDoubleBottom = isDoubleBottom;
            result.DoubleBottomScore = score;

            return result;
        }
    }
}
