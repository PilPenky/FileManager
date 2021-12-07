using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleFileMenager
{
    public class UI
    {
        static int WidthFildPath, WidthFildinfo, WidthFildComandLine = Console.WindowWidth - 1;
        static int HeightFildPath = Console.WindowHeight - HeightFildInfo - HeightFildCommandLine;
        const int HeightFildInfo = 5;
        const int HeightFildCommandLine = 5;
        const string FildSymvols = "-|";

        public static void createUI()
        {
            for (int j = 0; j < Console.WindowHeight + 1; j++)
            {
                Console.SetCursorPosition(0, j);
                Console.Write(FildSymvols[1]);
            }

            for (int j = 0; j < Console.WindowHeight + 1; j++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 1, j);
                Console.Write(FildSymvols[1]);
            }

            for (int j = 1; j < Console.WindowWidth - 1; j++)
            {
                Console.SetCursorPosition(j, 0);
                Console.Write(FildSymvols[0]);
            }

            for (int j = 1; j < Console.WindowWidth - 1; j++)
            {
                Console.SetCursorPosition(j, HeightFildPath);
                Console.Write(FildSymvols[0]);
            }

            for (int j = 1; j < Console.WindowWidth - 1; j++)
            {
                Console.SetCursorPosition(j, Console.WindowHeight - 2);
                Console.Write(FildSymvols[0]);
            }
            for (int j = 1; j < Console.WindowWidth - 1; j++)
            {
                Console.SetCursorPosition(j, Console.WindowHeight);
                Console.Write(FildSymvols[0]);
            }
            UI.SetCursorToWriteCommand();
        }

        public static void ShowSystemInfo(string CurentInfoForShow)
        {
            ClearSystemInfo();
            int top = HeightFildPath + 1;
            int left = 2;
            Console.SetCursorPosition(left, top);
            Console.Write("Системная информация:");
            top++;
            if (CurentInfoForShow.Length > Console.WindowWidth - 2)
            {
                for (int j = 0; j < CurentInfoForShow.Length; j++)
                {
                    if (left < Console.WindowWidth - 2 && top < (HeightFildInfo + HeightFildPath + 2))
                    {
                        Console.SetCursorPosition(left, top);
                        Console.Write(CurentInfoForShow[j]);
                    }
                    if (top <= (HeightFildPath + HeightFildPath + 2))
                    {
                        left++;
                    }
                    if (left == Console.WindowWidth - 2)
                    {
                        top += 1;
                        left = 2;
                    }
                }
            }
            else
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine(CurentInfoForShow);
            }
            UI.SetCursorToWriteCommand();
        }

        public static void ClearSystemInfo()
        {
            for (int i = (HeightFildPath + 1); i < (HeightFildInfo + HeightFildPath + 2); i++)
            {
                for (int j = 1; j < Console.WindowWidth - 1; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(' ');
                }
            }
            UI.SetCursorToWriteCommand();
        }
        public static void ShowPagePaths(Config conf)
        {
            ClearPagePaths(); // очитска поля

            int top = 1;
            int left = 2;
            int symwol = 0;
            Console.SetCursorPosition(left, top);

            for (int i = 0; i < (Console.WindowHeight - 10) / 2; i++)
            {
                if (!string.IsNullOrEmpty(conf.CurrentPagesPaths[conf.NumberCurrentPage - 1, i])) //проврка на null и пустую строку
                {
                    if (conf.CurrentPagesPaths[conf.NumberCurrentPage - 1, i].Length > Console.WindowWidth - 3)
                    {
                        top = 1;
                        left = 2;

                        foreach (var item in conf.CurrentPagesPaths[conf.NumberCurrentPage - 1, i])
                        {
                            if (left < Console.WindowWidth - 2 && top < HeightFildPath)
                            {
                                Console.SetCursorPosition(left, top);
                                Console.WriteLine(item);
                                symwol++;
                            }
                            if (top <= (HeightFildPath))
                            {
                                left++;
                            }
                            if (left == Console.WindowWidth - 2)
                            {
                                top += 1;
                                left = 2;
                            }
                            if (symwol == Console.WindowWidth - 3)
                            {
                                top += 2;
                                left = 2;
                            }
                        }
                    }
                    else if (Console.WindowHeight - 10 >= top)
                    {
                        Console.SetCursorPosition(left, top);
                        Console.WriteLine(conf.CurrentPagesPaths[conf.NumberCurrentPage - 1, i]);
                        top += 2;
                    }
                }
            }
            ShowNamberPage(conf);
            SetCursorToWriteCommand();
        }
        public static void ClearPagePaths()
        {
            int top = 1;
            int left = 1;
            Console.SetCursorPosition(left, top);

            for (int i = 0; i < (HeightFildPath - 2); i++)
            {
                for (int j = 0; j < Console.WindowWidth - 1; j++)
                {
                    if (left < Console.WindowWidth - 1)
                    {
                        Console.SetCursorPosition(left, top);
                        Console.Write(' ');
                    }
                    if (top <= (HeightFildPath + 2))
                    {
                        left++;
                    }
                    if (left == Console.WindowWidth - 1)
                    {
                        top += 1;
                        left = 1;
                    }
                }
            }
        }
        public static void ShowNamberPage(Config conf)
        {
            Console.SetCursorPosition(2, HeightFildPath);
            Console.Write($"Страница ({conf.NumberCurrentPage}/{conf.NumberAllPages + 1})");
        }
        public static void SetCursorToWriteCommand()
        {
            for (int i = 1; i < Console.WindowWidth - 1; i++)
            {
                Console.SetCursorPosition(i, Console.WindowHeight - 1);
                Console.Write(' ');
            }
            ValueTuple<Int32, int> a = Console.GetCursorPosition();

            if (a.Item1 != 1 && a.Item1 != Console.WindowHeight - 1)
            {
                Console.SetCursorPosition(1, Console.WindowHeight - 1);
            }
        }

        //для просмотра информации о файлах
        public static void ShowFileInfo(string path)
        {
            ClearSystemInfo();
            FileInfo a1 = new FileInfo(path);
            int a = 0;
            string y = "";
            if( ((int.Parse(a1.Length.ToString()))/ (1024 * 1024) != 0))
            {
               a = (int.Parse(a1.Length.ToString())) / (1024 * 1024);
                y = "Mb";
            }
            else
            {
                a = (int.Parse(a1.Length.ToString())) / 1024;
                y = "Kb";
            }

            string[] info = { $"Имя папки {a1.Name}",$"Размер файла {a} {y}",$"Дата создания {a1.CreationTime}"};

            int top = HeightFildPath + 2;
            int left = 2;
            Console.SetCursorPosition(left, top);

            foreach (var item in info)
            {
                if (item.Length > Console.WindowWidth - 2)
                {
                    for (int j = 0; j < item.Length; j++)
                    {
                        if (left < Console.WindowWidth - 2 && top < (HeightFildInfo + HeightFildPath + 2))
                        {
                            Console.SetCursorPosition(left, top);
                            Console.Write(item[j]);
                        }
                        if (top <= (HeightFildPath + HeightFildPath + 2))
                        {
                            left++;
                        }
                        if (left == Console.WindowWidth - 2)
                        {
                            top += 1;
                            left = 2;
                        }
                    }
                }
                else
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine(item);
                    top++;
                }
            }
        }

        //для просмотра информации о папках
        public static void ShowDirectoryInfo(string path)
        {
            ClearSystemInfo();

            int result = 0;
            string[] info = {$"Размер Директории {DirectoryLength(path, result)/(1024*1024)} Mb", $"Дата создания {Directory.GetCreationTimeUtc(path)}" };

            int top = HeightFildPath + 2;
            int left = 2;
            Console.SetCursorPosition(left, top);

            foreach (var item in info)
            {
                if (item.Length > Console.WindowWidth - 2)
                {
                    for (int j = 0; j < item.Length; j++)
                    {
                        if (left < Console.WindowWidth - 2 && top < (HeightFildInfo + HeightFildPath + 2))
                        {
                            Console.SetCursorPosition(left, top);
                            Console.Write(item[j]);
                        }
                        if (top <= (HeightFildPath + HeightFildPath + 2))
                        {
                            left++;
                        }
                        if (left == Console.WindowWidth - 2)
                        {
                            top += 1;
                            left = 2;
                        }
                    }
                }
                else
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine(item);
                    top++;
                }
            }
        }

        public static int DirectoryLength(string path,int result)
        { 
            if (File.Exists(path))
            {
                FileInfo a1 = new FileInfo(path);
                result += int.Parse(a1.Length.ToString());
            }
            else
            {
                var aa = Directory.EnumerateFileSystemEntries(path);

                foreach (var item in aa)
                {
                    if (File.Exists(item))
                    {
                        FileInfo a1 = new FileInfo(item);
                        result += int.Parse(a1.Length.ToString());
                    }
                    else
                    {          
                        var tyre = Directory.EnumerateFileSystemEntries(item).ToArray().Length;
                        if (!(tyre == 0))
                        {
                            return DirectoryLength(item, result);
                        }
                    }
                }
            }   
            return result;
        }


    }
}

