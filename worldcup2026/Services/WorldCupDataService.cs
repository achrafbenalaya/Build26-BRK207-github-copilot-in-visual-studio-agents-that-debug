using worldcup2026.Models;

namespace worldcup2026.Services;

public class WorldCupDataService
{
    public List<Team> GetTeams() =>
    [
        new Team { Flag = "🇲🇽", Name = "Mexico",         Group = "A", AttackRating = 7, DefenseRating = 7 },
        new Team { Flag = "🇨🇦", Name = "Canada",         Group = "A", AttackRating = 6, DefenseRating = 6 },
        new Team { Flag = "🇺🇸", Name = "United States",  Group = "B", AttackRating = 7, DefenseRating = 7 },
        new Team { Flag = "🏴󠁧󠁢󠁥󠁮󠁿", Name = "England",        Group = "B", AttackRating = 8, DefenseRating = 8 },
        new Team { Flag = "🇦🇷", Name = "Argentina",      Group = "C", AttackRating = 10, DefenseRating = 8 },
        new Team { Flag = "🇧🇷", Name = "Brazil",         Group = "C", AttackRating = 9,  DefenseRating = 8 },
        new Team { Flag = "🇫🇷", Name = "France",         Group = "D", AttackRating = 9,  DefenseRating = 9 },
        new Team { Flag = "🇩🇪", Name = "Germany",        Group = "D", AttackRating = 8,  DefenseRating = 8 },
        new Team { Flag = "🇪🇸", Name = "Spain",          Group = "E", AttackRating = 9,  DefenseRating = 8 },
        new Team { Flag = "🇵🇹", Name = "Portugal",       Group = "E", AttackRating = 9,  DefenseRating = 7 },
        new Team { Flag = "🇳🇱", Name = "Netherlands",    Group = "F", AttackRating = 8,  DefenseRating = 8 },
        new Team { Flag = "🇧🇪", Name = "Belgium",        Group = "F", AttackRating = 8,  DefenseRating = 7 },
    ];

    public List<Match> GetMatches() =>
    [
        new Match { HomeTeam = "Mexico",        AwayTeam = "Canada",        HomeGoals = 2, AwayGoals = 0 },
        new Match { HomeTeam = "United States", AwayTeam = "England",       HomeGoals = 1, AwayGoals = 2 },
        new Match { HomeTeam = "Argentina",     AwayTeam = "Brazil",        HomeGoals = 3, AwayGoals = 1 },
        new Match { HomeTeam = "France",        AwayTeam = "Germany",       HomeGoals = 2, AwayGoals = 2 },
        new Match { HomeTeam = "Spain",         AwayTeam = "Portugal",      HomeGoals = 1, AwayGoals = 1 },
        new Match { HomeTeam = "Netherlands",   AwayTeam = "Belgium",       HomeGoals = 2, AwayGoals = 1 },
    ];
}
