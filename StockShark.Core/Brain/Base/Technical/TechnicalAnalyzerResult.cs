namespace StockShark.Core.Brain.Base.Technical
{
    public abstract class TechnicalAnalyzerSignalScoreResult : ITechnicalAnalyzerResult
    {
        public double SignalScore { get; set; }
    }
}
