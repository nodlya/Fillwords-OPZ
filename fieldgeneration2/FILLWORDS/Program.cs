using System;

namespace FILLWORDS
{
    static class Program
    {

        public static string path = @"..\\..\\..\\original.txt";
        public static MainMenu Screen1 = new MainMenu();
        public static GameScreen GS;
        static void Main(string[] args)
        {
            Screen1.Action();

            
        }
    }
}
