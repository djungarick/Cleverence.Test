using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Cleverrence.Test.Task3;

public static partial class Format2Helper
{
    private const string Date = "date";
    private const string Time = "time";
    private const string Level = "level";
    private const string Caller = "caller";
    private const string Message = "message";

    private static readonly Regex _format2Regex = GetFormat2Regex();

    public static bool TryMatch(string input, [NotNullWhen(true)] out InputInfo? inputInfo)
    {
        inputInfo = null;

        Match match = _format2Regex.Match(input);

        if (!match.Success)
            return false;

        if (!DateOnly.TryParseExact(match.Groups[Date].ValueSpan, "yyyy-MM-dd", out DateOnly dateOnly))
            return false;

        if (!LevelParser.TryParseLevel(match.Groups[Level].Value, out string? parsedLevel))
            return false;

        inputInfo = new InputInfo(dateOnly, match.Groups[Time].Value, parsedLevel, match.Groups[Caller].Value, match.Groups[Message].Value);

        return true;
    }

    [GeneratedRegex($$"""^(?<{{Date}}>\d{4}-\d{2}-\d{2})\s*?"""
        + $$"""(?<{{Time}}>\d{2}:\d{2}:\d{2}\.\d{4})\s*?\|\s*?"""
        + $$"""(?<{{Level}}>[A-Za-z]+)\s*?\|\s*?"""
        + $$"""(?<unknownDigitsToIgnore>\d+\s*?\|\s*?)?"""
        + $$"""(?<{{Caller}}>.+?)\s*?\|\s*?"""
        + $$"""(?<{{Message}}>.+)$""",
        RegexOptions.Compiled)]
    private static partial Regex GetFormat2Regex();

    public record struct InputInfo(DateOnly Date, string Time, string Level, string Caller, string Message);
}
