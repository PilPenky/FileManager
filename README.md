Добро пожаловать в файловый менеджер.

Настоящая программа разработана в рамках курсовой работы по курсу «Введения в C#». Программа показывает файлы и папки на персональном компьютере, а также позволяет выполнять ряд команд, таких как: переход между папок, копирование и удаление файлов и папок, просмотр информации о файле или папке.

-
Список команд:

Просмотр файловой структуры:
cd - перейти в необходимую папку. 

Пример: cd C:\

cpg - перейти на другую страницу

Пример: cpg 4

-
Поддержка копирования файлов и папок:

cpf - копирование файла из одной папки в другую.

Пример: cpf C:\any_file.txt C:\any_folder\any_file.txt

cpdir - копирование папки из одного места расположения в другое.

Пример: cpdir C:\any_folder C:\Temp\any_folder


Обращаю внимание, что при выполнении команд копирования файла или папки (cpf / cpdir), необходимо ставить пробел между начальным и конечным местоположением файла или папки.

-
Поддержка удаления файлов и папок:

rmf - удалить указанный файл.

Пример: rmf C:\any_file.txt

rmdir - удалить указанную папку.

Пример: rmdir C:\any_folder

-
Поддержка просмотра информации о файлах и папках:
fif – просмотр информации об указанном файле.
Пример: fif C:\any_file.txt
di – просмотр информации об указанной папке.
Пример: di C:\any_folder

Обращаю внимание, что в поддержку просмотра информации о файлах и папках входит информация о размере и дате создания файла или папки.
