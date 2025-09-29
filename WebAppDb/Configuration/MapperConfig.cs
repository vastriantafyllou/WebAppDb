using AutoMapper;
using WebAppDb.DTO;
using WebAppDb.Models;

namespace WebAppDb.Configuration;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<StudentInsertDto, Student>().ReverseMap();
        CreateMap<StudentUpdateDto, Student>().ReverseMap();
        CreateMap<StudentReadOnlyDto, Student>().ReverseMap();
    }
}