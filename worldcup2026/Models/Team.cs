namespace worldcup2026.Models;

public class Team
{
    public string Flag { get; set; } = "";
    public string Name { get; set; } = "";
    public string Group { get; set; } = "";
    public int AttackRating { get; set; }
    public int DefenseRating { get; set; }
}
