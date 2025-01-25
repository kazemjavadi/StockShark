using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShark.ApplicationService.Technical.Indicators.Momentum.Momentumz
{
    public class AnalyzeMACDInput
    {
        public int ShortEMAPeriod { get; set; }
        public int LongEMAPeriod { get; set; }
        public int SignalEMAPeriod { get; set; }
        public string Symbol { get; set; } = string.Empty;

        public int HistogramAveragePeriod { get; set; } = 3;
        public double PositiveThreshold { get; set; } = 0.1;
        public double NegativeThreshold { get; set; } = -0.1;
    }
}
