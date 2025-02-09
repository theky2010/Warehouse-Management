using AutoMapper;
using WareHouseManagment.Dto;
using WareHouseManagment.Models;

namespace WareHouseManagment.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<ProductDto, Product>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserRoleDto, UserRole>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierDto, Supplier>();
            CreateMap<InboundTransaction, InboundTransactionDto>();
            CreateMap<InboundTransactionDto, InboundTransaction>();
            CreateMap<Inventory, InventoryDto>();
            CreateMap<InventoryDto, Inventory>();
            CreateMap<InboundTransactionDetail, InboundTransactionDetailDto>();
            CreateMap<InboundTransactionDetailDto, InboundTransactionDetail>();
            CreateMap<OutboundTransaction, OutboundTransactionDto>();
            CreateMap<OutboundTransactionDto, OutboundTransaction>();
            CreateMap<OutboundTransactionDetail, OutboundTransactionDetailDto>();
            CreateMap<OutboundTransactionDetailDto, OutboundTransactionDetail>();

        }
    }
}