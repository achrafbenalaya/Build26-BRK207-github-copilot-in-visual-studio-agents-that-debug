using worldcup2026.Models;

namespace worldcup2026.Services;

public class PredictionService
{
    public string Predict(Team home, Team away)
    {
        int homeStrength = home.AttackRating - home.DefenseRating;  // BUG: should be +
        int awayStrength = away.AttackRating - away.DefenseRating;  // BUG: should be +

        if (homeStrength > awayStrength)
            return $"{home.Flag} {home.Name} wins!";
        // BUG: draw not handled — falls through to away win
        return $"{away.Flag} {away.Name} wins!";
    }
}
