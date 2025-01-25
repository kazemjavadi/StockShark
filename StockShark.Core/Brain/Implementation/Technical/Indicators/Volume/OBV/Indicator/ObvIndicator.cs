using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Volume.OBV.Indicator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volume.OBV.Indicator
{
    internal class ObvIndicator : ITechnicalIndicator<ObvIndicatorResult, ObvIndicatorParameter>
    {
        public ObvIndicatorResult Calculate(ObvIndicatorParameter parameter)
        {
            List<double> obvValues = [];
            double obv = 0;

            for (int i = 0; i < parameter.ClosingPrices.Length; i++)
            {
                if (i == 0)
                {
                    // The first OBV value is initialized to the first volume
                    obv = parameter.Volumes[i];
                }
                else
                {
                    if (parameter.ClosingPrices[i] > parameter.ClosingPrices[i - 1])
                    {
                        obv += parameter.Volumes[i];
                    }
                    else if (parameter.ClosingPrices[i] < parameter.ClosingPrices[i - 1])
                    {
                        obv -= parameter.Volumes[i];
                    }
                    // If closingPrices[i] == closingPrices[i - 1], OBV remains unchanged
                }

                obvValues.Add(obv);
            }

            return new ObvIndicatorResult { ObvValues = [.. obvValues] };
        }
    }
}
