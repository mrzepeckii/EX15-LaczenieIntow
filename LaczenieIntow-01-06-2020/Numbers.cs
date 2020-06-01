using System;
using System.Collections.Generic;
using System.Text;

namespace LaczenieIntow_01_06_2020
{
    class Numbers
    {
        int[] number = new int[4];
        public void ReadNumbers()
        {
            Console.WriteLine("Type 4 numbers");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(i + 1 + " number: ");
                if (!int.TryParse(Console.ReadLine(), out int parasedValue))
                {
                    i--;
                    continue;
                }
                number[i] = Math.Abs(parasedValue);
            }
        }

        private StringBuilder GetNumber(bool bigger)
        {
            NewComparer comparer = new NewComparer(bigger);
            StringBuilder getNumber = new StringBuilder();
            Array.Sort(number, comparer);
            for (int i = 0; i < number.Length; i++)
                getNumber.Append(number[i]);

            return getNumber;
        }

        public void Write()
        {
            Console.WriteLine("The biggest number: " + GetNumber(true));
            Console.WriteLine("The lowest number: " + GetNumber(false));
        }
    }
}
