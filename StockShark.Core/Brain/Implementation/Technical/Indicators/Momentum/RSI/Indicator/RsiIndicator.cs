using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.RSI.Indicator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.RSI.Indicator;

public class RsiIndicator : ITechnicalIndicator<RsiIndicatorResult, RsiIndicatorParameter>
{
    public RsiIndicatorResult Calculate(RsiIndicatorParameter parameter)
    {
        if (parameter.HistoricalClosingPrices == null || parameter.HistoricalClosingPrices.Length < parameter.LookbackPeriod)
            throw new ArgumentException("Insufficient data to calculate RSI.");

        List<double> rsiValues = [];
        double gainSum = 0, lossSum = 0;

        // Calculate initial average gain and loss for the first period
        for (int i = 1; i <= parameter.LookbackPeriod; i++)
        {
            double difference = parameter.HistoricalClosingPrices[i] - parameter.HistoricalClosingPrices[i - 1];
            if (difference > 0)
                gainSum += difference;
            else
                lossSum -= difference; // Inverting loss as it's negative
        }

        double avgGain = gainSum / parameter.LookbackPeriod;
        double avgLoss = lossSum / parameter.LookbackPeriod;
        double rs = avgLoss == 0 ? 0 : avgGain / avgLoss;
        rsiValues.Add(100 - (100 / (1 + rs)));

        // Calculate RSI for each subsequent day
        for (int i = parameter.LookbackPeriod + 1; i < parameter.HistoricalClosingPrices.Length; i++)
        {
            double difference = parameter.HistoricalClosingPrices[i] - parameter.HistoricalClosingPrices[i - 1];
            double gain = difference > 0 ? difference : 0;
            double loss = difference < 0 ? -difference : 0;

            // Update the average gain and loss with smoothing
            avgGain = ((avgGain * (parameter.LookbackPeriod - 1)) + gain) / parameter.LookbackPeriod;
            avgLoss = ((avgLoss * (parameter.LookbackPeriod - 1)) + loss) / parameter.LookbackPeriod;

            // Calculate RSI
            rs = avgLoss == 0 ? 0 : avgGain / avgLoss;
            double rsi = 100 - (100 / (1 + rs));
            rsiValues.Add(rsi);
        }

        return new RsiIndicatorResult { Rsi = [.. rsiValues] };
    }
}
