using EstatisticasFutebol.Data.Entities;
using EstatisticasFutebol.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace EstatisticasFutebol.Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly UfabcEcContext _dbContext;

        public TeamRepository(UfabcEcContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Team>> GetAllAsync()
        {
            return await _dbContext.Teams
                .Include(x => x.HomeProfile)
                .Include(x => x.AwayProfile)
                .ToListAsync();
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            var team = await _dbContext.Teams
                .Include(x => x.HomeProfile)
                .Include(x => x.AwayProfile)
                .AsNoTracking()
                .FirstOrDefaultAsync(x=> x.Id == id);

            return team;
        }

        public async Task<Team> GetByNameAsync(string name, UfabcEcContext? context = null)
        {
            var team = await _dbContext.Teams
                    .Include(x => x.HomeProfile)
                    .Include(x => x.AwayProfile)
                    .FirstOrDefaultAsync(x => x.Name == name);
            //_dbContext.Entry(team).State = EntityState.Detached;
            return team;
        }

        public async Task<Team> GetByNameWithoutTrackingAsync(string name, UfabcEcContext? context = null)
        {
            var team = await _dbContext.Teams
                    .Include(x => x.HomeProfile)
                    .Include(x => x.AwayProfile)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Name == name);

            //_dbContext.Entry(team).State = EntityState.Detached;
            return team;
        }

        public async Task UpdateAsync(Team team)
        {
            _dbContext.Update(team);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateConversionRateAsync(Team team)
        {
            _dbContext.Entry(team).State = EntityState.Detached;

            var existingTeam = await _dbContext.Teams.FindAsync(team.Name);

            if (existingTeam != null)
            {
                existingTeam.ConversionRate = team.ConversionRate;

                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
