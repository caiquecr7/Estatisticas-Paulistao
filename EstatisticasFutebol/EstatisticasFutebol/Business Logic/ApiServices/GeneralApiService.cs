using EstatisticasFutebol.Business_Logic.ApiServices.Interface;
using System.Text.Json;

namespace EstatisticasFutebol.Business_Logic.ApiServices
{
    public class GeneralApiService : IGeneralApiService
    {
        public async Task<T> DeserializeAsync<T>(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
