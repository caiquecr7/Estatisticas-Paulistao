using EstatisticasFutebol.Data.Models;
using EstatisticasFutebol.Business_Logic.Services.Interface;
using EstatisticasFutebol.Data.Enum;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;

namespace EstatisticasFutebol.Business_Logic.Services
{
    public class TeamService : ITeamService
    {

        public TeamProfile GetNewAwayProfile(MatchData match)
        {
            int pastWeight = 5;
            int winWeight = 0;
            int loseWeight = 0;
            int drawWeight = 0;

            var oldAwayProfile = match.AwayTeam.AwayProfile;
            TeamProfile newAwayProfile = new TeamProfile();

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

            newAwayProfile.VictoryOdd = (pastWeight * oldAwayProfile.VictoryOdd) + ((match.Odds.AwayOdd + match.HomeTeam.DifficultyLevel)* winWeight); 
            newAwayProfile.DrawOdd = (pastWeight * oldAwayProfile.DrawOdd) + ((match.Odds.DrawOdd + match.HomeTeam.DifficultyLevel) * drawWeight);
            newAwayProfile.DefeatOdd = (pastWeight * oldAwayProfile.DefeatOdd) + (match.Odds.HomeOdd +(0.5 * (match.HomeTeam.NationalRank/16)) * loseWeight);

            return GetNormalizedProbabilites(newAwayProfile);
        }

        public TeamProfile GetNewHomeProfile(MatchData match)
        {
            int pastWeight = 5;
            int winWeight = 0;
            int loseWeight = 0;
            int drawWeight = 0;

            var oldHomeProfile = match.HomeTeam.HomeProfile;
            TeamProfile newHomeProfile = new TeamProfile();

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
            newHomeProfile.DefeatOdd = (pastWeight * oldHomeProfile.DefeatOdd) + (match.Odds.AwayOdd + (0.5 * (match.AwayTeam.NationalRank / 16)) * loseWeight);

            return GetNormalizedProbabilites(newHomeProfile);
        }


        public TeamProfile GetNormalizedProbabilites(TeamProfile probabilities)
        {
            double total = probabilities.VictoryOdd + probabilities.DrawOdd + probabilities.DefeatOdd;
            TeamProfile normalizedProbabilites = new TeamProfile(probabilities.VictoryOdd/total, probabilities.DrawOdd/total, probabilities.DefeatOdd/total);
            return normalizedProbabilites;
        }
    }
}
