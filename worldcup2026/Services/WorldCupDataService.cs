using System.Text.Json;
using System.Text.Json.Serialization;
using worldcup2026.Helpers;
using worldcup2026.Models;

namespace worldcup2026.Services;

public class WorldCupDataService
{
    private readonly List<Team> _teams;
    private readonly List<Match> _matches;

    public WorldCupDataService(IWebHostEnvironment env)
    {
        var jsonPath = Path.Combine(env.ContentRootPath, "worldcup-2026-schedule.json");
        var json = File.ReadAllText(jsonPath);
        var schedule = JsonSerializer.Deserialize<ScheduleJson>(json)!;

        var groupLookup = new Dictionary<string, string>();
        foreach (var m in schedule.Matches)
        {
            groupLookup.TryAdd(m.TeamA, m.GroupName);
            groupLookup.TryAdd(m.TeamB, m.GroupName);
        }

        _teams = schedule.Teams.Select(t =>
        {
            var ratings = GetRatings(t.Code);
            return new Team
            {
                Flag = FlagHelper.GetFlag(t.Code),
                Name = t.Name,
                Group = groupLookup.GetValueOrDefault(t.Code, "?"),
                AttackRating = ratings.attack,
                DefenseRating = ratings.defense
            };
        }).ToList();

        var nameLookup = schedule.Teams.ToDictionary(t => t.Code, t => t.Name);

        _matches = schedule.Matches.Select(m => new Match
        {
            HomeTeam = nameLookup.GetValueOrDefault(m.TeamA, m.TeamA),
            AwayTeam = nameLookup.GetValueOrDefault(m.TeamB, m.TeamB),
            HomeGoals = 0,
            AwayGoals = 0
        }).ToList();
    }

    public List<Team> GetTeams() => _teams;
    public List<Match> GetMatches() => _matches;

    private static (int attack, int defense) GetRatings(string code) => code switch
    {
        "ARG" => (10, 8), "FRA" => (9, 9), "BRA" => (9, 8), "ESP" => (9, 8),
        "ENG" => (8, 8), "GER" => (8, 8), "POR" => (9, 7), "NED" => (8, 8),
        "BEL" => (8, 7), "CRO" => (7, 8), "URY" => (7, 8), "COL" => (8, 7),
        "USA" => (7, 7), "MEX" => (7, 7), "JPN" => (8, 7), "KOR" => (7, 7),
        "MAR" => (7, 8), "SEN" => (7, 7), "SUI" => (7, 8), "TUR" => (7, 7),
        "AUS" => (6, 7), "AUT" => (7, 7), "ECU" => (7, 6), "CAN" => (6, 6),
        "EGY" => (7, 7), "SWE" => (7, 7), "NOR" => (7, 6), "ALG" => (6, 7),
        "CIV" => (7, 6), "IRN" => (6, 7), "GHA" => (6, 6), "TUN" => (6, 7),
        "KSA" => (6, 6), "IRQ" => (6, 6), "QAT" => (6, 6), "PAR" => (6, 6),
        "BIH" => (6, 6), "NZL" => (5, 6), "PAN" => (5, 6), "JOR" => (5, 6),
        "COD" => (6, 5), "UZB" => (6, 6), "SCO" => (6, 7), "HTI" => (5, 5),
        "CUW" => (4, 5), "CPV" => (5, 5), "CZE" => (7, 7), "RSA" => (6, 6),
        _ => (5, 5)
    };

    private class ScheduleJson
    {
        [JsonPropertyName("teams")]
        public List<TeamJson> Teams { get; set; } = [];

        [JsonPropertyName("matches")]
        public List<MatchJson> Matches { get; set; } = [];
    }

    private class TeamJson
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = "";

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
    }

    private class MatchJson
    {
        [JsonPropertyName("group_name")]
        public string GroupName { get; set; } = "";

        [JsonPropertyName("team_a")]
        public string TeamA { get; set; } = "";

        [JsonPropertyName("team_b")]
        public string TeamB { get; set; } = "";
    }
}
