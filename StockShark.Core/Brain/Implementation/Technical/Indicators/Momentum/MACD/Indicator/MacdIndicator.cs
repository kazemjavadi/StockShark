using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.MACD.Indicator.DTO;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.EMA.Indicator;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.EMA.Indicator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.MACD.Indicator
{
    public class MacdIndicator : ITechnicalIndicator<MacdIndicatorResult, MacdIndicatorParameter>
    {
        // Method to calculate MACD and return result
        public MacdIndicatorResult Calculate(MacdIndicatorParameter parameter)
        {
            // Calculate the short-term and long-term EMAs
            double[] shortEMA = CalculateEMA(parameter.ClosingPrices, parameter.ShortEMAPeriod);
            double[] longEMA = CalculateEMA(parameter.ClosingPrices, parameter.LongEMAPeriod);

            // Calculate the MACD line
            List<double> macdLine = new List<double>();
            for (int i = 0; i < parameter.ClosingPrices.Length; i++)
            {
                macdLine.Add(shortEMA[i] - longEMA[i]);
            }

            // Calculate the Signal line (9-day EMA of the MACD line)
            double[] signalLine = CalculateEMA(macdLine.ToArray(), parameter.SignalEMAPeriod);

            // Calculate the MACD Histogram (MACD line - Signal line)
            List<double> histogram = new List<double>();
            for (int i = 0; i < macdLine.Count; i++)
            {
                histogram.Add(macdLine[i] - signalLine[i]);
            }

            return new MacdIndicatorResult() { MacdLine = [.. macdLine], 
                SignalLine = signalLine, 
                Histogram = [.. histogram]
            };
        }

        // Method to calculate EMA
        private double[] CalculateEMA(double[] prices, int period)
        {
            double multiplier = 2.0 / (period + 1);
            List<double> emaValues = new List<double>();

            // Start with the first EMA value as the first closing price
            double ema = prices[0];
            emaValues.Add(ema);

            // Calculate subsequent EMA values
            for (int i = 1; i < prices.Length; i++)
            {
                ema = ((prices[i] - ema) * multiplier) + ema;
                emaValues.Add(ema);
            }

            return [.. emaValues];
        }
    }
}
