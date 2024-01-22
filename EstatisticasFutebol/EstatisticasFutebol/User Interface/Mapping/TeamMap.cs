using AutoMapper;
using EstatisticasFutebol.Data.Entities;
using EstatisticasFutebol.User_Interface.Mapping.DTO;

namespace EstatisticasFutebol.User_Interface.Mapping
{
    public class TeamMap : Profile
    {
        public TeamMap() 
        {
            CreateMap<Team, TeamDTO>();

            CreateMap<TeamDTO, Team>();
        }
    }
}
