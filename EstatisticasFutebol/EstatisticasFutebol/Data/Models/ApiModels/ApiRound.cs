using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Text.Json.Serialization;

namespace EstatisticasFutebol.Data.Models.ApiModels
{
    public class ApiRound
    {
        [JsonPropertyName("rodada")]
        public int Number { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("partidas")]
        public List<ApiMatch> Matches { get; set; }


    }
}
