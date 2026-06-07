namespace worldcup2026.Helpers;

// Source - https://stackoverflow.com/a/61472035
// Posted by M. Hamza Rajput
// Retrieved 2026-06-07, License - CC BY-SA 4.0
public static class FlagHelper
{
    public static string IsoCountryCodeToFlagEmoji(this string country)
    {
        return string.Concat(country.ToUpper().Select(x => char.ConvertFromUtf32(x + 0x1F1A5)));
    }

    public static string GetFlag(string fifaCode)
    {
        // England and Scotland use tag sequences, not regional indicators
        if (fifaCode == "ENG") return "🏴󠁧󠁢󠁥󠁮󠁧󠁿";
        if (fifaCode == "SCO") return "🏴󠁧󠁢󠁳󠁣󠁴󠁿";

        var iso = FifaToIso.GetValueOrDefault(fifaCode, fifaCode);
        return iso.Length == 2 ? iso.IsoCountryCodeToFlagEmoji() : "🏳️";
    }

    private static readonly Dictionary<string, string> FifaToIso = new()
    {
        ["MEX"] = "MX", ["RSA"] = "ZA", ["KOR"] = "KR", ["CZE"] = "CZ",
        ["CAN"] = "CA", ["BIH"] = "BA", ["QAT"] = "QA", ["SUI"] = "CH",
        ["HTI"] = "HT", ["SCO"] = "GB", ["BRA"] = "BR", ["MAR"] = "MA",
        ["USA"] = "US", ["PAR"] = "PY", ["AUS"] = "AU", ["TUR"] = "TR",
        ["CIV"] = "CI", ["ECU"] = "EC", ["GER"] = "DE", ["CUW"] = "CW",
        ["NED"] = "NL", ["JPN"] = "JP", ["SWE"] = "SE", ["TUN"] = "TN",
        ["BEL"] = "BE", ["EGY"] = "EG", ["IRN"] = "IR", ["NZL"] = "NZ",
        ["KSA"] = "SA", ["URY"] = "UY", ["ESP"] = "ES", ["CPV"] = "CV",
        ["FRA"] = "FR", ["SEN"] = "SN", ["IRQ"] = "IQ", ["NOR"] = "NO",
        ["ARG"] = "AR", ["ALG"] = "DZ", ["AUT"] = "AT", ["JOR"] = "JO",
        ["POR"] = "PT", ["COD"] = "CD", ["UZB"] = "UZ", ["COL"] = "CO",
        ["ENG"] = "GB", ["CRO"] = "HR", ["GHA"] = "GH", ["PAN"] = "PA",
    };
}
