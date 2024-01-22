using EstatisticasFutebol.Business_Logic.ApiServices.Interface;
using EstatisticasFutebol.Data.Entities;
using EstatisticasFutebol.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EstatisticasFutebol.Data.Repositories
{
    public class RoundRepository : IRoundRepository
    {
        private readonly UfabcEcContext _dbContext;
        public RoundRepository (UfabcEcContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<RoundMatches>> GetAllAsync()
        {
            return await _dbContext.RoundMatches
                .ToListAsync();
        }

        public async Task<List<RoundMatches>> GetByRoundAsync(int roundNumber)
        {
            using (var dbContext = new UfabcEcContext())
            {
                return await dbContext.RoundMatches
                    .Where(x => x.Round_Number == roundNumber)
                    .ToListAsync();
            };
        }

        public async Task<RoundMatches> GetByTeams(string HomeTeam, string AwayTeam)
        {
            return await _dbContext.RoundMatches
                .FirstOrDefaultAsync(x => x.Home_Team == HomeTeam && x.Away_Team ==  AwayTeam);
        }
    }
}
