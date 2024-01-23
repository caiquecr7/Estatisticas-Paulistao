using EstatisticasFutebol.Data.Entities.Simulation;
using EstatisticasFutebol.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstatisticasFutebol.Data.Entities
{
    public class SimulationMatch
    {
        public SimulationTeam HomeTeam { get; set; }
        public SimulationTeam AwayTeam { get; set; }
        public MatchProfile? Odds { get; set; }
        public int RoundNumber { get; set; }
        public Result FinalResult { get; set; }


        public SimulationMatch(SimulationTeam homeTeam, SimulationTeam awayTeam, int roundNumber)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            RoundNumber = roundNumber;
        }

        public void GetOneMatchOdds()
        {
            var victoryProbability = (HomeTeam.HomeProfile.VictoryOdd + AwayTeam.AwayProfile.DefeatOdd) / 2;
            var drawProbability = (HomeTeam.HomeProfile.DrawOdd + AwayTeam.AwayProfile.DrawOdd) / 2;
            var defeatProbability = (HomeTeam.HomeProfile.DefeatOdd + AwayTeam.AwayProfile.VictoryOdd) / 2;
            MatchProfile profile = new MatchProfile(victoryProbability, drawProbability, defeatProbability);

            Odds = profile;
        }

        public void GetOneMatchResult()
        {
            Random random = new Random();
            var randonNumber = random.NextDouble();
            Result result = new Result();


            if (randonNumber <= Odds.HomeOdd)
            {
                result = Result.HomeWinner;
                HomeTeam.SimulatedPoints += 3;
            }

            else if (randonNumber > Odds.HomeOdd & randonNumber <= Odds.HomeOdd + Odds.DrawOdd)
            {
                result = Result.Draw;
                HomeTeam.SimulatedPoints += 1;
                AwayTeam.SimulatedPoints += 1;
            }

            else
            {
                result = Result.AwayWinner;
                AwayTeam.SimulatedPoints += 3;
            }
            FinalResult = result;
        }
        public SimulationMatch() { }
    }
}
