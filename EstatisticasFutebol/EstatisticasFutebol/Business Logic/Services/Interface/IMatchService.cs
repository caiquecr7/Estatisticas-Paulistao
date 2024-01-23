using EstatisticasFutebol.Data.Entities;
using EstatisticasFutebol.Data.Entities.Simulation;

namespace EstatisticasFutebol.Business_Logic.Services.Interface
{
    public interface IMatchService
    {
        Task<List<SimulationMatch>> ReadMatches(List<RoundMatches> matches, List<Team> allTeams);
        List<SimulationTeam> GetSimulationTeams(List<Team> teams);
        SimulationHomeProfile GetSimulationHomeProfile(HomeProfile homeProfile);
        SimulationAwayProfile GetSimulationAwayProfile(AwayProfile awayProfile);
    }
}
