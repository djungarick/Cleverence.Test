using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Cleverrence.Test.Task3;

public static partial class Format1Helper
{
    private const string Date = "date";
    private const string Time = "time";
    private const string Level = "level";
    private const string Message = "message";

    private static readonly Regex _regex = MyRegex();

    public static bool TryMatch(string input, [NotNullWhen(true)] out InputInfo? inputInfo)
    {
        inputInfo = null;

        Match match = _regex.Match(input);

        if (!match.Success)
            return false;

        if (!DateOnly.TryParseExact(match.Groups[Date].ValueSpan, "dd.MM.yyyy", out DateOnly dateOnly))
            return false;

        if (!LevelParser.TryParseLevel(match.Groups[Level].Value, out string? parsedLevel))
            return false;

        inputInfo = new InputInfo(dateOnly, match.Groups[Time].Value, parsedLevel, match.Groups[Message].Value);

        return true;
    }

    [GeneratedRegex($$"""^(?<{{Date}}>\d{2}\.\d{2}\.\d{4})\s*"""
        + $$"""(?<{{Time}}>\d{2}:\d{2}:\d{2}\.\d{3})\s*"""
        + $$"""(?<{{Level}}>[A-Za-z]+)\s*"""
        + $$"""(?<{{Message}}>.+)$""",
        RegexOptions.Compiled)]
    private static partial Regex MyRegex();

    public record struct InputInfo(DateOnly Date, string Time, string Level, string Message);
}
