using EstatisticasFutebol.Business_Logic.Services;
using EstatisticasFutebol.Business_Logic.Services.Interface;
using Microsoft.AspNetCore.Components;

namespace EstatisticasFutebol.Views.Components.Pages
{
    public partial class Teste
    {
        [Inject]
        private IRoundService _roundService {  get; set; }

        public void TesteAPI()
        {
            Console.WriteLine("Teste");
            _roundService.SimulateRound();
        }
    }
}
