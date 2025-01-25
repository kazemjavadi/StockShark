using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Down.Analyzer.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Down.Analyzer
{
    internal class DownTrendAnalyzer : ITechnicalAnalyzer<DownTrendAnalyzerResult, DownTrendAnalyzerParameter>
    {
        public DownTrendAnalyzerResult Analyze(DownTrendAnalyzerParameter parameter)
        {
            DownTrendAnalyzerResult result = new();

            if (!parameter.IsDowntrend)
            {
                result.SignalScore = Config.MaxRange / 2;
                return result; // Neutral signal if no clear downtrend
            }

            // Calculate signal score based on the severity of downtrend (for example, based on average change)
            double averageChange = CalculateAverageChange(parameter.Prices, parameter.Period);
            result.SignalScore = Math.Min(-averageChange * Config.MaxRange, Config.MaxRange); // Scale to range 0-100
            return result;
        }

        private static double CalculateAverageChange(double[] prices, int period)
        {
            double totalChange = 0;
            for (int i = 1; i <= period; i++)
            {
                totalChange += (prices[prices.Length - i] - prices[prices.Length - i - 1]) / prices[prices.Length - i - 1];
            }

            double averageChange = totalChange / period; // Average change over the specified period
            return averageChange;
        }
    }
}
