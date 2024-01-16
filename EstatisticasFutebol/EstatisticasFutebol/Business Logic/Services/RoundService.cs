using EstatisticasFutebol.Business_Logic.ApiServices;
using EstatisticasFutebol.Business_Logic.ApiServices.Interface;
using EstatisticasFutebol.Business_Logic.Services.Interface;
using EstatisticasFutebol.Data.Enum;
using EstatisticasFutebol.Data.Entities;

namespace EstatisticasFutebol.Business_Logic.Services
{
    public class RoundService : IRoundService
    {
        private readonly ITeamService _teamService;
        private readonly IRoundApiService _roundApiService;

        public RoundService(ITeamService teamService, IRoundApiService roundApiService)
        {
            _teamService = teamService;
            _roundApiService = roundApiService;
        }
        public void SimulateRound()
        {
            var round = _roundApiService.GetOneRound(1).Result;
            foreach(var match in round.Matches)
            {
                Console.WriteLine(match.Score.ToString());
            }
        }
    }
}
