using System;
using System.Collections.Generic;
using System.Text;

namespace FILLWORDS
{
    public class Player
    {
        public readonly string Name;
        public int Level { get; private set; }
        public int Points { get; private set; }
        public int Rank { get; private set; }

        public Player(string name)
        {
            Name = name;
            Level = 1;
            Points = 0;
            Rank = 4;
            SetRank();
        }

        public void LevelUp()
        {
            Level++;
            Points += Level;
            SetRank();
        }
        public void AddPoints(int length)
        {
            Points += length;
            Leaderbord.UpdateCsv(Game.ThisPlayer);
        }

        public int SetRank()
        {
            Rank = (Level / 10) + 4;
            return Rank;
        }
    }
}
