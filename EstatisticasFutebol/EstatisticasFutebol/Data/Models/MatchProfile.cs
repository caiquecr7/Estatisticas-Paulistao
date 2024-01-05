namespace EstatisticasFutebol.Data.Models
{
    public class MatchProfile
    {
        public int MatchProfileId { get; set; }
        public double HomeOdd { get; set; }
        public double AwayOdd { get; set; }
        public double DrawOdd { get; set; }

        public MatchProfile(double homeOdd, double awayOdd, double drawOdd)
        {
            HomeOdd = homeOdd;
            AwayOdd = awayOdd;
            DrawOdd = drawOdd;
        }
    }
}
