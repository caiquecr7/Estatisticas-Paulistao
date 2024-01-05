using EstatisticasFutebol.Data.Models;

namespace EstatisticasFutebol.Business_Logic.Services.Interface
{
    public interface ITeamService
    {
        Task UpdateHomeProfile(Team team, double[] matchOdds);
        Task UpdateAwayProfile(Team team, double[] matchOdds);
    }
}
