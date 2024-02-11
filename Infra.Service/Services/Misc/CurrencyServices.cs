using RestSharp;
namespace Service.Application.Services.Misc
{
    public class CurrencyServices
    {
        //USD-BRL,EUR-BRL,BTC-BRL
        public async Task GetCurrencyBRL(string[] currencyName)
        {
            var options = new RestClientOptions("https://economia.awesomeapi.com.br")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest($"/last/{string.Join(",", currencyName)}", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }

    }
}
