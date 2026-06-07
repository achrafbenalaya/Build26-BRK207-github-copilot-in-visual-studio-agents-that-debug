using worldcup2026.Models;

namespace worldcup2026.Services;

public class SlowStandingsService
{
    private readonly WorldCupDataService _data;

    public SlowStandingsService(WorldCupDataService data) => _data = data;

    public List<Standing> GetStandings()
    {
        var matches = _data.GetMatches();
        var standings = new List<Standing>();

        // Intentionally slow: recalculates 10 000 times to simulate expensive work
        for (int i = 0; i < 10_000; i++)
        {
            standings.Clear();
            foreach (var match in matches)
            {
                var home = standings.FirstOrDefault(s => s.TeamName == match.HomeTeam);
                if (home == null) { home = new Standing { TeamName = match.HomeTeam }; standings.Add(home); }

                var away = standings.FirstOrDefault(s => s.TeamName == match.AwayTeam);
                if (away == null) { away = new Standing { TeamName = match.AwayTeam }; standings.Add(away); }

                if (match.HomeGoals > match.AwayGoals)      { home.Points += 3; }
                else if (match.HomeGoals == match.AwayGoals) { home.Points += 1; away.Points += 1; }
                else                                          { away.Points += 3; }
            }
        }

        return [.. standings.OrderByDescending(s => s.Points)];
    }
}
