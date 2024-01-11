using System.Text.Json.Serialization;

namespace EstatisticasFutebol.Data.Models.ApiModels
{
    public class ApiTeam
    {
        [JsonPropertyName("nome_popular")]
        public string Name { get; set; }

    }
}
