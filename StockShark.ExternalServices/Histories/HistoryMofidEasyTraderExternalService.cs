using StockShark.Contracts.Histories.EternalServices;
using StockShark.ExternalServices.Histories;
using StockShark.Helper;
using System.Text.Json;

namespace StockShark.ExternalServices
{
    public class HistoryMofidEasyTraderExternalService : IHistoryExternalService
    {
        private readonly MofidEasyTraderExternalServiceConfig _config;

        public HistoryMofidEasyTraderExternalService(MofidEasyTraderExternalServiceConfig config)
        {
            this._config = config;
        }

        public async Task<string?> GetHistory(GetHistoryExternalServiceQuery query)
        {
            GetHistoryExternalServiceResult? resultObject = null;

            long from = query.From.ToUnixTimestamp();
            long to = query.To.ToUnixTimestamp();

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), 
                    
                    $"https://api-mts.orbis.easytrader.ir/chart/api/datafeed/history?symbol={query.Symbol.Trim()}%3A1&resolution=1D&from={from}&to={to}&countback=2"))
                {
                    request.Headers.TryAddWithoutValidation("sec-ch-ua", "\"Chromium\";v=\"128\", \"Not;A=Brand\";v=\"24\", \"Microsoft Edge\";v=\"128\"");
                    request.Headers.TryAddWithoutValidation("Accept-language", "fa");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                    request.Headers.TryAddWithoutValidation("Authorization", _config.Token);
                    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/128.0.0.0 Safari/537.36 Edg/128.0.0.0");
                    request.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
                    request.Headers.TryAddWithoutValidation("Referer", "https://d.easytrader.ir/");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");

                    var response = await httpClient.SendAsync(request);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        resultObject = JsonSerializer.Deserialize<GetHistoryExternalServiceResult>(await response.Content.ReadAsStringAsync());
                    }

                }
            }

            if (resultObject == null)
                return null;

            return JsonSerializer.Serialize( new {time = resultObject.t,
                close =  resultObject.c, 
                open = resultObject.o,
                high = resultObject.h,
                low = resultObject.l,
                volume = resultObject.v
            });
        }
    }
}
