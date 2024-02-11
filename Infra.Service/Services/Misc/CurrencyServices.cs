using Application.Dto.DTOs;
using RestSharp;
using System.Text.Json;
namespace Service.Application.Services.Misc
{
    public class CurrencyServices
    {
        //USD-BRL,EUR-BRL,BTC-BRL
        public async Task<string> GetCurrencyBRL(string[] currencyName)
        {
            var options = new RestClientOptions("https://economia.awesomeapi.com.br")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest($"/last/{string.Join(",", currencyName)}", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            return response.Content;
        }
        public async Task UpdateCurrencyGlobal(string rawReponse)
        {
            try
            {
                var currencyList = JsonSerializer.Deserialize<CurrencyDto>(rawReponse);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
