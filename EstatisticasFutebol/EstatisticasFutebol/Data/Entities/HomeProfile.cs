using System;
using System.Collections.Generic;

namespace EstatisticasFutebol.Data.Entities;

public partial class HomeProfile
{
    public int Id { get; set; }

    public string Team { get; set; } = null!;

    public double VictoryOdd { get; set; }

    public double DrawOdd { get; set; }

    public double DefeatOdd { get; set; }

    public virtual Team TeamNavigation { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public HomeProfile(double victoryOdd, double drawOdd, double defeatOdd)
    {
        VictoryOdd = victoryOdd;
        DrawOdd = drawOdd;
        DefeatOdd = defeatOdd;
    }
    public HomeProfile() { }
}
