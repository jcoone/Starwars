using API.Data.DTOs;
using API.Entitys;
using AutoMapper;

namespace API.helper
{
    public class AutoProfiling : Profile
    {

        // I need to add a mapper to return the same json values.
        public AutoProfiling()
        {
            CreateMap<Films, FilmDto>();
        }
    }
}