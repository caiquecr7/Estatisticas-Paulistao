using Microsoft.EntityFrameworkCore;

namespace EstatisticasFutebol.Data.Entities
{
    public class RoundMatches
    { 
        public int Id { get; set; }
        public string Away_Team { get; set; }
        public int? Away_Score { get; set; }
        public string Home_Team { get; set; }
        public int? Home_Score { get; set; }
        public int Round_Number { get; set; }
        public bool Finished { get; set; }

        public RoundMatches() { }
    }
    
}
