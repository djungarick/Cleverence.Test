using Cleverence.Test.Task1;

if (args.Length != 2 || args[0] is not "-c" and not "-d")
    throw new Exception("Ожидались аргументы командной строки: -c|d <string>, где -c - compress, -d - decompress, <string> - строка, над которой будет выполнена операция.");

if (args[0] is "-c")
    Console.WriteLine(StringCompressionHelper.Compress(args[1]));
else
    Console.WriteLine(StringCompressionHelper.Decompress(args[1]));
