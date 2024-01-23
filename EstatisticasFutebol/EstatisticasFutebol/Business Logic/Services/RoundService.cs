using EstatisticasFutebol.Business_Logic.ApiServices;
using EstatisticasFutebol.Business_Logic.ApiServices.Interface;
using EstatisticasFutebol.Business_Logic.Services.Interface;
using EstatisticasFutebol.Data.Enum;
using EstatisticasFutebol.Data.Entities;
using EstatisticasFutebol.Data.Repositories.Interface;
using System.Text.RegularExpressions;
using Microsoft.Identity.Client;
using EstatisticasFutebol.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using static MudBlazor.Colors;

namespace EstatisticasFutebol.Business_Logic.Services
{
    public class RoundService : IRoundService
    {
        private readonly IMatchService _matchService;
        private readonly ITeamService _teamService;
        private readonly IRoundRepository _roundRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly UfabcEcContext _dbContext;

        public RoundService(IMatchService matchService, ITeamService teamService, IRoundRepository roundRepository, ITeamRepository teamRepository)
        {
            _matchService = matchService;
            _teamService = teamService;
            _roundRepository = roundRepository;
            _teamRepository = teamRepository;
        }
        public async void SimulateRound()
        {
            var allTeams = await _teamRepository.GetAllAsync();
            var matches = await _roundRepository.GetAllAsync();

            var iterations = 1000000;
            for (var i = 0; i < iterations; i++)
            {
                var simulationMatches = await _matchService.ReadMatches(matches, allTeams);

                for (int round = 1; round <= 12; round++)
                {
                    var roundMatches = simulationMatches.FindAll(x => x.RoundNumber == round);

                    foreach (var match in roundMatches)
                    {
                        SimulateMatch(match);
                    }
                }
                var simulationTeams = simulationMatches
                    .Select(match => match.HomeTeam)
                    .Distinct()
                    .ToList();

                allTeams = _teamService.GetClassifiedTeams(simulationTeams, allTeams);
            }

            await _teamService.GetConversionRate(allTeams, iterations);
        }

        public void SimulateMatch(SimulationMatch match)
        {
            match.GetOneMatchOdds();
            match.GetOneMatchResult();
            match.HomeTeam.HomeProfile = _teamService.GetNewHomeProfile(match);
            match.AwayTeam.AwayProfile = _teamService.GetNewAwayProfile(match);
        }
    }
}
