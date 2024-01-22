using EstatisticasFutebol.Business_Logic.Services.Interface;
using EstatisticasFutebol.Data.Enum;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using EstatisticasFutebol.Data.Entities;
using EstatisticasFutebol.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

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

        public AwayProfile GetNewAwayProfile(MatchData match)
        {
            int pastWeight = 10;
            int winWeight = 0;
            int loseWeight = 0;
            int drawWeight = 0;

            var oldAwayProfile = match.AwayTeam.AwayProfile;
            AwayProfile newAwayProfile = new AwayProfile();

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

        public HomeProfile GetNewHomeProfile(MatchData match)
        {
            int pastWeight = 10;
            int winWeight = 0;
            int loseWeight = 0;
            int drawWeight = 0;

            var oldHomeProfile = match.HomeTeam.HomeProfile;
            HomeProfile newHomeProfile = new HomeProfile();

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


        public AwayProfile GetNormalizedAwayOdds(AwayProfile probabilities)
        {
            double total = probabilities.VictoryOdd + probabilities.DrawOdd + probabilities.DefeatOdd;
            AwayProfile normalizedProbabilites = new AwayProfile(probabilities.VictoryOdd / total, probabilities.DrawOdd / total, probabilities.DefeatOdd / total);
            return normalizedProbabilites;
        }

        public HomeProfile GetNormalizedHomeOdds(HomeProfile probabilities)
        {
            double total = probabilities.VictoryOdd + probabilities.DrawOdd + probabilities.DefeatOdd;
            HomeProfile normalizedProbabilites = new HomeProfile(probabilities.VictoryOdd / total, probabilities.DrawOdd / total, probabilities.DefeatOdd / total);
            return normalizedProbabilites;
        }

        public List<Team> GetClassifiedTeams (List<Team> teams)
        {
            var teamsByGroup = teams.GroupBy(x => x.GroupLetter);

            foreach( var group in teamsByGroup)
            {
                var classifiedTeams = group.OrderByDescending(x => x.TotalPoints).ThenBy(x => x.NationalRank).Take(2);

                foreach( var team in classifiedTeams)
                {
                    team.times_classified++;
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
