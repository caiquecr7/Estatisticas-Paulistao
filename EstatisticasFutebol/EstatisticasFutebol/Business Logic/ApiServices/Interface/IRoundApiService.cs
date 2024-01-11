using EstatisticasFutebol.Data.Models.ApiModels;
using Microsoft.AspNetCore.SignalR;

namespace EstatisticasFutebol.Business_Logic.ApiServices.Interface
{
    public interface IRoundApiService
    {
        Task<ApiRound> GetOneRound(int  roundNumber);
    }
}
