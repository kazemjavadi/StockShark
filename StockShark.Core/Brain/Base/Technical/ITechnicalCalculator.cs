namespace StockShark.Core.Brain.Base.Technical
{
    internal interface ITechnicalCalculator<TResult, TParameter>
        where TResult : ITechnicalCalculatorResult
        where TParameter : ITechnicalCalculatorParameter
    {
        TResult Calculate(TParameter parameter);
    }
}
