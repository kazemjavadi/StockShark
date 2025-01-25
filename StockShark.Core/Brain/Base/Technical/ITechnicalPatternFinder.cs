namespace StockShark.Core.Brain.Base.Technical
{
    internal interface ITechnicalPatternFinder<TResult, TParameter>
        where TResult : ITechnicalPatternFinderResult
        where TParameter : ITechnicalPatternFinderParameter
    {
        TResult Recognize(TParameter parameter);
    }
}
