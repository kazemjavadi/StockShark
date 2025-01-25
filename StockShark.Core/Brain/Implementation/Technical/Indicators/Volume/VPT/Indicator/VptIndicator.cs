using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Volume.VPT.Indicator.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volume.VPT.Indicator
{
    internal class VptIndicator : ITechnicalIndicator<VptIndicatorResult, VptIndicatorParameter>
    {
        public VptIndicatorResult Calculate(VptIndicatorParameter parameter)
        {
            List<double> vptValues = [];
            double vpt = 0;

            for (int i = 0; i < parameter.ClosingPrices.Length; i++)
            {
                if (i == 0)
                {
                    // The first VPT value is initialized to zero
                    vptValues.Add(0);
                }
                else
                {
                    double priceChange = parameter.ClosingPrices[i] - parameter.ClosingPrices[i - 1];
                    double percentagePriceChange = priceChange / parameter.ClosingPrices[i - 1];
                    vpt += percentagePriceChange * parameter.Volumes[i];
                    vptValues.Add(vpt);
                }
            }

            return new VptIndicatorResult { VptValues = [.. vptValues] };
        }
    }
}
