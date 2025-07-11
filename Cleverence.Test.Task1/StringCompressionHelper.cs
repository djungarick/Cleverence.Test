using System.Text;

namespace Cleverence.Test.Task1;

public static class StringCompressionHelper
{
    public static string Compress(string str)
    {
        ArgumentException.ThrowIfNullOrEmpty(str);

        StringBuilder stringBuilder = new();

        // Используем метод плавающих непересекающихся окон
        int leftPointer = 0;
        int rightPointer = 0;

        int strLength = str.Length;

        while (leftPointer < strLength)
        {
            while (rightPointer + 1 < strLength && str[rightPointer] == str[rightPointer + 1])
                rightPointer++;

            int charCount = rightPointer - leftPointer + 1;

            if (charCount == 1)
                stringBuilder.Append(str[leftPointer]);
            else
                stringBuilder.Append($"{str[leftPointer]}{charCount}");

            rightPointer = leftPointer = rightPointer + 1;
        }

        return stringBuilder.ToString();
    }

    public static string Decompress(string str)
    {
        ArgumentException.ThrowIfNullOrEmpty(str);

        StringBuilder stringBuilder = new();

        // Аналогично используем метод плавающих непересекающихся окон
        int leftPointer = 0;
        int rightPointer = 0;

        int strLength = str.Length;

        while (leftPointer < strLength)
        {
            while (rightPointer + 1 < strLength && char.IsDigit(str[rightPointer + 1]))
                rightPointer++;

            int charCount = rightPointer == leftPointer
                ? 1
                : int.Parse(str.AsSpan((leftPointer + 1)..(rightPointer + 1)));

            stringBuilder.Append(str[leftPointer], charCount);

            rightPointer = leftPointer = rightPointer + 1;
        }

        return stringBuilder.ToString();
    }
}
