namespace StockShark.Core.Brain.Base.Technical
{
    internal interface ITechnicalAnalyzer<TResult, TParameter>
        where TResult : ITechnicalAnalyzerResult
        where TParameter : ITechnicalAnalyzerParameter
    {
        TResult Analyze(TParameter parameter);
    }
}
