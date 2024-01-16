using EstatisticasFutebol.Data.Entities;
using EstatisticasFutebol.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EstatisticasFutebol.Data.Repositories
{
    public class AwayRepository : IAwayRepository
    {
        private readonly UfabcEcContext _dbContext;
        public AwayRepository(UfabcEcContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<AwayProfile> GetByTeamAsync(string name)
        {
            return await _dbContext.AwayProfiles
                .FirstOrDefaultAsync(profile => profile.Team == name);
        }
    }
}
