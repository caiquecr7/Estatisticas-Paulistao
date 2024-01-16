using EstatisticasFutebol.Data.Entities;

namespace EstatisticasFutebol.Business_Logic.Services.Interface
{
    public interface ITeamService
    {
        AwayProfile GetNewAwayProfile(MatchData match);
        HomeProfile GetNewHomeProfile(MatchData match);
        AwayProfile GetNormalizedAwayOdds(AwayProfile probabilities);
        HomeProfile GetNormalizedHomeOdds(HomeProfile probabilities);
    }
}
