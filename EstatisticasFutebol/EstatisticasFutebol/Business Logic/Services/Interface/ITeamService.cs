using EstatisticasFutebol.Data.Entities;
using EstatisticasFutebol.Data.Entities.Simulation;

namespace EstatisticasFutebol.Business_Logic.Services.Interface
{
    public interface ITeamService
    {
        SimulationAwayProfile GetNewAwayProfile(SimulationMatch match);
        SimulationHomeProfile GetNewHomeProfile(SimulationMatch match);
        SimulationAwayProfile GetNormalizedAwayOdds(SimulationAwayProfile probabilities);
        SimulationHomeProfile GetNormalizedHomeOdds(SimulationHomeProfile probabilities);
        List<Team> GetClassifiedTeams(List<SimulationTeam> simulationTeams, List<Team> teams);
        Task GetConversionRate(List<Team> teams, int iterations);
    }
}
