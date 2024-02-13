using Application.Dto.DTOs;
using Application.Repositories;
using Application.ViewModels.CurrencyLocale;
using AutoMapper;
using Core.Domain.Entities.Concrates.Catalog;
using RestSharp;
using Service.Interface.Services;
using Services;
using System.Text.Json;
namespace Service.Application.Services.Misc
{
    public class CurrencyService : GenericService<CurrencyLocaleSaveVM, CurrencyLocaleVM, CurrencyLocale>, ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepositor;
        public CurrencyService(IGenericRepository<CurrencyLocale> repository, IMapper mapper, ICurrencyRepository currencyRepositor) : base(repository, mapper)
        {
            _currencyRepositor = currencyRepositor;
        }
        
        public async Task<CurrencyDto> GetCurrencyBRL(string[] currencyName)
        {
            var options = new RestClientOptions("https://economia.awesomeapi.com.br")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest($"/last/{string.Join(",", currencyName)}", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            return JsonSerializer.Deserialize<CurrencyDto>(response.Content);            
        }
        public async Task UpdateCurrencyGlobal(CurrencyDto rawReponse)
        {
            try
            {
                var list =  new List<CurrencyLocale>();
                list.Add(_mapper.Map<CurrencyLocale>(rawReponse.USDBRL));
                list.Add(_mapper.Map<CurrencyLocale>(rawReponse.BTCBRL));
                list.Add(_mapper.Map<CurrencyLocale>(rawReponse.EURBRL));
                await _currencyRepositor.AddRangeAsync(list);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
