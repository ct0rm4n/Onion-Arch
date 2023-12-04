using Application.Repositories;
using AutoMapper;
using Domain.Entities.Concrates;
using ViewModels.ProductSupplier;
using Wrappers;

namespace Services
{
    public class ProductSupplierService : GenericService<ProductSupplierSaveVM, ProductSupplierVM, ProductSupplier>, IProductSupplierService
    {
        private readonly IProductSupplierRepository _productSupplierRepository;
        public ProductSupplierService(IGenericRepository<ProductSupplier> repository, IMapper mapper, IProductSupplierRepository productSupplierRepository) : base(repository, mapper)
        {
            _productSupplierRepository = productSupplierRepository;
        }

        public async Task<Result<List<ProductSupplierVM>>> GetProductSupplierWithProductAndSupplier()
        {

            List<ProductSupplier> result = (await _productSupplierRepository.GetProductSupplierWithProductAndSupplier()).ToList();
            List<ProductSupplierVM> productSupplierVMs = _mapper.Map<List<ProductSupplierVM>>(result);
            return Result<List<ProductSupplierVM>>.Success(productSupplierVMs);

        }
    }
}
