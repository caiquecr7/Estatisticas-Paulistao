using EstatisticasFutebol.Business_Logic.Services.Interface;
using EstatisticasFutebol.Data.Entities;
using EstatisticasFutebol.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EstatisticasFutebol.Business_Logic.Services
{
    public class MatchService : IMatchService
    {
        private readonly ITeamRepository _teamRepository;
        public MatchService(ITeamRepository teamRepository, UfabcEcContext dbContext)
        {
            _teamRepository = teamRepository;
        }
        public async Task<List<MatchData>> ReadMatches(List<RoundMatches> matches, bool enableTracking)
        {
            List<MatchData> result = new List<MatchData>();

            foreach (RoundMatches match in matches)
            {
                if (!match.Finished)
                {
                    MatchData matchRead = new MatchData();
                   
                    if (enableTracking)
                    {
                        matchRead.AwayTeam = await _teamRepository.GetByNameWithoutTrackingAsync(match.Away_Team.Trim());
                        matchRead.HomeTeam = await _teamRepository.GetByNameWithoutTrackingAsync(match.Home_Team.Trim());
                    }
                    else
                    {
                        matchRead.AwayTeam = await _teamRepository.GetByNameAsync(match.Away_Team.Trim());
                        matchRead.HomeTeam = await _teamRepository.GetByNameAsync(match.Home_Team.Trim());
                    }
                    result.Add(matchRead);
                }
            }
            return result;
        }
    }
}
