using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FILLWORDS
{
    public class FieldGeneration
    {
        public static char[,] Field { get; set; }

        public static List<string> Words { get; set; }

        public static List<Word> Words1 = new List<Word>();
        private static int rank;

        public FieldGeneration(int Rank)
        {
            rank = Rank;
            Field = new char[Rank, Rank];
            Words = new List<string>();
            FillWordList();
        }

        private static string PickRandomPattern()
        {
            string path = ThingsNeededToStart.PatternFolderPath 
                        + Convert.ToString(rank);
            var random = new Random();
            string[] files = Directory.GetFiles(path);
            string temp = files[random.Next(0, files.Length)];
            return new FileInfo(temp).Name;
        }
        public static string[] ParsePattern(string fileName)
        {
            string path = ThingsNeededToStart.PatternFolderPath + Convert.ToString(rank) + @"\\" + fileName;
            string[] file = File.ReadAllLines(path);
            return file;
        }

        private static void FillWordList()
        {

            string[] strings = ParsePattern(PickRandomPattern());
            foreach (string a in strings)
            {
                string word = GetRandomWord(CountLetters(a));
                FitWord(word, a);
                Words.Add(word);
            }

        }

        private static int CountLetters(string coordinates)
        {
            int k = 1;
            foreach (char a in coordinates)
            {
                if (a == ',') k++;
            }
            return k;
        }

        private static string GetRandomWord(int length)
        {
            string temp;
            do
                temp = ThingsNeededToStart.StringsFile[ThingsNeededToStart.random.Next(ThingsNeededToStart.StringsFile.Length) - 1];
            while (temp.Length != length || Used(temp));
            return temp;
        }

        private static bool Used(string word)
        {
            return Words.Find(a => a == word) == null ? false : true;
        }

        private static void FitWord(string word, string pattern)
        {
            int i = 0;
            string[] subPattern = pattern.Split(',');
            Word word1 = new Word(word, pattern);
            Words1.Add(word1);
            word = RandomReverse(word);
            foreach (string a in subPattern)
            {
                int x = int.Parse(Convert.ToString(a[0]));
                int y = int.Parse(Convert.ToString(a[1]));
                Field[x, y] = word[i];
                i++;
            }
        }

        private static string RandomReverse(string word)
        {
            return (ThingsNeededToStart.random.Next(0, 2) > 0) ? word : Reversed(word);
        }

        private static string Reversed(string word)
        {
            string temp = string.Empty;
            for (int i = word.Length - 1; i >= 0; i--)
                temp += word[i];
            return temp;
        }

    }

    public class Word
    {
        public readonly string ActualWord;
        public string LocationOnField { get; private set; }

        public Word(string word, string pattern)
        {
            ActualWord = word;
            LocationOnField = pattern;
        }
    }
}
