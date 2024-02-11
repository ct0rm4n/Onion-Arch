using Core.Domain.Entities.Concrates.Catalog;
using Application.Dto.ViewModels.Banner;
using Microsoft.AspNetCore.Components.Forms;

namespace Services
{
    public interface IBannerService : IGenericService<BannerSaveVM, BannerVM, Banner>
    {
        public Task<List<BannerVM>> GetList();
        public Task<BannerVM> CreateOrUpdate(BannerVM model);
        Task<(int, string)> UploadAsync(IBrowserFile arquivo, int tamanhoMaximoPermitido, string[] extensoesPermitidas);
    }
}
