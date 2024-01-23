namespace EstatisticasFutebol.Data.Entities.Simulation
{
    public class SimulationHomeProfile
    {
        public int Id { get; set; }
        public string Team { get; set; } = null!;
        public double VictoryOdd { get; set; }
        public double DrawOdd { get; set; }
        public double DefeatOdd { get; set; }

        public SimulationHomeProfile(int id, double victoryOdd, double drawOdd, double defeatOdd)
        {
            Id = id;
            VictoryOdd = victoryOdd;
            DrawOdd = drawOdd;
            DefeatOdd = defeatOdd;
        }

        public SimulationHomeProfile() { }
    }
}
