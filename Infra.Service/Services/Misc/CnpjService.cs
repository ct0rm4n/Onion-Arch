using Application.Dto.DTOs;
using RestSharp;
using System.Text.Json;

namespace Service.Application.Services.Misc
{
    public class CnpjService
    {

        public async Task<CnpjDto> GetCnpj(string cnpj)
        {
            var options = new RestClientOptions($"https://brasilapi.com.br")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest($"/cnpj/v1/{cnpj}", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);            
            return JsonSerializer.Deserialize<CnpjDto>(response.Content);
        }
    }

}
