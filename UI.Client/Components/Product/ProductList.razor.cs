using Application.Dto.Wrappers;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using ViewModels.Product;

namespace UI.Client.Components.Product
{
    public partial class ProductList
    {
        [Inject]
        IConfiguration Configuration { get; set; }
        private readonly HttpClient _client = new HttpClient();
        public List<ProductVM> listProduct { get; set; }
        int PageIndex = 0;
        int TotalPages = 1;

        protected override async Task OnInitializedAsync()
        {
            var respose = new PagedResponse<List<ProductVM>>(null, 0, int.MaxValue);
            if (listProduct is null)
            {
                PageIndex = 1;
                respose = await _client.GetFromJsonAsync<PagedResponse<List<ProductVM>>>($"{Configuration["ApiRest"]}api/product/getall?PageSize=6");
                listProduct = respose.Data;
                TotalPages = respose.TotalPages;
            }
            await base.OnInitializedAsync();
        }
        public async Task SelectedPage(int index)
        {
            PageIndex = index + 1;
            await OpenPage(index);
        }
        private async Task OpenPage(int page)
        {
            PageIndex = page;
            var respose = await _client.GetFromJsonAsync<PagedResponse<List<ProductVM>>>($"{Configuration["ApiRest"]}api/product/getall?PageNumber={page}&PageSize=6");
            listProduct = respose.Data;
            StateHasChanged();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }


    }
}
