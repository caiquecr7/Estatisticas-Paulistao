using EstatisticasFutebol.Business_Logic.Services;
using EstatisticasFutebol.Business_Logic.Services.Interface;
using EstatisticasFutebol.Data.Entities;
using EstatisticasFutebol.Data.Repositories.Interface;
using Microsoft.AspNetCore.Components;

namespace EstatisticasFutebol.Views.Components.Pages
{
    public partial class Teste
    {
        [Inject]
        private IRoundService _roundService {  get; set; }

        public async void TesteAPI()
        {
            Console.WriteLine("Teste");
            _roundService.SimulateRound();
        }
    }
}
