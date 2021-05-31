using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPZ
{
    public class Converter
    {
        readonly char[] Symbols = new char[] { '+', '-', '*', '/', '^', '(', ')'};

        public Queue<char> ToReversePolish(char[] variables)
        {
            var stack = new Stack<char>();
            var queue = new Queue<char>();
            foreach (var ch in variables)
            {
                if(!Symbols.Contains(ch))
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
                return 4;
            else if (symbol == '*' || symbol == '/')
                return 3;
            else if (symbol == '+' || symbol == '-')
                return 2;
            return 1;
        }

        public string ToString(Queue<char> str)
        {
            var sb = new StringBuilder();
            foreach (var item in str)
            {
                sb.Append(item + " ");
            }
            return sb.ToString();
        }
    }
}
