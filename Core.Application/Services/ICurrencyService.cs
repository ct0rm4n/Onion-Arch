
using Application;
using Application.Dto.DTOs;
using Application.ViewModels.CurrencyLocale;
using Core.Domain.Entities.Concrates.Catalog;
using Services;

namespace Service.Interface.Services
{
    public interface ICurrencyService : IGenericService<CurrencyLocaleSaveVM, CurrencyLocaleVM, CurrencyLocale>
    {
        public Task<CurrencyDto> GetCurrencyBRL(string[] currencyName);
        public Task UpdateCurrencyGlobal(CurrencyDto rawReponse);
    }
}
