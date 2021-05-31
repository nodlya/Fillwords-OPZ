using System;
using System.Collections.Generic;
using System.Text;

namespace FILLWORDS
{
    public abstract class MenuScreens
    {
        public string Title;
        public string[] Rows;
        public abstract void DrawRows();
        public abstract void Move(ConsoleKey a);

        public static void BasicColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void SelectedColor()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public void GuessedColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }
        public void PrepareNewWindow()
        {
            Console.Clear();
            BasicColor();
        }

        public void ClearScreen()
        {
            Console.SetCursorPosition(0, 0);
            BasicColor();
        }
    }
}
