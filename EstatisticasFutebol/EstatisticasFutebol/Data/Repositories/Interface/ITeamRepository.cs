using EstatisticasFutebol.Data.Entities;

namespace EstatisticasFutebol.Data.Repositories.Interface
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAllAsync();
        Task<Team> GetByIdAsync(int id);
        Task<Team> GetByNameAsync(string name);
        Task UpdateAsync(Team team);
    }
}
