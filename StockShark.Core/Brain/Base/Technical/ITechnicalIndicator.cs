namespace StockShark.Core.Brain.Base.Technical
{
    internal interface ITechnicalIndicator<TResult, TParameter>
        where TResult : ITechnicalIndicatorResult
        where TParameter : ITechnicalIndicatorParameter
    {
        TResult Calculate(TParameter parameter);
    }
}
