using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPN
{
    public class Converter
    {
        private readonly static char[] Tokens = new char[] 
        { '+', '-', '*', '/', '^', '(', ')'};
        public string ResultStringRPN { get; }
        public char[] ResultRPN { get; }

        private Calculator calculator;
    
        public double Result { get; }

        public Converter (string str)
        {
            ResultStringRPN = ToString(ReversePolish(OptimiseString(str)));
            ResultRPN = ResultStringRPN.ToArray();
            calculator = new Calculator(ResultRPN);
            Result = calculator.Result;
        }

        private char[] OptimiseString(string str)
        {
            return str
                   .ToCharArray()
                   .Where(x => x != ' ')
                   .ToArray();
        }
        private Queue<char> ReversePolish(char[] variables)
        {
            var stack = new Stack<char>();
            var queue = new Queue<char>();
            foreach (var ch in variables)
            {
                if(!Tokens.Contains(ch))
                {
                    queue.Enqueue(ch);
                }
                else
                {
                    if(stack.Count()==0 || ch=='(' || GetPriority(stack.Peek()) < GetPriority(ch))
                    {
                        stack.Push(ch);
                    }
                    else if(ch!=')')
                    {
                        while(stack.Count()!=0 && GetPriority(ch) <= GetPriority(stack.Peek()))
                        {
                            queue.Enqueue(stack.Pop());
                        }
                        stack.Push(ch);
                    }
                    else
                    {
                        while(stack.Peek()!='(')
                        {
                            queue.Enqueue(stack.Pop());
                        }
                        stack.Pop();
                    }
                }
            }
            while(stack.Count()!=0)
            {
                queue.Enqueue(stack.Pop());
            }
            return queue;
        }

        private int GetPriority(char symbol)
        {
            if (symbol == '^')
                return 3;
            else if (symbol == '*' || symbol == '/')
                return 2;
            else if (symbol == '+' || symbol == '-')
                return 1;
            return 0;
        }

        private string ToString(Queue<char> str)
        {
            var sb = new StringBuilder();
            foreach (var item in str)
                sb.Append(item + " ");
            return sb.ToString();
        }

    }
}
