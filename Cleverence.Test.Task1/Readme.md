﻿# Задача

Дана строка, содержащая n маленьких букв латинского алфавита. Требуется реализовать алгоритм компрессии этой строки, замещающий группы последовательно идущих одинаковых букв формой "sc" (где "s" – символ, "с" – количество букв в группе), а также алгоритм декомпрессии, возвращающий исходную строку по сжатой.

Если буква в группе всего одна – количество в сжатой строке не указываем, а пишем её как есть.

Пример:

Исходная строка: aaabbcccdde

Сжатая строка: a3b2c3d2e

# Реализация

[StringCompressionHelper.cs](./StringCompressionHelper.cs)

# Запуск

**Программа ожидает аргументы командной строки в виде -c|d \<string\>, где -c - compress, -d - decompress, <string> - строка, над которой будет выполнена операция**

Аргуметны можно задать в файле [launchSettings.json](./Properties/launchSettings.json)

Пример 1:  
-c aaabbcccdde

Пример 2:  
-d a3b2c3d2e
