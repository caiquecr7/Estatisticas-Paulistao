using System.Text.Json.Serialization;

namespace EstatisticasFutebol.Data.Entities.ApiModels
{
    public class ApiMatch
    {
        [JsonPropertyName("partida_id")]
        public int Id { get; set; }
        [JsonPropertyName("placar")]
        public string Score { get; set; }
        [JsonPropertyName("time_mandante")]
        public ApiTeam HomeTeam { get; set; }
        [JsonPropertyName("time_visitante")]
        public ApiTeam AwayTeam { get; set; }
        [JsonPropertyName("placar_mandante")]
        public int HomeScore { get; set; }
        [JsonPropertyName("placar_visitante")]
        public int AwayScore { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }

    }
}
