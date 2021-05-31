using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace FILLWORDS 
{
    public static class Leaderbord 
    {
        private static readonly char delimeter = ',';
        public static void AddPlayerCsv(string name)
        {
            List<string> templates = new List<string> (File.ReadAllLines(Program.CsvPath));
            string createText = name + delimeter + "0";
            templates.Add(createText);
            File.WriteAllLines(Program.CsvPath, templates, Encoding.UTF8);
        }

        public static void UpdateCsv(Player player)
        {
            string[] templates = File.ReadAllLines(Program.CsvPath);

            for (int i = 0; i < templates.Length; i++)
                if (templates[i].Contains(player.Name))
                    templates[i] = player.Name + delimeter
                                 + player.Points;


            //templates = SortCsv(templates);

            File.WriteAllLines(Program.CsvPath, templates);
        }

        private static string[] SortCsv(string[] templates)
        {
            if (templates != null)
            {
                var temp = from u in templates
                           orderby u.Substring(u.IndexOf(',')) ascending
                           select u;
                return temp.ToArray();
            }
            else return templates;
        }

        public static void WriteCsv()
        {
            string[] templates = SortCsv(File.ReadAllLines(Program.CsvPath));

            foreach (string a in templates)
            {
                Console.WriteLine(a);
            }
        }
    }

}
