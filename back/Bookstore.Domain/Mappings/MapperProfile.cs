using AutoMapper;
using Bookstore.Domain.DTO;
using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Mappings
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BookRequestDTO, Book>();
            CreateMap<Book, BookResponseDTO>()
                .ForMember(dest => dest.Category, map => map.MapFrom(src => src.Category.Name));
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
