using EstatisticasFutebol.Business_Logic.Services.Interface;
using EstatisticasFutebol.Data.Entities;
using EstatisticasFutebol.Data.Entities.Simulation;
using EstatisticasFutebol.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EstatisticasFutebol.Business_Logic.Services
{
    public class MatchService : IMatchService
    {
        private readonly ITeamRepository _teamRepository;
        public MatchService(ITeamRepository teamRepository, UfabcEcContext dbContext)
        {
            _teamRepository = teamRepository;
        }
        public async Task<List<SimulationMatch>> ReadMatches(List<RoundMatches> matches, List<Team> allTeams)
        {
            List<SimulationMatch> result = new List<SimulationMatch>();
            List<SimulationTeam> simulationTeams = GetSimulationTeams(allTeams);

            foreach (RoundMatches match in matches)
            {
               if (!match.Finished)
               {
                    var simulationMatch = new SimulationMatch
                    {
                        HomeTeam = simulationTeams.FirstOrDefault(x => x.Name == match.Home_Team.Trim()),
                        AwayTeam = simulationTeams.FirstOrDefault(x => x.Name == match.Away_Team.Trim()),
                        RoundNumber = match.Round_Number
                    };
                    result.Add(simulationMatch);
               }
            }
            return result;
        }

        public List<SimulationTeam> GetSimulationTeams(List<Team> teams) 
        { 
            List<SimulationTeam> simulationTeams= new List<SimulationTeam>();

            foreach (Team team in teams)
            {
                var simulationTeam = new SimulationTeam
                {
                    Id = team.Id,
                    Name = team.Name,
                    NationalRank = team.NationalRank,
                    Points = team.Points,
                    HomeProfile = GetSimulationHomeProfile(team.HomeProfile),
                    AwayProfile = GetSimulationAwayProfile(team.AwayProfile),
                    GroupLetter = team.GroupLetter,
                };

                simulationTeams.Add(simulationTeam);
            }

            return simulationTeams;
        }

        public SimulationHomeProfile GetSimulationHomeProfile(HomeProfile homeProfile)
        {
            var simulationHomeProfile = new SimulationHomeProfile
            {
                Id = homeProfile.Id,
                VictoryOdd = homeProfile.VictoryOdd,
                DrawOdd = homeProfile.DrawOdd,
                DefeatOdd = homeProfile.DefeatOdd
            };

            return simulationHomeProfile;
        }

        public SimulationAwayProfile GetSimulationAwayProfile(AwayProfile awayProfile)
        {
            var simulationAwayProfile = new SimulationAwayProfile
            {
                Id = awayProfile.Id,
                VictoryOdd = awayProfile.VictoryOdd,
                DrawOdd = awayProfile.DrawOdd,
                DefeatOdd = awayProfile.DefeatOdd
            };

            return simulationAwayProfile;
        }
    }
}
