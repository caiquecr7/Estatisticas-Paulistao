using EstatisticasFutebol.Business_Logic.ApiServices.Interface;
using EstatisticasFutebol.Data.Models.ApiModels;

namespace EstatisticasFutebol.Business_Logic.ApiServices
{
    public class RoundApiService : IRoundApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IGeneralApiService _generalApiService;

        public RoundApiService(HttpClient httpClient, IGeneralApiService generalApiService)
        {
            _httpClient = httpClient;
            _generalApiService = generalApiService;
        }
        public async Task<ApiRound> GetOneRound(int roundNumber)
        {
            try
            {

                var response = _httpClient.GetAsync($"rodadas/{roundNumber}").Result;

                if (response.IsSuccessStatusCode)
                {
                    return await _generalApiService.DeserializeAsync<ApiRound>(response);
                }
                else
                {
                    Console.WriteLine(response.StatusCode.ToString());
                    ApiRound apiRound = new ApiRound();
                    return apiRound;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                throw;
            }
        }
    }
}
