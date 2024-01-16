using EstatisticasFutebol.Data.Entities;
using EstatisticasFutebol.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EstatisticasFutebol.Data.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly UfabcEcContext _dbContext;
        public HomeRepository(UfabcEcContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<HomeProfile> GetByTeamAsync(string name)
        {
            return await _dbContext.HomeProfiles
                .FirstOrDefaultAsync(profile => profile.Team == name);
        }
    }
}
