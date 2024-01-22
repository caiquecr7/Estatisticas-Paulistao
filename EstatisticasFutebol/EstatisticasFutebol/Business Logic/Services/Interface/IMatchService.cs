using EstatisticasFutebol.Data.Entities;

namespace EstatisticasFutebol.Business_Logic.Services.Interface
{
    public interface IMatchService
    {
        Task<List<MatchData>> ReadMatches(List<RoundMatches> matches, bool enableTracking);
    }
}
