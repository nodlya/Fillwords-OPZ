using System;
using System.Collections.Generic;
using System.Linq;

namespace OPZ
{
    public class Calculator
    {
        readonly char[] Symbols = new char[] { '+', '-', '*', '/', '^'};

        public double Calculate(char[] chars)
        {
            var stack = new Stack<double>();
            foreach (var item in chars)
            {
                if (!Symbols.Contains(item))
                {
                    stack.Push(double.Parse(item.ToString()));
                }
                else
                {
                    stack.Push(IdentifyOperator(item, stack.Pop(), stack.Pop()));
                }
            }
            return stack.Pop();
        }

        private double IdentifyOperator(char op, double first, double second)
        {
            switch (op)
            {
                case '+':
                    return second + first;
                case '-':
                    return second - first;
                case '*':
                    return second * first;
                case '/':
                    return second / first;
                case '^':
                    return Math.Pow(second,first);
                default:
                    throw new Exception("Такого оператора нет");
            }
        }
    }
}
