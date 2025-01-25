using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.DoubleTopAndDoubleBottom.DoubleTop.PatternFinder.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.DoubleTopAndDoubleBottom.DoubleTop.PatternFinder
{
    internal class DoubleTopPatternFinder : ITechnicalPatternFinder<DoubleTopPatternFinderResult, DoubleTopPatternFinderParameter>
    {
        public DoubleTopPatternFinderResult Recognize(DoubleTopPatternFinderParameter parameter)
        {
            DoubleTopPatternFinderResult result = new();

            if (parameter.Prices.Length < 5) // A Double Top pattern needs at least 5 data points
            {
                result.IsDoubleTop = false;
                result.DoubleTopScore = 0;

                return result;
            }

            double maxScore = Config.MaxRange;

            double maxDepthPercentage = 0.05; // Maximum depth percentage between tops
            double minConfirmationPercentage = 0.99; // Minimum percentage for confirmation trough

            bool isDoubleTop = false;
            double score = 0.0;

            for (int i = parameter.Period; i < parameter.Prices.Length - parameter.Period; i++)
            {
                // First top
                double top1 = parameter.Prices[i - parameter.Period];
                double trough1 = parameter.Prices[i - parameter.Period - 1];

                // Second top
                double top2 = parameter.Prices[i];
                double trough2 = parameter.Prices[i + 1];

                // Confirmation trough
                double confirmationTrough = parameter.Prices[i + parameter.Period + 1];

                // Check if the pattern fits the Double Top characteristics
                if (top1 > trough1 && top2 > trough2 &&
                    Math.Abs(top1 - top2) / Math.Max(top1, top2) < maxDepthPercentage && // Ensure tops are within 5% of each other
                    confirmationTrough < Math.Min(trough1, trough2) * minConfirmationPercentage) // Confirmation trough should be lower than the previous troughs
                {
                    isDoubleTop = true;

                    // Calculate a score based on how closely the pattern fits a perfect double top
                    double depthScore = (1 - Math.Abs(top1 - top2) / Math.Max(top1, top2)) * maxScore; // Score closer to 100 if tops are equal
                    double confirmationScore = (Math.Min(trough1, trough2) - confirmationTrough) / Math.Min(trough1, trough2) * maxScore; // Higher score if confirmation trough is lower

                    // Combine scores (you can adjust weights as needed)
                    score = (depthScore + confirmationScore) / 2.0;
                    break;
                }
            }

            result.IsDoubleTop = isDoubleTop;
            result.DoubleTopScore = score;

            return result;
        }
    }
}
