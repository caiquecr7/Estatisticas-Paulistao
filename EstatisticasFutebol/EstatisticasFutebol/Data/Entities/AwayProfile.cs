using System;
using System.Collections.Generic;

namespace EstatisticasFutebol.Data.Entities;

public partial class AwayProfile
{
    public int Id { get; set; }

    public string Team { get; set; } = null!;

    public double VictoryOdd { get; set; }

    public double DrawOdd { get; set; }

    public double DefeatOdd { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public AwayProfile(double victoryOdd, double drawOdd, double defeatOdd) 
    {
        VictoryOdd = victoryOdd;
        DrawOdd = drawOdd;
        DefeatOdd = defeatOdd;
    }

    public AwayProfile() { }
}
