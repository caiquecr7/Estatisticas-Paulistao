using EstatisticasFutebol.Data.Enum;
using EstatisticasFutebol.Data.Models;

namespace EstatisticasFutebol.Business_Logic.Services.Interface
{
    public interface IRoundService
    {
       Team SimulateRound(List<Team> teams);
       Task<double[]> SimulateMatch(Team homeTeam, Team awayTeam);

    }
}
