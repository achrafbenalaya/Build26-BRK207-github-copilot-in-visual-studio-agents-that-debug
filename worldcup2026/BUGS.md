# 🐛 Known Bugs in PredictionService

These bugs were **intentionally** placed for a live coding demo.

---

## Bug 1 — Defense is subtracted instead of added

**File:** `Services/PredictionService.cs`

**Buggy code:**
```csharp
int homeStrength = home.AttackRating - home.DefenseRating;  // BUG
int awayStrength = away.AttackRating - away.DefenseRating;  // BUG
```

**What's wrong:**  
Strength should combine attack AND defense (`+`), but the code subtracts defense.  
A strong defender like France (ATK 9, DEF 9) gets strength **0** instead of **18**.

**How to reproduce:**  
Go to the Predictor page, pick France vs Germany — both show Strength 0 because `9 - 9 = 0` and `8 - 8 = 0`. Germany is declared the winner even though the strengths are equal.

**Fix:**  
Change `-` to `+`:
```csharp
int homeStrength = home.AttackRating + home.DefenseRating;
int awayStrength = away.AttackRating + away.DefenseRating;
```

---

## Bug 2 — Draws are never predicted

**File:** `Services/PredictionService.cs`

**Buggy code:**
```csharp
if (homeStrength > awayStrength)
    return $"{home.Flag} {home.Name} wins!";
// No else-if for equal strength
return $"{away.Flag} {away.Name} wins!";
```

**What's wrong:**  
When both teams have the same strength, the code skips straight to "Away wins!" — it never returns a draw result.

**How to reproduce:**  
Pick two teams with equal ratings (e.g., Mexico ATK 7 / DEF 7 vs Korea Republic ATK 7 / DEF 7). After fixing Bug 1, both have strength 14, but the app says the away team wins.

**Fix:**  
Add an `else if` for equal strength:
```csharp
if (homeStrength > awayStrength)
    return $"{home.Flag} {home.Name} wins!";
else if (homeStrength == awayStrength)
    return "It's a draw!";
else
    return $"{away.Flag} {away.Name} wins!";
```
