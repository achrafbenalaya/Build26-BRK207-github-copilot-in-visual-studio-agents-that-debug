using worldcup2026.Models;

namespace worldcup2026.Services;

public class FastStandingsService
{
    private readonly WorldCupDataService _data;

    public FastStandingsService(WorldCupDataService data) => _data = data;

    public List<Standing> GetStandings()
    {
        var matches = _data.GetMatches();
        var points = new Dictionary<string, int>();

        foreach (var match in matches)
        {
            points.TryAdd(match.HomeTeam, 0);
            points.TryAdd(match.AwayTeam, 0);

            if (match.HomeGoals > match.AwayGoals)       points[match.HomeTeam] += 3;
            else if (match.HomeGoals == match.AwayGoals) { points[match.HomeTeam] += 1; points[match.AwayTeam] += 1; }
            else                                          points[match.AwayTeam] += 3;
        }

        return [.. points
            .Select(kv => new Standing { TeamName = kv.Key, Points = kv.Value })
            .OrderByDescending(s => s.Points)];
    }
}
