using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.KeyComponents.SupportAndResistanceLevels.SupportLevel.Analyzer.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.SupportAndResistanceLevels.SupportLevel.Analyzer
{
    internal class SupportLevelAnalyzer : ITechnicalAnalyzer<SupportLevelAnalyzerResult, SupportLevelAnalyzerParameter>
    {
        public SupportLevelAnalyzerResult Analyze(SupportLevelAnalyzerParameter parameter)
        {
            SupportLevelAnalyzerResult result = new();

            if (parameter.SupportLevels.Length == 0)
            {
                result.SignalScore = Config.MaxRange / 2;
                return result; // Neutral if there's no data
            }

            double nearestSupportLevel = parameter.SupportLevels.OrderBy(level => Math.Abs(level - parameter.CurrentPrice)).First();

            result.SignalScore = 100 * (1 - nearestSupportLevel / parameter.CurrentPrice);

            if (result.SignalScore < 0)
                result.SignalScore = 0; // Ensure score is not negative
            else if (result.SignalScore > Config.MaxRange)
                result.SignalScore = 100; // Ensure score does not exceed 100

            return result;
        }
    }
}
