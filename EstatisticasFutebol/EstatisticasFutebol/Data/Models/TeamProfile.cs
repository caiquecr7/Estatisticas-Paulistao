namespace EstatisticasFutebol.Data.Models
{
    public class TeamProfile
    {
        public int TeamProfileId { get; set; }
        public double VictoryOdd { get; set; }
        public double DefeatOdd { get; set; }
        public double DrawOdd { get; set; }

        public TeamProfile(double victoryOdd, double defeatOdd, double drawOdd)
        {
            VictoryOdd = victoryOdd;
            DefeatOdd = defeatOdd;
            DrawOdd = drawOdd;
        }
        public TeamProfile() { }
    }
}
