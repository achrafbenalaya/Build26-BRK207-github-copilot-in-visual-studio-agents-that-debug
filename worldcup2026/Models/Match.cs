namespace worldcup2026.Models;

public class Match
{
    public string HomeTeam { get; set; } = "";
    public string AwayTeam { get; set; } = "";
    public int HomeGoals { get; set; }
    public int AwayGoals { get; set; }
}
