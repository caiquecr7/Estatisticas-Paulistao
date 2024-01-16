using EstatisticasFutebol.Data.Entities;

namespace EstatisticasFutebol.Data.Repositories.Interface
{
    public interface IHomeRepository
    {
        Task<HomeProfile> GetByTeamAsync(string name);
    }
}
