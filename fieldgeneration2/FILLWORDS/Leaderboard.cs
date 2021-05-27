using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace FILLWORDS 
{
    public static class Leaderbord //Если все методы содержат цсв то их логично засунуть в статик класс CSV
    {
        public static readonly string csvPath = @"..\\..\\..\\Leaderboard.csv";
        private static readonly char delimeter = ',';
        public static void AddPlayerCsv(string name)
        {
            List<string> templates = new List<string> (File.ReadAllLines(csvPath));
            string createText = name + delimeter + "0";
            templates.Add(createText);
            File.WriteAllLines(csvPath, templates, Encoding.UTF8);
        }

        public static void UpdateCsv(Player player)
        {
            string[] templates = File.ReadAllLines(csvPath);

            for (int i = 0; i < templates.Length; i++)
                if (templates[i].Contains(player.Name))
                    templates[i] = player.Name + delimeter
                                 + player.Points;


            templates = SortCsv(templates);

            File.WriteAllLines(csvPath, templates);
        }

        private static string[] SortCsv(string[] templates)
        {
            if (templates != null)
            {
                var temp = from u in templates
                           orderby u.Substring(u.IndexOf(',')) descending
                           select u;
                return temp.ToArray();
            }
            else return templates;
        }

        public static void WriteCsv()
        {
            string[] templates = File.ReadAllLines(csvPath);
            foreach (string a in templates)
            {
                Console.WriteLine(a);
            }
        }
    }

}
