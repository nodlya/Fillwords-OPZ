using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;

namespace FILLWORDS
{
    public enum CellStatus
    {
        Free,
        Selected,
        Guessed
    }

    public static class ThingsNeededToStart
    {
        public static readonly string CsvPath = @"..\\..\\Leaderboard.csv";
        public static Player Player;
        public static Game Game;

        public static Dictionary<CellStatus, SolidColorBrush> Colors =
            new Dictionary<CellStatus, SolidColorBrush>()
            {
                [CellStatus.Free] = Brushes.Yellow,
                [CellStatus.Selected] = Brushes.BlueViolet,
                [CellStatus.Guessed] = Brushes.Gray
            };


        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}