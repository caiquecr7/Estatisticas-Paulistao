using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EstatisticasFutebol.Data.Entities.Simulation
{
    public class SimulationTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NationalRank { get; set; }
        public int Points { get; set; }
        public int SimulatedPoints { get; set; }
        public int TotalPoints => SimulatedPoints + Points;
        public double DifficultyLevel => 0.5 - 0.03125 * (NationalRank - 1);
        public string GroupLetter { get; set; }

        public SimulationAwayProfile? AwayProfile { get; set; }
        public SimulationHomeProfile? HomeProfile { get; set; }

        public SimulationTeam(int id, string name, int nationalRank, int points, SimulationAwayProfile? awayProfile, SimulationHomeProfile? homeProfile, string groupLetter)
        {
            Id = id;
            Name = name;
            NationalRank = nationalRank;
            Points = points;
            AwayProfile = awayProfile;
            HomeProfile = homeProfile;
            GroupLetter = groupLetter;
        }
        
        public SimulationTeam() { }
    }
}
