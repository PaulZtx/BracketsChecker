using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            CheckBrackets(str);
        }

        static void CheckBrackets(string str)
        {
            Stack<char> stack = new Stack<char>();
            Stack<int> stack2 = new Stack<int>();
            int count = 0;
            
            foreach (var st in str)
            {
                if (st != '(' && st != '[' && st != '{' &&
                    st != ')' && st != ']' && st != '}')
                {
                    ++count;
                    continue;
                }

                if (st == '(' || st == '[' || st == '{')
                {
                    stack.Push(st);
                    ++count;
                    stack2.Push(count);
                    continue;
                }

                if (stack.Count == 0)
                {
                    Console.WriteLine(++count);
                    return;
                }
                var peek = stack.Peek();

                if (peek == '(' && st == ')'
                    || peek == '{' && st == '}'
                    || peek == '[' && st == ']')
                {
                    stack.Pop();
                    stack2.Pop();
                    ++count;
                    continue;
                }

                if (peek == '(' && st != ')'
                    || peek == '{' && st != '}'
                    || peek == '[' && st != ']')
                {
                    Console.WriteLine(++count);
                    return;
                }
            }

            if (stack.Count != 0)
                Console.WriteLine(stack2.Pop());
            else Console.WriteLine("Success");
        }
    }
}