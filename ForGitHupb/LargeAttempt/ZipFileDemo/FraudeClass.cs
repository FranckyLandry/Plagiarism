using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipFileDemo
{
    class FraudeClass
    {
        public int factorial(int num)
        {
            /* local variable declaration */
            int result;
            if (num == 1)
            {
                return 1;
            }
            else
            {
                result = factorial(num - 1) * num;
                return result;
            }
        }


        public int AddNumbers(int number1, int number2)
        {
            int result = number1 + number2;
            if (result > 10)
            {
                return result;
            }
            return 0;
        }
        static void Swap(int a, int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
            Console.WriteLine("Inside Swap method");
            Console.WriteLine("a is {0}", a);
            Console.WriteLine("b is {0}", b);
        }
    }
}
