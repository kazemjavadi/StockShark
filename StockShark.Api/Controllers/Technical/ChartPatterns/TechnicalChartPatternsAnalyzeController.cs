using Microsoft.AspNetCore.Mvc;
using StockShark.Api.Controllers.Technical.ChartPatterns.Dto;
using StockShark.ApplicationService.Histories;
using StockShark.ApplicationService.Technical.ChartPatterns.AnalyzeAscendingTriangle;
using StockShark.ApplicationService.Technical.ChartPatterns.AnalyzeFlagsAndPennants;
using StockShark.ApplicationService.Technical.ChartPatterns.DescendingTriangle;
using StockShark.ApplicationService.Technical.ChartPatterns.SymmetricalTriangle;

namespace StockShark.Api.Controllers.Technical.ChartPatterns
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class TechnicalChartPatternsAnalyzeController : ControllerBase
    {
        private readonly AnalyzeFlagsAndPennantsApplicationService _analyzeFlagsAndPennantsApplicationService;
        private readonly AnalyzeAscendingTriangleApplicationService _analyzeAscendingTriangleApplicationService;
        private readonly AnalyzeDescendingTriangleApplicationService _analyzeDescendingTriangleApplicationService;
        private readonly AnalyzeSymmetricalTriangleApplicationService _analyzeSymmetricalTriangleApplicationService;

        public TechnicalChartPatternsAnalyzeController(AnalyzeFlagsAndPennantsApplicationService analyzeFlagsAndPennantsApplicationService,
            AnalyzeAscendingTriangleApplicationService analyzeAscendingTriangleApplicationService,
            AnalyzeDescendingTriangleApplicationService analyzeDescendingTriangleApplicationService,
            AnalyzeSymmetricalTriangleApplicationService analyzeSymmetricalTriangleApplicationService)
        {
            _analyzeFlagsAndPennantsApplicationService = analyzeFlagsAndPennantsApplicationService;
            _analyzeAscendingTriangleApplicationService = analyzeAscendingTriangleApplicationService;
            _analyzeDescendingTriangleApplicationService = analyzeDescendingTriangleApplicationService;
            _analyzeSymmetricalTriangleApplicationService = analyzeSymmetricalTriangleApplicationService;
        }


        [HttpPost]
        public async Task<IActionResult> AnalyzeFlagsAndPennants([FromBody] AnalyzeFlagsAndPennantsRequest input)
        {
            var result = await _analyzeFlagsAndPennantsApplicationService.Execute(new() { Period = input.Period, Symbol = input.Symbol });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AnalyzeAscendingTriangle([FromBody] AnalyzeAscendingTriangleRequest input)
        {
            var result = await _analyzeAscendingTriangleApplicationService.Execute(new() { Period = input.Period, Symbol = input.Symbol });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AnalyzeDescendingTriangle([FromBody] AnalyzeDescendingTriangleRequest input)
        {
            var result = await _analyzeDescendingTriangleApplicationService.Execute(new() { Period = input.Period, Symbol = input.Symbol });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AnalyzeSymmetricalTriangle([FromBody] AnalyzeSymmetricalTriangleRequest input)
        {
            var result = await _analyzeSymmetricalTriangleApplicationService.Execute(new() { Period = input.Period, Symbol = input.Symbol });

            return Ok(result);
        }
    }
}
