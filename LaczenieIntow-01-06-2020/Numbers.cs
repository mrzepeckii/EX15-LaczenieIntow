using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LaczenieIntow_01_06_2020
{
    class Numbers
    {
        List<int> numbers = new List<int>();
        public void ReadNumbers()
        {
            Console.WriteLine("Type numbers - if u want to end, type -1");
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int parasedValue))
                    continue;
                if (parasedValue == -1)
                    break;
                numbers.Add(Math.Abs(parasedValue));
            }
        }

        private StringBuilder GetNumber(bool bigger)
        {
            NewComparer comparer = new NewComparer(bigger);
            StringBuilder getNumber = new StringBuilder();
            numbers.Sort(comparer);
            for (int i = 0; i < numbers.Count; i++)
                getNumber.Append(numbers[i]);

            return getNumber;
        }

        public void Write()
        {
            Console.WriteLine("The biggest number: " + GetNumber(true));
            Console.WriteLine("The lowest number: " + GetNumber(false));
        }
    }
}
