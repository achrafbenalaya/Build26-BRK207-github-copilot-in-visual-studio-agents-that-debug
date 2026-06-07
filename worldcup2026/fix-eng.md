#bug 1

The Predict method in PredictionService.cs calculates team strength by subtracting DefenseRating from AttackRating. 
This is wrong — a team's overall strength should combine both attack and defense. 
Fix the strength calculation so it adds AttackRating and DefenseRating together for both home and away teams.


#bug2 
The Predict method in PredictionService.cs never returns a draw result. 
When homeStrength equals awayStrength, it falls through and declares the away team the winner.
Add an else if condition to handle equal strength by returning "It's a draw!".


#demo 3

✅ 4 — What is ⚡ Performance Comparison?
It's a page that demonstrates why algorithm choice matters using System.Diagnostics.Stopwatch:

SlowStandingsService	FastStandingsService
Data structure	List<Standing> — linear search with FirstOrDefault() every time	Dictionary<string, int> — O(1) lookup by team name
Algorithm	Loops through 10,000 iterations (simulates expensive work), and inside each iteration scans the list for each team using FirstOrDefault() — O(n) per lookup	Single pass through all matches, O(1) dictionary lookup
Result	Slow (hundreds of ms)	Fast (< 1 ms)
What it does: When you click "Run Comparison", it times both services with Stopwatch and shows the result in a table: "Fast version is X× faster!"

Demo takeaway: Choosing the right data structure (Dictionary vs List) and avoiding unnecessary re-computation can make code orders of magnitude faster.



#Unit Test

Add comprehensive xUnit tests to the woldcupunittest project for my World Cup 2026 Blazor app. The test project already references xUnit 2.9.3 and targets net10.0. You will need to add a project reference to the worldcup2026 project.

Write tests for the following:

PredictionService tests:
- Test that when home team has higher total strength (AttackRating + DefenseRating) than away, the result contains the home team name and "wins"
- Test that when away team has higher total strength, the result contains the away team name and "wins"
- Test that when both teams have equal total strength, the result contains "draw" (this test should FAIL initially — it proves Bug 2 exists)
- Test that strength calculation uses addition not subtraction (this test should FAIL initially — it proves Bug 1 exists)

FlagHelper tests:
- Test IsoCountryCodeToFlagEmoji converts "US" to the US flag emoji 🇺🇸
- Test IsoCountryCodeToFlagEmoji converts "FR" to the France flag emoji 🇫🇷
- Test GetFlag maps FIFA code "USA" to the US flag emoji
- Test GetFlag handles England "ENG" returning the England subdivision flag 🏴󠁧󠁢󠁥󠁮󠁧󠁿 (not the UK flag)
- Test GetFlag returns a white flag for unknown codes

SlowStandingsService and FastStandingsService tests:
- Test that both services return the same standings results (same teams, same points)
- Test that a home win awards 3 points to home team and 0 to away
- Test that a draw awards 1 point to each team
- Test that an away win awards 3 points to away team and 0 to home

Create separate test classes per service. Use descriptive test method names. Use the Arrange-Act-Assert pattern. For services that need WorldCupDataService, mock it or create test instances with known data.

#5

Run the app → go to Performance → click Run Test → see "SlowStandingsService: ~1700 ms"
Open VS Profiler (Alt+F2) → select CPU Usage → run → click Run Test again → stop profiler
See the hot path: SlowStandingsService.GetStandings() → the 10,000-iteration loop + List.FirstOrDefault() O(n) scans
Ask Copilot to fix it with this prompt:
The Visual Studio Profiler shows that SlowStandingsService.GetStandings() in Services/SlowStandingsService.cs is extremely slow. The hot path is List.FirstOrDefault() being called inside a loop of 10,000 iterations. Rewrite this method to be fast: remove the unnecessary 10,000× loop (it should calculate standings in a single pass), and replace the List<Standing> with a Dictionary<string, int> so team lookups are O(1) instead of O(n). Keep the same return type List<Standing> ordered by points descending.