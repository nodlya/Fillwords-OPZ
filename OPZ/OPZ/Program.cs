using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPZ
{
    class Program
    {
        static void Main(string[] args)
        {
            var strForPolish = "3 + 4 * 2 / (1 - 5)^2";
            var converter = new Converter();
            Console.WriteLine("Обратная польская запись " + strForPolish + " равно "
                + converter.ToString(converter.ToReversePolish(OptimizeString(strForPolish))));

            var calculator = new Calculator();
            var strForCalculatePolish = "7 5 2 - 4 * +";
            Console.WriteLine(strForCalculatePolish + " равно " + calculator.Calculate(OptimizeString(strForCalculatePolish)));
        }

        static char[] OptimizeString(string str)
        {
            return str
                .ToCharArray()
                .Where(x => x != ' ')
                .ToArray();
        }
    }
}
