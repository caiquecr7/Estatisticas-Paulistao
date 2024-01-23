using EstatisticasFutebol.Business_Logic.Services.Interface;
using EstatisticasFutebol.Data.Enum;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using EstatisticasFutebol.Data.Entities;
using EstatisticasFutebol.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using EstatisticasFutebol.Data.Entities.Simulation;

namespace EstatisticasFutebol.Business_Logic.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly UfabcEcContext _dbContext;

        public TeamService(ITeamRepository teamRepository, UfabcEcContext dbContext)
        {
            _teamRepository = teamRepository;
            _dbContext = dbContext;
        }

        public SimulationAwayProfile GetNewAwayProfile(SimulationMatch match)
        {
            int pastWeight = 10;
            int winWeight = 0;
            int loseWeight = 0;
            int drawWeight = 0;

            var oldAwayProfile = match.AwayTeam.AwayProfile;
            SimulationAwayProfile newAwayProfile = new SimulationAwayProfile();

            if (match.FinalResult == Result.AwayWinner)
            {
                winWeight = 1;
            }
            else if (match.FinalResult == Result.Draw)
            {
                drawWeight = 1;
            }
            else if (match.FinalResult == Result.HomeWinner)
            {
                loseWeight = 1;
            }

            newAwayProfile.VictoryOdd = (pastWeight * oldAwayProfile.VictoryOdd) + ((match.Odds.AwayOdd + match.HomeTeam.DifficultyLevel) * winWeight);
            newAwayProfile.DrawOdd = (pastWeight * oldAwayProfile.DrawOdd) + ((match.Odds.DrawOdd + match.HomeTeam.DifficultyLevel) * drawWeight);
            newAwayProfile.DefeatOdd =(pastWeight * oldAwayProfile.DefeatOdd) + ((match.Odds.HomeOdd + (0.5 * (match.HomeTeam.NationalRank / 16))) * loseWeight);

            return GetNormalizedAwayOdds(newAwayProfile);
        }

        public SimulationHomeProfile GetNewHomeProfile(SimulationMatch match)
        {
            int pastWeight = 10;
            int winWeight = 0;
            int loseWeight = 0;
            int drawWeight = 0;

            var oldHomeProfile = match.HomeTeam.HomeProfile;
            SimulationHomeProfile newHomeProfile = new SimulationHomeProfile();

            if (match.FinalResult == Result.HomeWinner)
            {
                winWeight = 1;
            }
            else if (match.FinalResult == Result.Draw)
            {
                drawWeight = 1;
            }
            else if (match.FinalResult == Result.AwayWinner)
            {
                loseWeight = 1;
            }

            newHomeProfile.VictoryOdd = (pastWeight * oldHomeProfile.VictoryOdd) + ((match.Odds.HomeOdd + match.AwayTeam.DifficultyLevel) * winWeight);
            newHomeProfile.DrawOdd = (pastWeight * oldHomeProfile.DrawOdd) + ((match.Odds.DrawOdd + match.AwayTeam.DifficultyLevel) * drawWeight);
            newHomeProfile.DefeatOdd = (pastWeight * oldHomeProfile.DefeatOdd) + ((match.Odds.AwayOdd + (0.5 * (match.AwayTeam.NationalRank / 16))) * loseWeight);

            return GetNormalizedHomeOdds(newHomeProfile);
        }


        public SimulationAwayProfile GetNormalizedAwayOdds(SimulationAwayProfile probabilities)
        {
            double total = probabilities.VictoryOdd + probabilities.DrawOdd + probabilities.DefeatOdd;

            probabilities.VictoryOdd = probabilities.VictoryOdd / total;
            probabilities.DrawOdd = probabilities.DrawOdd / total;
            probabilities.DefeatOdd = probabilities.DefeatOdd / total;

            return probabilities;
        }

        public SimulationHomeProfile GetNormalizedHomeOdds(SimulationHomeProfile probabilities)
        {
            double total = probabilities.VictoryOdd + probabilities.DrawOdd + probabilities.DefeatOdd;

            probabilities.VictoryOdd = probabilities.VictoryOdd / total;
            probabilities.DrawOdd = probabilities.DrawOdd / total;
            probabilities.DefeatOdd = probabilities.DefeatOdd / total;

            return probabilities;
        }

        public List<Team> GetClassifiedTeams (List<SimulationTeam> simulationTeams, List<Team> teams)
        {
            var teamsByGroup = simulationTeams.GroupBy(x => x.GroupLetter);

            foreach( var group in teamsByGroup)
            {
                var classifiedTeams = group.OrderByDescending(x => x.TotalPoints).ThenBy(x => x.NationalRank).Take(2);

                foreach (var team in teams.Where(t => t.GroupLetter == group.Key))
                {
                    if (classifiedTeams.Any(simulatedTeam => simulatedTeam.Id == team.Id))
                    {
                        team.times_classified += 1;
                    }
                }
            }

            return teams;
        }

        public async Task GetConversionRate(List<Team> teams, int iterations)
        {
            foreach (var team in teams)
            {
                double conversionRate = (double)team.times_classified / iterations;
                team.ConversionRate = conversionRate;

                await _teamRepository.UpdateConversionRateAsync(team);
            }
            
        }

    }
}
