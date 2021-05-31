using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace FILLWORDS
{

    public class MainMenu : MenuScreens
    {
        private int SelectedRow = 0;
        private static GameScreen newGame;
        public MainMenu()
        {
            Rows = new string[] {"Новая игра","Продолжить",
                                 "Рейтинг","Выход" };
        }

        public void Action()
        {
            ConsoleKeyInfo CK;
            do
            {
                DrawRows();
                CK = Console.ReadKey();
                if (CK.Key == ConsoleKey.Enter) RowAction();
                else Move(CK.Key);
            }
            while (CK.Key != ConsoleKey.Enter);
        }
        public override void DrawRows()
        {
            PrepareNewWindow();
            int Y = -1;           
            for (int i=0;i<Rows.Length; i++)
            {
                if (IfChosen(i)) SelectedColor();
                else BasicColor();
                int X = (Console.WindowWidth / 2) - (Rows[i].Length / 2);
                Console.SetCursorPosition(X,++Y);
                Console.WriteLine(Rows[i]);
            }
            Console.CursorVisible = false;
        }

        private bool IfChosen(int i) 
        {
            return i == SelectedRow;
        }

        public override void Move(ConsoleKey CK)
        {
            if (CK == ConsoleKey.UpArrow ||
                CK == ConsoleKey.W)
                if (SelectedRow == 0) SelectedRow = Rows.Length-1;
                else SelectedRow--;

            if (CK == ConsoleKey.DownArrow ||
                CK == ConsoleKey.S)
                if (SelectedRow == Rows.Length - 1) SelectedRow = 0;
                else SelectedRow++;

        }

        private void RowAction()
        {
            switch (SelectedRow)
            {
                case 0: StartGame(); break;
                case 1: ContinueLastGame(); break;
                case 2: ShowRating(); break;
                case 3: Environment.Exit(0); break;
                default: throw new Exception("технические шоколадки");
            }
        }

        public void StartGame() 
        {
            PrepareNewWindow();
            newGame = new GameScreen();
            Program.GS = newGame;
        }
        private void ContinueLastGame()
        {
            if (Program.GS != null) Program.GS.NewLot();
            else
            {
                PrepareNewWindow();
                Console.WriteLine("Игра не начата");
                Thread.Sleep(1000);
                Action();
            }
        }
        private void ShowRating() 
        { 
            PrepareNewWindow();
            Leaderbord.WriteCsv();
            var CK = Console.ReadKey();
            if (CK.Key == ConsoleKey.Enter)
                Action();
        }

    }

    public class LeaderboardScreen : MenuScreens
    {
        public LeaderboardScreen()
        {
            DrawRows();
            var CK = Console.ReadKey();
            Move(CK.Key);
        }
        public override void DrawRows() => Leaderbord.WriteCsv();

        public override void Move(ConsoleKey a)
        {
            if (a==ConsoleKey.Enter)
                Program.Screen1.Action();
        }

    }
}
