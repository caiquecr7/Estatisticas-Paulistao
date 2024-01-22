using EstatisticasFutebol.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstatisticasFutebol.Data.Entities;

public partial class Team
{   
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int GoalsScored { get; set; }

    public int NationalRank { get; set; }

    public int Points { get; set; }

    public int? HomeProfileId { get; set; }

    public int? AwayProfileId { get; set; }

    public string GroupLetter { get; set; } = null!;

    public int? Matches { get; set; }

    public int? Victories { get; set; }

    public int? Draws { get; set; }

    public int? Defeats { get; set; }

    public int? GoalsFor { get; set; }

    public int? GoalsAgainst { get; set; }

    public int? GoalsDifference { get; set; }

    public double? ConversionRate { get; set; }
    [NotMapped]
    public int times_classified { get; set; }

    [NotMapped]
    public int _simulatedPoints;
    [NotMapped]
    public int SimulatedPoints
    {
        get => _simulatedPoints;
        set => _simulatedPoints = value;
    }
    [NotMapped]
    public int TotalPoints => _simulatedPoints + Points;
    public double DifficultyLevel => 0.5 - (0.03125 * (NationalRank - 1));

    public virtual AwayProfile? AwayProfile { get; set; }

    public virtual HomeProfile? HomeProfile { get; set; }

    public Team(string name, HomeProfile homeProfile, AwayProfile awayProfile, int nationalRank)
    {
        Name = name;
        HomeProfile = homeProfile;
        AwayProfile = awayProfile;
        NationalRank = nationalRank;
    }

    public Team()
    {
    }

    public void ResetPoints()
    {
        _simulatedPoints = 0;
    }
}
