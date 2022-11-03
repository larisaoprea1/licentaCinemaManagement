using AutoMapper;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.ProductionViewModels;

namespace CinemaManagement.Profiles.ProductionProfiles
{
    public class ProductionProfile : Profile
    {
        public ProductionProfile()
        {
            CreateMap<Production, ProductionViewModel>();
            CreateMap<ProductionViewModel, Production>();
            CreateMap<ProductionForCreateViewModel, Production>();
            //CreateMap<MovieForUpdateViewModel, Movie>();

        }
    }
}
