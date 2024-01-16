using EstatisticasFutebol.Data.Entities.ApiModels;
using Microsoft.AspNetCore.SignalR;

namespace EstatisticasFutebol.Business_Logic.ApiServices.Interface
{
    public interface IRoundApiService
    {
        Task<ApiRound> GetOneRound(int  roundNumber);
    }
}
