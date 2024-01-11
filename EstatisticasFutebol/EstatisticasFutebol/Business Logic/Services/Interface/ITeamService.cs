using EstatisticasFutebol.Data.Models;

namespace EstatisticasFutebol.Business_Logic.Services.Interface
{
    public interface ITeamService
    {
        TeamProfile GetNewAwayProfile(MatchData match);
        TeamProfile GetNewHomeProfile(MatchData match);
        TeamProfile GetNormalizedProbabilites(TeamProfile probabilities);
    }
}
