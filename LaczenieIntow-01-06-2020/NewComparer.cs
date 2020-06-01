using System;
using System.Collections.Generic;
using System.Text;

namespace LaczenieIntow_01_06_2020
{
    class NewComparer : IComparer<int>
    {
        private bool theBiggest;
        public NewComparer(bool theBiggest)
        {
            this.theBiggest = theBiggest;
        }

        public int Compare(int x, int y)
        {
            Stack<int> stackX = CreateStack(x);
            Stack<int> stackY = CreateStack(y);
            int stackXLastItem = 0;
            int stackYLastItem = 0;

            while (stackXLastItem == stackYLastItem)
            {
                if (theBiggest)
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
                stackXLastItem = stackX.Pop();
                stackYLastItem = stackY.Pop();
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
}
