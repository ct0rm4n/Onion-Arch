using Application.Dto.Wrappers;
using Application.ViewModels.Post;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace UI.Client.Components.Post
{
    public partial class PostListPagged
    {
        [Inject]
        IConfiguration Configuration { get; set; }
        private readonly HttpClient _client = new HttpClient();
        public List<PostVM> listPosts { get; set;  }
        int PageIndex = 0;
        int TotalPages = 1;
        
        protected override async Task OnInitializedAsync()
        {
            var respose = new PagedResponse<List<PostVM>>(null, 0, int.MaxValue);
            if (listPosts is null)
            {
                PageIndex = 1;
                respose = await _client.GetFromJsonAsync<PagedResponse<List<PostVM>>>($"{Configuration["ApiRest"]}api/post/getall?PageSize=6");
                listPosts = respose.Data;
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
            var respose = await _client.GetFromJsonAsync<PagedResponse<List<PostVM>>>($"{Configuration["ApiRest"]}api/post/getall?PageNumber={page}&PageSize=6");
            listPosts = respose.Data;
            StateHasChanged();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }


    }
}
