using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShark.ApplicationService.Technical.Indicators.Momentum.Momentum
{
    public class AnalyzeRSIInput
    {
        public int LookbackPeriod { get; set; } = 14;
        public string Symbol { get; set; } = string.Empty;

    }
}
