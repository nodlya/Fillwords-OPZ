using System;
using System.IO;

namespace FILLWORDS
{
    static class Program
    {
        public static readonly string PatternFolderPath = @"..\\..\\..\\patterns\\";
        public static readonly string DictionaryPath = @"..\\..\\..\\original.txt";
        public static readonly string CsvPath = @"..\\..\\..\\Leaderboard.csv";
        public static Random random = new Random();
        public static MainMenu Screen1 = new MainMenu();
        public static GameScreen GS;
        public static string[] StringsFile;
        static void Main(string[] args)
        {
            Console.Title = "FILLWORDS";
            StringsFile = File.ReadAllLines(DictionaryPath);
            Screen1.Action();

            
        }
    }
}
