using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;

namespace Cleverrence.Test.Task3;

public static class LevelParser
{
    private static readonly FrozenDictionary<string, string> _levels
        = new Dictionary<string, string>()
        {
            ["INFO"] = "INFO",
            ["INFORMATION"] = "INFO",
            ["WARN"] = "WARN",
            ["WARNING"] = "WARN",
            ["ERROR"] = "ERROR",
            ["DEBUG"] = "DEBUG",
        }
        .ToFrozenDictionary();

    public static bool TryParseLevel(string level, [NotNullWhen(true)] out string? parsedLevel)
        => _levels.TryGetValue(level.ToUpper(), out parsedLevel);
}
