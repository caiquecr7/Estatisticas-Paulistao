﻿namespace EstatisticasFutebol.Data.Models
{
    public class Team
    {
        private static int lastId = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Goals_Scored { get; set; }
        public TeamProfile HomeProfile { get; set; }
        public TeamProfile AwayProfile { get; set; }
        public int _nationalRank;
        public int NationalRank
        {
            get => _nationalRank;
            set => _nationalRank = value;
        }

        public double DifficultyLevel => 0.5 - (0.03125 * (_nationalRank - 1));

        public Team(string name, TeamProfile homeProfile, TeamProfile awayProfile, int nationalRank)
        {
            Id = ++lastId;
            Name = name;
            HomeProfile = homeProfile;
            AwayProfile = awayProfile;
            NationalRank = nationalRank;
        }
    }
}
