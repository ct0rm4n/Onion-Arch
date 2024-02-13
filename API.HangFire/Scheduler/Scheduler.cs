using Service.Application.Services.Misc;
using Service.Interface.Services;

namespace API.HangFire.Scheduler
{
    public class Scheduler
    {
        public ICurrencyService currencyService { get; set; }

        public void Run()
        {
            try
            {
                currencyService.UpdateCurrencyGlobal(currencyService.GetCurrencyBRL(new string[] { "USD-BRL", "EUR-BRL", "BTC-BRL" }).Result);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
