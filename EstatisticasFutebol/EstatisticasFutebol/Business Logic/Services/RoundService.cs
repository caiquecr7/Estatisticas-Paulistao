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

            var iterations = 10;
            for (var i = 0; i < iterations; i++)
            {
                var simulationTeams = new List<Team>();

                for (int round = 1; round <= 12; round++)
                {
                    var roundMatches = matches.FindAll(x => x.Round_Number == round);
                    var enableTracking = (round == 1);

                    var simulationMatches = await _matchService.ReadMatches(roundMatches, enableTracking);

                    foreach (var match in simulationMatches)
                    {
                        SimulateMatch(match);
                    }

                    var getSimulatedTeams = (round == 12);

                    if (getSimulatedTeams)
                    {
                        simulationTeams = GetSimulatedTeamsData(simulationMatches);
                    }
                }

                allTeams = _teamService.GetClassifiedTeams(simulationTeams);

                foreach(var team in allTeams)
                {
                    team.ResetPoints();
                }

                simulationTeams = null;
            }

            await _teamService.GetConversionRate(allTeams, iterations);
        }

        public void SimulateMatch(MatchData match)
        {
            match.GetOneMatchOdds();
            match.GetOneMatchResult();
            match.HomeTeam.HomeProfile = _teamService.GetNewHomeProfile(match);
            match.AwayTeam.AwayProfile = _teamService.GetNewAwayProfile(match);
        }

        public List<Team> GetSimulatedTeamsData(List<MatchData> simulationMatches)
        {
            List<Team> simulationTeams = new List<Team>();
            foreach (var match in simulationMatches)
            {
                simulationTeams.Add(match.HomeTeam);
                simulationTeams.Add(match.AwayTeam);
            }

            return simulationTeams;
        }
    }
}
