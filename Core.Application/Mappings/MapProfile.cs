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
using Core.Domain.Entities.Concrates.Catalog;
using Application.ViewModels.Post;
using Application;
using Application.Dto.ViewModels.Product;

namespace Mapping
{
    public sealed class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Product Mapping
            CreateMap<Product, ProductVM>()
                    .ForMember(dest => dest.Category, act => act.MapFrom(src => src.Category))
                    .ForMember(dest => dest.Variants, act => act.MapFrom(src => src.Variants))
                    .ForMember(dest => dest.Images, act => act.MapFrom(src => src.Images))
                    .ReverseMap();
            
            CreateMap<ProductVM, ProductSaveVM>().ReverseMap();
            #endregion

            #region Category Mapping
            CreateMap<Category, CategorySaveVM>()
                     .ReverseMap();
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<IEnumerable<Category>, List<CategoryVM>>().ReverseMap();
            #endregion

            #region ProductFeature Mapping
            //CreateMap<ProductFeature, ProductFeatureVM>()
            //        .ReverseMap();
            //CreateMap<ProductFeature, ProductFeatureSaveVM>()
            //    .ReverseMap();
            #endregion

            #region Supplier Mapping
            //CreateMap<Supplier, SupplierVM>()
            //         .ForMember(dest => dest.ProductSupplierVMs, act => act.MapFrom(src => src.ProductSuppliers))
            //         .ReverseMap();
            //CreateMap<Supplier, SupplierSaveVM>()
            //        .ReverseMap(); ;
            #endregion

            #region ProductSupplier Mapping
            //CreateMap<ProductSupplier, ProductSupplierVM>()
            //         .ForMember(dest => dest.ProductVM, act => act.MapFrom(src => src.Product))
            //         .ForMember(dest => dest.SupplierVM, act => act.MapFrom(src => src.Supplier))
            //         .ReverseMap();
            //CreateMap<ProductSupplier, ProductSupplierSaveVM>()
            //         .ForMember(dest => dest.ProductVM, act => act.MapFrom(src => src.Product))
            //         .ForMember(dest => dest.SupplierVM, act => act.MapFrom(src => src.Supplier))
            //         .ReverseMap();

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
            #endregion
            #region ToDo Mapping
            CreateMap<ToDo, ToDoVM>()
                .ReverseMap();
            #endregion

            CreateMap<ProductType, ProductTypeSaveVM>().ReverseMap();
            CreateMap<ProductType, ProductTypeVM>().ReverseMap();
            CreateMap<IEnumerable<ProductType>, List<ProductTypeVM>>().ReverseMap();
            #region Post Mapping
            CreateMap<Post, PostVM>()
                .ReverseMap();
            CreateMap<Post, PostSaveVM>()
                .ReverseMap();
            #endregion
        }
    }
}