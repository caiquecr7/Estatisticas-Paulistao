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
        [Inject]
        private ITeamRepository _teamRepository { get; set; }

        public async void TesteAPI()
        {
            Console.WriteLine("Teste");
            _roundService.SimulateRound();
            List<Team> teams = await _teamRepository.GetAllAsync();
            foreach (Team team in teams)
            {
                Console.WriteLine(team.Name);
            }
        }
    }
}
