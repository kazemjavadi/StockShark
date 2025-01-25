using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.ParabolicSAR.Indicator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.ParabolicSAR.Indicator
{
    internal class ParabolicSARIndicator : ITechnicalIndicator<ParabolicSARIndicatorResult, ParabolicSARIndicatorParameter>
    {
        public ParabolicSARIndicatorResult Calculate(ParabolicSARIndicatorParameter parameter)
        {
            if (parameter.HighPrices.Length != parameter.LowPrices.Length || parameter.HighPrices.Length < 2)
            {
                throw new ArgumentException("Invalid price data provided.");
            }

            List<double> sarValues = new List<double>();
            bool isLong = true; // Initial direction (long)

            double initialSAR = parameter.LowPrices[0];
            double initialAF = parameter.AccelerationFactor;

            double currentSAR = initialSAR;
            double extremePoint = parameter.HighPrices[0];
            double acceleration = initialAF;

            // First SAR is the initial SAR value
            sarValues.Add(initialSAR);

            for (int i = 1; i < parameter.HighPrices.Length; i++)
            {
                double previousSAR = currentSAR;

                if (isLong)
                {
                    // Calculate SAR for long position
                    currentSAR += acceleration * (extremePoint - previousSAR);

                    // Update extreme point
                    if (parameter.HighPrices[i] > extremePoint)
                    {
                        extremePoint = parameter.HighPrices[i];
                        acceleration = Math.Min(acceleration + parameter.AccelerationFactor, parameter.MaxAccelerationFactor);
                    }
                }
                else
                {
                    // Calculate SAR for short position
                    currentSAR -= acceleration * (previousSAR - extremePoint);

                    // Update extreme point
                    if (parameter.LowPrices[i] < extremePoint)
                    {
                        extremePoint = parameter.LowPrices[i];
                        acceleration = Math.Min(acceleration + parameter.AccelerationFactor, parameter.MaxAccelerationFactor);
                    }
                }

                // Switch direction if SAR is hit
                if (isLong && currentSAR > parameter.LowPrices[i])
                {
                    isLong = false;
                    currentSAR = extremePoint;
                    acceleration = initialAF;
                    extremePoint = parameter.LowPrices[i];
                }
                else if (!isLong && currentSAR < parameter.HighPrices[i])
                {
                    isLong = true;
                    currentSAR = extremePoint;
                    acceleration = initialAF;
                    extremePoint = parameter.HighPrices[i];
                }

                // Add current SAR to the list
                sarValues.Add(currentSAR);
            }

            return new ParabolicSARIndicatorResult { SarValues = [.. sarValues] };
        }
    }
}
