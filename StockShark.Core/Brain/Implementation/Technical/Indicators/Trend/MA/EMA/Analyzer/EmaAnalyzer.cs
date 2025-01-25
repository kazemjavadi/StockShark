using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.EMA.Analyzer.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.EMA.Analyzer
{
    public class EmaAnalyzer : ITechnicalAnalyzer<EmaAnalyzerResult, EmaAnalyzerParameter>
    {
        public EmaAnalyzerResult Analyze(EmaAnalyzerParameter parameter)
        {
            if (parameter.EmaValues.Length < 2)
            {
                throw new ArgumentException("EMA list must contain at least two values.");
            }

            // Calculate percentage change from the second last to the last EMA value
            double lastEMA = parameter.EmaValues[parameter.EmaValues.Length - 1];
            double prevEMA = parameter.EmaValues[parameter.EmaValues.Length - 2];

            double percentageChange = (lastEMA - prevEMA) / prevEMA * Config.MaxRange;

            // Adjust to a score from 0 to 100
            int signalScore = (int)Math.Round(Config.MaxRange / 2 + 0.5 * percentageChange); // Shift the midpoint to 50

            // Ensure the score is within the range of 0 to 100
            if (signalScore < 0)
            {
                signalScore = 0;
            }
            else if (signalScore > Config.MaxRange)
            {
                signalScore = Config.MaxRange;
            }

            return new EmaAnalyzerResult { SignalScore = signalScore };
        }
    }
}
