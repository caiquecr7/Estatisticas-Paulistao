using EstatisticasFutebol.Data.Entities;

namespace EstatisticasFutebol.Data.Repositories.Interface
{
    public interface IAwayRepository
    {
        Task<AwayProfile> GetByTeamAsync(string name);
    }
}
