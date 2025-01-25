using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShark.ApplicationService.Base
{
    public interface IApplicationService<TInput, TOutput>
    {
        Task<TOutput> Execute(TInput input);
    }
}
