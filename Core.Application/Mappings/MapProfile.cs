using AutoMapper;
using ViewModels.Account;
using ViewModels.AppRole;
using ViewModels.AppUser;
using ViewModels.AppUserRole;
using ViewModels.Category;
using ViewModels.Product;
using ViewModels.ProductFeature;
using ViewModels.ProductSupplier;
using ViewModels.AppRole;
using ViewModels.Supplier;
using Domain.Entities.Concrates;
using Application.ViewModels.ToDo;

namespace Mapping
{
    public sealed class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Product Mapping
            CreateMap<Product, ProductVM>()
                    .ForMember(dest => dest.CategoryVM, act => act.MapFrom(src => src.Category))
                    .ForMember(dest => dest.ProductFeatureVM, act => act.MapFrom(src => src.ProductFeature))
                    .ForMember(dest => dest.ProductSupplierVMs, act => act.MapFrom(src => src.ProductSuppliers))
                    .ReverseMap();
            CreateMap<Product, ProductSaveVM>()
                .ForMember(dest => dest.SupplierIDs, act => act.MapFrom(src => src.ProductSuppliers.Select(x => x.Supplier).Select(x => x.Id)))
                .ForMember(dest => dest.ProductFeatureSaveVM, act => act.MapFrom(src => src.ProductFeature))
                .ForMember(dest => dest.ProductSupplierVMs, act => act.MapFrom(src => src.ProductSuppliers))
                .ReverseMap();
            CreateMap<ProductVM, ProductSaveVM>().ReverseMap();
            #endregion

            #region Category Mapping
            CreateMap<Category, CategorySaveVM>()
                     .ReverseMap();
            CreateMap<Category, CategoryVM>()
                      .ForMember(dest => dest.ProductVMs, act => act.MapFrom(src => src.Products))
                      .ForMember(dest => dest.Childreen, act => act.MapFrom(src => src.Children))
                      .ReverseMap();
            #endregion

            #region ProductFeature Mapping
            CreateMap<ProductFeature, ProductFeatureVM>()
                    .ReverseMap();
            CreateMap<ProductFeature, ProductFeatureSaveVM>()
                .ReverseMap();
            #endregion

            #region Supplier Mapping
            CreateMap<Supplier, SupplierVM>()
                     .ForMember(dest => dest.ProductSupplierVMs, act => act.MapFrom(src => src.ProductSuppliers))
                     .ReverseMap();
            CreateMap<Supplier, SupplierSaveVM>()
                    .ReverseMap(); ;
            #endregion

            #region ProductSupplier Mapping
            CreateMap<ProductSupplier, ProductSupplierVM>()
                     .ForMember(dest => dest.ProductVM, act => act.MapFrom(src => src.Product))
                     .ForMember(dest => dest.SupplierVM, act => act.MapFrom(src => src.Supplier))
                     .ReverseMap();
            CreateMap<ProductSupplier, ProductSupplierSaveVM>()
                     .ForMember(dest => dest.ProductVM, act => act.MapFrom(src => src.Product))
                     .ForMember(dest => dest.SupplierVM, act => act.MapFrom(src => src.Supplier))
                     .ReverseMap();

            #endregion

            #region AppUser Mapping
            CreateMap<AppUser, AppUserVM>()
                .ForMember(dest => dest.AppUserRoleVMs, act => act.MapFrom(src => src.UserRoles))
                    .ReverseMap()
                .ReverseMap();
            CreateMap<AppUser, AppUserSaveVM>()
                .ReverseMap();
            #endregion

            #region AppRole Mapping
            CreateMap<AppRole, AppRoleVM>()
                .ReverseMap();
            CreateMap<AppRole, AppRoleSaveVM>()
                .ReverseMap();
            #endregion

            #region AppUserRole Mapping
            CreateMap<AppUserRole, AppUserRoleVM>()
                .ForMember(dest => dest.AppUserVM, act => act.MapFrom(src => src.User))
                .ForMember(dest => dest.AppRoleVM, act => act.MapFrom(src => src.Role))
                .ReverseMap();
            CreateMap<ToDo, ToDoVM>()
                .ReverseMap();
            #endregion
        }
    }
}