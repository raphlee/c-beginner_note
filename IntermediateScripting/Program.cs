using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateScripting
{

    class Yielding
    {
        public static IEnumerable<int> Foo1(int number)
        {
            int[] numbers = new int[number];
            for(int i = 0; i < number; ++i)
            {
                numbers[i] = i;
            }

            return numbers;
        }

        public static IEnumerable<int> Foo2(int number)
        {
            for(int i = 0; i < number; ++i)
            {
                if (i >= number / 2)
                    yield break;
                yield return i;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            foreach(int i in Yielding.Foo2(10)){
                Console.WriteLine(i);
            }


            Console.ReadKey();
        }
    }
}
