using AutoMapper;
using Application.Repositories;
using Application.Dto.ViewModels.Banner;
using Core.Domain.Entities.Concrates.Catalog;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace Services
{
    public class BannerService : GenericService<BannerSaveVM, BannerVM, Banner>, IBannerService
    {
        private readonly IBannerRepository _bannerrepository;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<BannerService> _logger;
        public BannerService(IGenericRepository<Banner> repository, IMapper mapper, IBannerRepository bannerrepository, IWebHostEnvironment environment, ILogger<BannerService> logger) : base(repository, mapper)
        {
            _bannerrepository = bannerrepository;
            _environment = environment;
            _logger = logger;
        }

        public async Task<List<BannerVM>> GetList()
        {
            List<BannerVM> bannerVMs = new List<BannerVM>();
            List<Banner> list = _bannerrepository.GetAllAsIQueryable().ToList();
            foreach (var itemEntity in list)
            {
                bannerVMs.Add(_mapper.Map<BannerVM>(itemEntity));
            }
            return bannerVMs;
        }
        public async Task<BannerVM> CreateOrUpdate(BannerVM model)
        {
            Banner banner = _mapper.Map<Banner>(model);
            
            if(banner.Id is not 0 && banner.Id > 0)
            {
                var old = await _bannerrepository.FirstOrDefaultAsync(x => x.Id == model.Id);
                banner.InsertedDate = old.InsertedDate;
                if(model.Binary is null) {
                    model.Binary = old.Binary;
                    model.Name = old.Name;
                }
                await _repository.UpdateAsync(banner);
            }
            else
            {
                await _repository.AddAsync(banner);
            }
            return model;
        }
        public async Task<(int, string)> UploadAsync(IBrowserFile arquivo,
                                                        int tamanhoMaximoPermitido,
                                                        string[] extensoesPermitidas)
        {
            try
            {
                var diretorioUpload = Path.Combine(_environment.WebRootPath, "uploads");
                if (!Directory.Exists(diretorioUpload))
                {
                    Directory.CreateDirectory(diretorioUpload);
                }

                if (arquivo.Size > tamanhoMaximoPermitido)
                {
                    var mensagem = $"Arquivo: {arquivo.Name} excede o tamanho máximo permitido.";
                    _logger.LogInformation(mensagem);
                    return (0, mensagem);
                }

                var arquivoExtensao = Path.GetExtension(arquivo.Name);

                if (!extensoesPermitidas.Contains(arquivoExtensao))
                {
                    var mensagem = $"Arquivo: {arquivo.Name}, tipo de Arquivo não permitido";
                    _logger.LogInformation(mensagem);
                    return (0, mensagem);
                }

                var nomeArquivoSeguro = $"{Guid.NewGuid()}{arquivoExtensao}";
                var path = Path.Combine(diretorioUpload, nomeArquivoSeguro);
                await using var fs = new FileStream(path, FileMode.Create);
                await arquivo.OpenReadStream(tamanhoMaximoPermitido).CopyToAsync(fs);
                return (1, nomeArquivoSeguro);
            }
            catch(Exception ex)
            {
                return (1, ex.Message);
            }
        }
        
    }
}