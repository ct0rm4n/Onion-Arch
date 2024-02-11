using Application.Dto.Wrappers;
using Application.Dto.ViewModels.Banner;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace UI.Client.Components.Banner
{
    public partial class BannerHome
    {

        [Inject]
        IConfiguration Configuration { get; set; }
        private readonly HttpClient _client = new HttpClient();
        public List<BannerVM> listBanner { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var respose = new PagedResponse<List<BannerVM>>(null, 0, int.MaxValue);
            if (listBanner is null)
            {
                respose = await _client.GetFromJsonAsync<PagedResponse<List<BannerVM>>>($"{Configuration["ApiRest"]}api/banner/getall?PageSize="+ int.MaxValue);
                listBanner = respose.Data;                
            }
            await base.OnInitializedAsync();
        }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }
    }
}
