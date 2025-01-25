using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.HeadAndShoulders.Analyzer.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.HeadAndShoulders.Analyzer
{
    internal class HeadAndShouldersAnalyzer : ITechnicalAnalyzer<HeadAndShouldersAnalyzerResult, HeadAndShouldersAnalyzerParameter>
    {
        public HeadAndShouldersAnalyzerResult Analyze(HeadAndShouldersAnalyzerParameter parameter)
        {
            HeadAndShouldersAnalyzerResult result = new();

            if (!parameter.IsHeadAndShoulders)
            {
                result.SignalScore = Config.MaxRange / 2;
                return result;  // Neutral score if no pattern detected
            }

            // Scale the score to fit within the 0-100 range
            int signalScore = (int)Math.Round(parameter.HeadAndShouldersScore);

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
