using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShark.Contracts.Shares.Repository
{
    public class GetShareBySymbolQuery
    {
        public string Symbol { get; set; } = string.Empty;
    }
}
