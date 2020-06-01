using System;
using System.Collections;
using System.Collections.Generic;

namespace LaczenieIntow_01_06_2020
{
    class Program
    {
        public class NewComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                Stack<int> stackX = CreateStack(x);
                Stack<int> stackY = CreateStack(y);
                int j = 0;
                int k = 0;

                while (j == k)
                {
                    if (Numbers.TheBiggest)
                    {
                        if (stackX.Peek() < stackY.Peek())
                            return 1;
                        if (stackX.Peek() > stackY.Peek())
                            return -1;
                    }
                    else
                    {
                        if (stackX.Peek() < stackY.Peek())
                            return -1;
                        if (stackX.Peek() > stackY.Peek())
                            return 1;
                    }
                    j = stackX.Pop();
                    k = stackY.Pop();
                    if (stackX.Count == 0 || stackY.Count == 0)
                        break;
                }
                return 0;
            }

            private Stack<int> CreateStack(int x)
            {
                Stack<int> stackX = new Stack<int>();
                int xNumber = 0;
                if (x != 0)
                {
                    while (x != 0)
                    {
                        xNumber = x % 10;
                        x /= 10;
                        stackX.Push(xNumber);
                    }
                }
                else
                    stackX.Push(x);
                return stackX;
            }
        }
        public class Numbers
        {
            public static bool TheBiggest { get; private set; }
            NewComparer comparer = new NewComparer();
            
            int[] number = new int[4];
            public void ReadNumbers()
            {
                Console.WriteLine("Type 4 numbers");
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine(i+1 + " number: ");
                    number[i] = Math.Abs((Convert.ToInt32(Console.ReadLine())));
                }
            }

            private string GetNumber(bool bigger)
            {
                string getNumber ="";
                TheBiggest = bigger;
                Array.Sort(number, comparer);
                for (int i = 0; i < number.Length; i++)
                {
                    getNumber += number[i];
                }
                return getNumber;
            }
            
            public void Write()
            {
                Console.WriteLine("The biggest number: " + GetNumber(true)) ;
                Console.WriteLine("The lowest number: " + GetNumber(false));
            }

        }
        static void Main(string[] args)
        {
            Numbers numbers = new Numbers();
            numbers.ReadNumbers();
            numbers.Write();
        }

        
    }
}
