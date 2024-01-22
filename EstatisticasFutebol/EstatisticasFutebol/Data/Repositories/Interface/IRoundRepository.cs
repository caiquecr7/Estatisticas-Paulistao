using EstatisticasFutebol.Data.Entities;

namespace EstatisticasFutebol.Data.Repositories.Interface
{
    public interface IRoundRepository
    {
        Task<List<RoundMatches>> GetAllAsync();
        Task<RoundMatches> GetByTeams(string HomeTeam, string AwayTeam);
        Task<List<RoundMatches>> GetByRoundAsync(int roundNumber);
    }
}
