using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.ParabolicSAR.Analyzer.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.ParabolicSAR.Analyzer
{
    internal class ParabolicSarAnalyzer : ITechnicalAnalyzer<ParabolicSarAnalyzerResult, ParabolicSarAnalyzerParameter>
    {
        public ParabolicSarAnalyzerResult Analyze(ParabolicSarAnalyzerParameter parameter)
        {
            if (parameter.SarValues.Length < 2)
            {
                throw new ArgumentException("Invalid SAR data provided.");
            }

            // Get the last SAR value (current SAR)
            double currentSAR = parameter.SarValues[parameter.SarValues.Length - 1];

            // Compare the current SAR with the previous SAR to determine the signal score
            double previousSAR = parameter.SarValues[parameter.SarValues.Length - 2];

            // Calculate the distance ratio (normalized to 0-100 range)
            double distanceRatio = Math.Abs(currentSAR - previousSAR) / previousSAR;
            int signalScore = (int)Math.Round((1 - distanceRatio) * Config.MaxRange);

            return new ParabolicSarAnalyzerResult { SignalScore = signalScore };
        }
    }
}
