using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FILLWORDS
{
    public class Game
    {
        public static Player ThisPlayer { get; private set; }
        public static string PlayersWord { get; set; }
        public static int WordsLeft { get; private set; }
        public static int Rank { get; private set; }
        public static string PlayersWordPattern { get; set; }

        public static FieldGeneration LevelSettings { get; private set; }

        public Game(Player player)
        {
            ThisPlayer = player;
            PlayersWord = string.Empty;
            PlayersWordPattern = string.Empty;
            Rank = player.SetRank();
            LevelSettings = new FieldGeneration(Rank);
            WordsLeft = FieldGeneration.Words.Count;
        }

        public static int CheckStatus()
        {
            int b = 0;
            if (DictionaryContainsWord(PlayersWord))
            {
                b = 1;
                ThisPlayer.AddPoints(PlayersWord.Length);
            }
            foreach (string a in FieldGeneration.Words)
            {
                if (a == PlayersWord)
                {
                    b = 2;
                    if (FitsPattern(PlayersWord))
                    {
                        b = 3;
                        WordsLeft--;
                    }
                }
            }
            Leaderbord.UpdateCsv(ThisPlayer);
            PlayersWord = string.Empty;
            PlayersWordPattern = string.Empty;
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
            bool b = ThingsNeededToStart.StringsFile.Any(t => t == word);
            return b;
        }

        public static void Win()
        {
            ThisPlayer.LevelUp();
            LevelSettings = new FieldGeneration(ThisPlayer.Rank);
        }
    }
}
