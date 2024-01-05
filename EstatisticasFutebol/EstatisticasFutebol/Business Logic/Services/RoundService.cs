using EstatisticasFutebol.Business_Logic.Services.Interface;
using EstatisticasFutebol.Data.Enum;
using EstatisticasFutebol.Data.Models;

namespace EstatisticasFutebol.Business_Logic.Services
{
    public class RoundService : IRoundService
    {
        private readonly ITeamService _teamService;

        public RoundService(ITeamService teamService)
        {
            _teamService = teamService;
        }
        public Team SimulateRound(List<Team> teams)
        {
            
        }
    }
}
