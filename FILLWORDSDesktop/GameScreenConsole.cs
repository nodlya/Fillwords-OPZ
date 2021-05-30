using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FILLWORDS
{
    public class GameScreen : MenuScreens
    {
        public static int[,] CellsStatus = new int[Game.Rank, Game.Rank];
        public static int X { get; private set; }
        public static int Y { get; private set; }
        public static int TimesEnterTapped { get; private set; }
        public static string PlayerWord { get; private set; }
        private bool MenuSelected = false;
        public Player Player { get; private set; }
        public static string PlayerWordPosition { get; set; }
        public GameScreen()
        {
            Rows = new string[] { "Вернуться в меню" };
            SetNewGame();
            Action();
        }

        public void Action()
        {
            while (true)
            {
                PrepareNewWindow();
                if (!GameContinues())
                {
                    Player.LevelUp();
                    NewLot();
                }

                DrawRows();
                GameInfo();
                DrawCells();
                var CK = Console.ReadKey();
                Move(CK.Key);

            }
        }

        private void SetNewGame()
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            while (name.Contains(','))
            {
                Console.WriteLine("Имя не должно содержать " +
                                  "знак запятой");
                name = Console.ReadLine();
            }
            Leaderbord.AddPlayerCsv(name);
            Player = new Player(name);
            NewLot();
        }


        public void NewLot()
        {
            Game game = new Game(Player);
            PrepareNewWindow();
            X = 0;
            Y = 0;
            TimesEnterTapped = 0;
            PlayerWord = string.Empty;
            EmptySelected();
        }

        public override void DrawRows()
        {
            if (MenuSelected)
                SelectedColor();
            Console.WriteLine(Rows[0]);
        }

        private void GameInfo()
        {
            Console.WriteLine("У вас {0} уровень и {1} очков",
                               Player.Level, Player.Points);
        }

        private void DrawCells()
        {
            for (int i = 0; i < Game.Rank; i++)
            {
                for (int j = 0; j < Game.Rank; j++)
                {
                    if (((i == X && j == Y) ||
                        CellsStatus[i, j] == 1) && !MenuSelected)
                        SelectedColor();
                    else if ((CellsStatus[i, j] == 2) && !MenuSelected)
                        GuessedColor();
                    else BasicColor();
                    Console.Write(FieldGeneration.Field[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void EmptySelected(bool b)
        {
            for (int i = 0; i < CellsStatus.GetLength(0); i++)
                for (int j = 0; j < CellsStatus.GetLength(1); j++)
                    if (CellsStatus[i, j] == 1 && !b)
                        CellsStatus[i, j] = 0;
                    else if (CellsStatus[i, j] == 1)
                        CellsStatus[i, j] = 2;
        }

        static void EmptySelected()
        {
            for (int i = 0; i < CellsStatus.GetLength(0); i++)
                for (int j = 0; j < CellsStatus.GetLength(1); j++)
                    CellsStatus[i, j] = 0;

        }
        public override void Move(ConsoleKey CK)
        {
            if (TimesEnterTapped == 1)
            {
                PlayerWord += FieldGeneration.Field[X, Y];
                CellsStatus[X, Y] = 1;
            }
            
            CheckKey(CK);

            if (TimesEnterTapped != 0)
            {
                if (CellsStatus[X, Y] == 2)
                {
                    Warning();
                    TimesEnterTapped = 0;
                }
                else
                    PlayerWordPosition += "," + Convert.ToString(X * 10 + Y);
            }
            if (TimesEnterTapped == 2)
            {
                bool b = false;
                int a = Game.CheckStatus(PlayerWord);
                GiveFeedback(a, PlayerWord);
                if (a == 3) b = true;
                EmptySelected(b);
                TimesEnterTapped = 0;
                PlayerWord = string.Empty;

            }
        }

        private void CheckKey(ConsoleKey CK)
        {
            switch (CK)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow: X--; if (X < 0) X = Game.Rank - 1; break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow: X++; if (X > Game.Rank - 1) X = 0; break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow: Y++; if (Y > Game.Rank - 1) Y = 0; break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow: Y--; if (Y < 0) Y = Game.Rank - 1; break;
                case ConsoleKey.Enter:
                    if (!MenuSelected)
                        if (CellsStatus[X, Y] == 2)
                            Warning();
                        else
                            TimesEnterTapped++;
                    else Program.Screen1.Action();
                    break;
                case ConsoleKey.Escape:
                    MenuSelected = !MenuSelected;
                    break;
                default: break;
            }
        }

        private static void Warning()
        {
            Console.WriteLine("Низя выделять буквы отгаданного слова (НЕ МОЖНО!!!!)");
            EmptySelected(false);
            Thread.Sleep(1280);
        }

        public static void GiveFeedback(int wordTrue, string word)
        {
            switch (wordTrue)
            {
                case 0:
                    Console.WriteLine("Такого слова тут нет");
                    break;
                case 1:
                    Console.WriteLine("Это слово мы не загадывали," +
                        " но оно есть в словаре");
                    break;
                case 2:
                    Console.WriteLine("Это слово есть, но попробуйте" +
                                   " собрать его по-другому");
                    break;
                case 3:
                    Console.WriteLine("И правда, " +
                          "тут есть слово " + word);
                    break;
                default: break;
            }
            Thread.Sleep(1000);
        }

        private bool GameContinues()
        {
            return Game.WordsLeft != 0;
        }
    }
}
