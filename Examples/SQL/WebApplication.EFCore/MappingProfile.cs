using AutoMapper;
using Database.EFCore.Entities;

namespace WebApplication.EFCore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<BookEntity, BookSummary>()
                .ForMember(
                    dst => dst.BookCategory,
                    opt => opt.MapFrom(src => src.Category.Category));
        }
    }
}