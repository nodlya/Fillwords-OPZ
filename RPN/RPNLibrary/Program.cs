using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    class Program
    {
        static void Main(string[] args)
        {
            string strForPolish = Console.ReadLine();
            var converter = new Converter(strForPolish);
            Console.WriteLine("Обратная польская запись " 
                              + converter.ResultStringRPN + " равно "
                              + Convert.ToString(converter.Result));
        }

        
    }
}
