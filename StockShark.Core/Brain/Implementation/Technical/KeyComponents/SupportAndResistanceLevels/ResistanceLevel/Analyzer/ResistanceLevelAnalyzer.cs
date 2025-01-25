using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.KeyComponents.SupportAndResistanceLevels.ResistanceLevel.Analyzer.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.SupportAndResistanceLevels.ResistanceLevel.Analyzer
{
    internal class ResistanceLevelAnalyzer : ITechnicalAnalyzer<ResistanceLevelAnalyzerResult, ResistanceLevelAnalyzerParameter>
    {
        public ResistanceLevelAnalyzerResult Analyze(ResistanceLevelAnalyzerParameter parameter)
        {
            ResistanceLevelAnalyzerResult result = new();

            if (parameter.ResistanceLevels.Length == 0)
            {
                result.SignalScore = Config.MaxRange / 2;
                return result; // Neutral if there's no data
            }

            double nearestResistanceLevel = parameter.ResistanceLevels.OrderBy(level => Math.Abs(level - parameter.CurrentPrice)).First();

            result.SignalScore = Config.MaxRange * (1 - parameter.CurrentPrice / nearestResistanceLevel);

            if (result.SignalScore < 0)
            {
                result.SignalScore = 0; // Ensure score is not negative
            }
            else if (result.SignalScore > Config.MaxRange)
            {
                result.SignalScore = Config.MaxRange; // Ensure score does not exceed 100
            }

            return result;
        }
    }
}
