using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Collections;
using System.IO;
using CsvHelper;
namespace FILLWORDS
{
    public class Game
    {
        public static Player ThisPlayer { get; private set; }
        public string PlayersWord { get; set; }
        public static int WordsLeft { get; private set; } 
        public static int Rank { get; private set; }
        public Game(Player player)
        {
            ThisPlayer = player;
            PlayersWord = string.Empty;
            Rank = player.SetRank();
            FieldGeneration LevelSettings = new FieldGeneration(Rank);
            WordsLeft = FieldGeneration.Words.Count;
        }

        public static int CheckStatus(string word)
        {
            int b = 0;
            if (DictionaryContainsWord(word))
            {
                b = 1;
                ThisPlayer.AddPoints(word.Length);
            }
            foreach (string a in FieldGeneration.Words)
            {
                if (a == word)
                {
                    b = 2;
                    if (FitsPattern(word))
                    {
                        b = 3;
                        WordsLeft--;
                    }
                }
            }
            
            return b;
        }

        private static bool FitsPattern(string word)
        {
            bool b = false;
            foreach (var a in FieldGeneration.Words)
                if (a == word) b = true;
            return b;
        }
      
        private static bool DictionaryContainsWord(string word)
        {
            bool b = Program.StringsFile.Any(t => t == word);
            return b;
        }
    }
}
