using AutoMapper;
using Q1.Models;

namespace Q1
{
    public class MapperConfig : Profile
    {        
        public MapperConfig()
        {            
            CreateMap<SheduleDto, Schedule>().ReverseMap();                        
        }
    }
}
