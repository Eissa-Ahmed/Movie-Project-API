using Movie.DAL.Entity;

namespace Movie.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<GenersDTO, Gener>().ReverseMap();
            CreateMap<UpdateGenerDTO, Gener>().ReverseMap();
            CreateMap<GenerMovieDTO, Gener>().ForMember(
                i => i.Movies, c => c.MapFrom(m => m.MovieDTO)
                ).ReverseMap();
            CreateMap<Movies, MovieDTO>().ReverseMap();
            CreateMap<Movies, UpdateMovieDTO>().ReverseMap();
        }
    }
}
