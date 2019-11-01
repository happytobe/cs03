using AutoMapper;
using TC_CS03_API.Domain.Entity;
using TC_CS03_API.DTO;

namespace TC_CS03_API.Helpers
{
    /// <summary>
    /// Class to define the mappings between DTOs and Entity models
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReviewRatingType, ReviewRatingTypeDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>().ReverseMap();
        }
    }
}
