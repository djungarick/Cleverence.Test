using Cleverrence.Test.Task3;
using Format1InputInfo = Cleverrence.Test.Task3.Format1Helper.InputInfo;
using Format2InputInfo = Cleverrence.Test.Task3.Format2Helper.InputInfo;

if (args.Length != 2)
    throw new Exception("Ожидались аргументы командной строки: <input_file> <output_file>, где <input_file> - исходный файл для структуризации логов, <output_file> - файл со структуризированными логами.");

if (!File.Exists(args[0]))
    throw new Exception($"Файл {args[0]} не существует.");

using StreamReader inputFileReader = new(File.OpenRead(args[0]));

// Если путь к файлу не является валидным - мы хотим получить здесь ошибку
using StreamWriter outputFileWriter = new(File.Create(args[1]));

string? outputFileDirectory = Path.GetDirectoryName(args[1]);
string problemsFilePath = outputFileDirectory is null
    ? "problems.txt"
    : Path.Combine(outputFileDirectory, "problems.txt");

using StreamWriter problemsFileWriter = new(File.Create(problemsFilePath));

string? logLine;
while ((logLine = inputFileReader.ReadLine()) is not null)
{
    DateOnly date;
    string time;
    string level;
    string caller;
    string message;

    if (Format1Helper.TryMatch(logLine, out Format1InputInfo? format1InputInfo))
    {
        (date, time, level, message) = format1InputInfo.Value;
        caller = "DEFAULT";
    }
    else if (Format2Helper.TryMatch(logLine, out Format2InputInfo? format2InputInfo))
    {
        (date, time, level, caller, message) = format2InputInfo.Value;
    }
    else
    {
        problemsFileWriter.WriteLine(logLine);
        continue;
    }

    outputFileWriter.WriteLine($"{date:dd-MM-yyyy}\t{time}\t{level}\t{caller}\t{message}");
}
