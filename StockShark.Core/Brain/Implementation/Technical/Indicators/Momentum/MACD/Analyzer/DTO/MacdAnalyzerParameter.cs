using StockShark.Core.Brain.Base.Technical;
using System.Buffers.Text;
using System.Diagnostics.Metrics;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.MACD.Analyzer.DTO
{
    public class MacdAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public double[] MacdLine { get; set; } = [];
        public double[] SignalLine { get; set; } = [];
        public double[] Histogram { get; set; } = [];
        //If averagePeriod is 3, the method will take the average of the last 3 histogram values.
        public int HistogramAveragePeriod { get; set; } = 3;

        //The positiveThreshold and negativeThreshold are thresholds that help define
        //the boundaries for a strong buy or sell signal based on the MACD histogram values.
        public double PositiveThreshold { get; set; } = 0.1;
        public double NegativeThreshold { get; set; } = -0.1;
    }
}
