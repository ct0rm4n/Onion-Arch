using Application.Repositories;
using AutoMapper;
using Domain.Entities.Concrates;
using ViewModels.Supplier;
using Wrappers;

namespace Services
{
    public class SupplierService : GenericService<SupplierSaveVM, SupplierVM, Supplier>, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(IGenericRepository<Supplier> repository, IMapper mapper, ISupplierRepository supplierRepository) : base(repository, mapper)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<SupplierListVM> GetSuppliersWithProducts()
        {
            List<Supplier> suppliers = (await _supplierRepository.GetSuppliersWithProducts()).ToList();
            List<SupplierVM> supplierVMs = _mapper.Map<List<SupplierVM>>(suppliers);
            Result<List<SupplierVM>> result = Result<List<SupplierVM>>.Success(supplierVMs);
            return new SupplierListVM { Result = result };
        }
    }
}
