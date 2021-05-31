using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace fieldgeneration2
{
    static class FieldGeneration
    {
        public static char[,] field = new char[4, 4];
        
        public static List<string> words = new List<string>();

        public static void IfDirectoryExists(string path)
        {
            if (!File.Exists(path)) throw new Exception("File doesn't exist");
            else Console.WriteLine("File is ok");
        }

        public static string[] ParsePattern()
        {
            string path = @"patterns\\16cell1.txt";
            IfDirectoryExists(path);
            string[] file = File.ReadAllLines(path);
            return file;
            /*foreach (string a in file)
            Console.WriteLine(a);*/
        }

        public static void FillWordList()
        {
            string[] strings = ParsePattern();
            foreach (string a in strings)
            {
                string word = GetRandomWord(CountLetters(a));
                FitWord(word,a);
                words.Add(word);
            }
            ShowWords();
            ShowField();
        }

        private static int CountLetters(string coordinates)
        {
            int k = 1;
            foreach(char a in coordinates)
            {
                if (a == '-') k++;
            }
            return k;
        }

        public static string GetRandomWord(int length)
        {
            var random = new Random();
            string[] stringsFile = File.ReadAllLines(Program.path);
            string temp;
            do
                temp = stringsFile[random.Next(stringsFile.Length) - 1];
            while (temp.Length != length);
            return temp;
        }
       
        public static void ShowWords()
        {
            foreach (string a in words)
                Console.WriteLine(a);
        }
       
        public static void ShowField()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write(field[i, j]);
                Console.WriteLine();
            }
        }

        private static void FitWord(string word,string pattern)
        {
            int i = 0;
            string[] subPattern = pattern.Split("-");
            word = RandomReverse(word);
            foreach(string a in subPattern)
            {
                int x = int.Parse(Convert.ToString(a[0]));
                int y = int.Parse(Convert.ToString(a[2]));
                field[x, y] = word[i];
                i++;
            }
        }

        private static string RandomReverse(string word)
        {
            var a = new Random();
            bool randomBool = a.Next(0, 2) > 0;
            if (randomBool) return word;
            else return Reversed(word);
        }

        private static string Reversed(string word)
        {
            string temp = string.Empty;
            for (int i = word.Length - 1; i >= 0; i--)
                temp += word[i];
            return temp;
        }

    }


}
