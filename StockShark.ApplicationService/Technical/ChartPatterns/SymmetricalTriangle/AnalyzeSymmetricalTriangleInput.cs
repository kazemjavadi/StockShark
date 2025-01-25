using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShark.ApplicationService.Technical.ChartPatterns.SymmetricalTriangle
{
    public class AnalyzeSymmetricalTriangleInput
    {
        public int Period { get; set; } = 0;
        public string Symbol { get; set; } = string.Empty;
    }
}
