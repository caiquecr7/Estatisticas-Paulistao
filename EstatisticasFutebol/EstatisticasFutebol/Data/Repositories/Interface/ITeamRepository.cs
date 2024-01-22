using EstatisticasFutebol.Data.Entities;

namespace EstatisticasFutebol.Data.Repositories.Interface
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAllAsync();
        Task<Team> GetByIdAsync(int id);
        Task<Team> GetByNameAsync(string name, UfabcEcContext? context = null);
        Task<Team> GetByNameWithoutTrackingAsync(string name, UfabcEcContext? context = null);
        Task UpdateAsync(Team team);
        Task UpdateConversionRateAsync(Team team);
    }
}
