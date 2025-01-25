using Microsoft.AspNetCore.Mvc;
using StockShark.Api.Controllers.Histories.Dto;
using StockShark.ApplicationService.Histories;

namespace StockShark.Api.Controllers.Histories
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class HistoryController : ControllerBase
    {
        private readonly UpdateHistoryDataApplicationService _updateHistoryDataApplicationService;

        public HistoryController(UpdateHistoryDataApplicationService updateHistoryDataApplicationService)
        {
            _updateHistoryDataApplicationService = updateHistoryDataApplicationService;
        }


        [HttpPost]
        public async Task<IActionResult> UpdateShareHistory([FromBody]UpdateHistoryInput input)
        {
            await _updateHistoryDataApplicationService.Execute(new() { From = input.From, To = input.To, Symbols = input.Symbols });

            return Ok();
        }
    }
}
