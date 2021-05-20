using AutoMapper;
using NudgeDigital.Application.Features.Configurations.Command;
using NudgeDigital.Application.Features.Configurations.Queries;
using NudgeDigital.Application.Features.Laptops.Command;
using NudgeDigital.Application.Features.Laptops.Query;
using NudgeDigital.Application.Features.LaptopConfigs;
using NudgeDigital.Domain.Entities;
using NudgeDigital.Application.Features.Brands.Queries;
using NudgeDigital.Application.Features.Components.Queries;
using System.Linq;
using NudgeDigital.Application.Features.LaptopConfiguration.Query;

namespace NudgeDigital.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<CreateConfigurationCommand, Configuration>().ReverseMap();
            
            CreateMap<Configuration, ConfigurationVM>()
                .ForMember(x => x.Name, m => m.MapFrom(y => y.ComponentType))
                .ReverseMap();

            CreateMap<CreateLaptopCommand, Laptop>().ReverseMap();
            CreateMap<Laptop, LaptopVM>()
                 .ForMember(x => x.Configurations, m => m.MapFrom(y => y.Configurations.Select(s=> s.Configuration.ComponentType)))
                 .ForMember(x => x.Brand, m => m.MapFrom(y => y.Brand.Name))
                 .ForMember(x => x.Price, m => m.MapFrom(y => y.Brand.Price + y.Configurations.Sum(s => s.Configuration.Price)))
                .ReverseMap();

            CreateMap<CreateLaptopConfigurationCommand, LaptopConfiguration>().ReverseMap();
            CreateMap<Brand, BrandVM>().ReverseMap();
            CreateMap<Component, ComponentVM>().ReverseMap();


            CreateMap<ShoppingBasket, CartVM>()
                 .ForMember(x => x.ItemId, m => m.MapFrom(y => y.LaptopId))
                 .ForMember(x => x.ItemName, m => m.MapFrom(y => y.Laptop.Name))
                  .ForMember(x => x.Configurations, m => m.MapFrom(y => y.Laptop.Configurations.Select(s => s.Configuration.ComponentType)))
                .ReverseMap();

        }
    }
}
