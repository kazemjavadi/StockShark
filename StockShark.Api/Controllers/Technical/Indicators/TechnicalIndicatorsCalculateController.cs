using Microsoft.AspNetCore.Mvc;
using StockShark.Api.Controllers.Histories.Dto;
using StockShark.Api.Controllers.Technical.ChartPatterns.Dto;
using StockShark.ApplicationService.Histories;
using StockShark.ApplicationService.Technical.ChartPatterns.AnalyzeAscendingTriangle;
using StockShark.ApplicationService.Technical.ChartPatterns.AnalyzeFlagsAndPennants;
using StockShark.ApplicationService.Technical.ChartPatterns.DescendingTriangle;
using StockShark.ApplicationService.Technical.ChartPatterns.SymmetricalTriangle;
using StockShark.ApplicationService.Technical.Indicators.Momentum.Momentumz;

namespace StockShark.Api.Controllers.Technical.ChartPatterns
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class TechnicalIndicatorsCalculateController : ControllerBase
    {
        private readonly CalculateMACDApplicationService _calculateMACDApplicationService;
        private readonly CalculateRSIApplicationService _calculateRSIApplicationService;

        public TechnicalIndicatorsCalculateController(CalculateMACDApplicationService calculateMACDApplicationService,
            CalculateRSIApplicationService calculateRSIApplicationService)
        {
            this._calculateMACDApplicationService = calculateMACDApplicationService;
            this._calculateRSIApplicationService = calculateRSIApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateMacd([FromBody] CalculateMACDRequest input)
        {
            var result = await _calculateMACDApplicationService.Execute(new()
            {
                ShortEMAPeriod = input.ShortEMAPeriod,
                LongEMAPeriod = input.LongEMAPeriod,
                SignalEMAPeriod = input.SignalEMAPeriod,
                Symbol = input.Symbol,

                HistogramAveragePeriod = input.HistogramAveragePeriod,
                PositiveThreshold = input.PositiveThreshold,
                NegativeThreshold = input.NegativeThreshold
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CalculateRsi([FromBody] CalculateRsiRequest input)
        {
            var result = await _calculateRSIApplicationService.Execute(new(){Symbol = input.Symbol});

            return Ok(result);
        }
    }
}
