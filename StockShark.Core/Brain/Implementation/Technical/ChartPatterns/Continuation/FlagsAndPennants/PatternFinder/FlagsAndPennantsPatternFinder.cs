using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.FlagsAndPennants.PatternFinder.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.FlagsAndPennants.PatternFinder
{
    public class FlagsAndPennantsPatternFinder : ITechnicalPatternFinder<FlagsAndPennantsPatternFinderResult, FlagsAndPennantsPatternFinderParameter>
    {
        public FlagsAndPennantsPatternFinderResult Recognize(FlagsAndPennantsPatternFinderParameter parameter)
        {
            FlagsAndPennantsPatternFinderResult result = new();
            if (parameter.Prices.Length < parameter.Period * 2 + 1) // Ensure there are enough data points
            {
                result.IsFlagsAndPennants = false;
                result.FlagsAndPennantsScore = 0;
                return result;
            }

            int maxScore = Config.MaxRange;
            int score = 0;
            bool isFlagPennant = false;

            for (int i = parameter.Period; i < parameter.Prices.Length - parameter.Period; i++)
            {
                double poleStart = parameter.Prices[i - parameter.Period];
                double poleEnd = parameter.Prices[i];
                double flagStart = parameter.Prices[i + 1];
                double flagEnd = parameter.Prices[i + parameter.Period];

                // Detect the pole part
                bool isPole = poleEnd > poleStart * 1.1; // A pole should show at least a 10% price increase

                // Detect the flag or pennant part
                bool isFlag = flagEnd < poleEnd && flagEnd > flagStart;
                bool isPennant = flagEnd < poleEnd && flagEnd > flagStart * 0.9;

                if (isPole && (isFlag || isPennant))
                {
                    isFlagPennant = true;

                    // Calculate a score based on how closely the pattern fits a perfect flag or pennant
                    double poleScore = (poleEnd - poleStart) / poleStart; // Higher score if pole shows significant increase
                    double patternScore = isFlag ? (flagEnd - flagStart) / flagStart : (flagEnd - flagStart * 0.9) / (flagStart * 0.9); // Adjust score based on pattern type

                    // Combine scores (you can adjust weights as needed)
                    score = (int)((poleScore + patternScore) / 2.0 * maxScore);
                    break;
                }
            }

            result.IsFlagsAndPennants = isFlagPennant;
            result.FlagsAndPennantsScore = score;
            return result;
        }
    }
}
