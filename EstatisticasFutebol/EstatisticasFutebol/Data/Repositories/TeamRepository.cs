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
                .ToListAsync();
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            return await _dbContext.Teams
                .FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<Team> GetByNameAsync(string name)
        {
            return await _dbContext.Teams
                .FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task UpdateAsync(Team team)
        {
            _dbContext.Update(team);
            await _dbContext.SaveChangesAsync();
        }

    }
}
