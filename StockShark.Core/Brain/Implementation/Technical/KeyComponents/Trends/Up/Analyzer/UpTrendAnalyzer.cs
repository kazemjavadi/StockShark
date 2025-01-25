using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Up.Analyzer.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Up.Analyzer
{
    internal class UpTrendAnalyzer : ITechnicalAnalyzer<UpTrendAnalyzerResult, UpTrendAnalyzerParameter>
    {
        public UpTrendAnalyzerResult Analyze(UpTrendAnalyzerParameter parameter)
        {
            UpTrendAnalyzerResult result = new();

            if (!parameter.IsUptrend)
            {
                result.SignalScore = 0;
                return result; // Strong selling signal if there is no uptrend
            }

            // Calculate signal score based on the severity of uptrend (for example, based on average change)
            double averageChange = CalculateAverageChange(parameter.Prices, parameter.Period);
            result.SignalScore = Math.Max(averageChange * Config.MaxRange, 0); // Scale to range 0-100

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
