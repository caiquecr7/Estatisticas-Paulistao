using AutoMapper;
using EstatisticasFutebol.Data.Entities;
using EstatisticasFutebol.Data.Repositories.Interface;
using EstatisticasFutebol.User_Interface.Mapping.DTO;
using Microsoft.AspNetCore.Components;
using System.Xml.Linq;

namespace EstatisticasFutebol.Views.Components.Pages
{
    public partial class Probabilidades
    {

        public IEnumerable<TeamDTO> Teams = new List<TeamDTO>();

        [Inject]
        public ITeamRepository _teamRepository { get; set; }

        [Inject]
        public IMapper _mapper { get; set; }

        public List<string> Groups = new List<string> { "A", "B", "C", "D" };

    protected override async Task OnInitializedAsync()
        {
            var teamsUnmapped = await _teamRepository.GetAllAsync();
            Teams = _mapper.Map<List<TeamDTO>>(teamsUnmapped).OrderBy(x=> x.ConversionRate);
        }

        private IEnumerable<TeamDTO> GetTeamsForGroup(string groupLetter)
        {
            return Teams.Where(x => x.GroupLetter == groupLetter)
                        .OrderByDescending(x => x.ConversionRate);
        }
    }
}