using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyGirlWithExtension
{

    //

    class AnonymousMethodYo
    {
        public void DoAnonymous()
        {
            int[] IntArr = {1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // from delegate ... -> Anonymous Method (Pridicate<T> match)
            int[] OddArr = Array.FindAll(IntArr, delegate (int value)
            {
                return value % 2 == 1;
            });

            // 2nd param is Action<T>
            Array.ForEach(OddArr, delegate (int value) { Console.WriteLine(value); });

            // 2nd param is Comparision<T>: 
            Array.Sort(IntArr, delegate (int x, int y) { return x.CompareTo(y); });
        }
    }

    class LambdaExpressionYo
    {

        // (parameter-list) =>  expression
        public void DoLambda()
        {
            int[] IntArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // from delegate ... -> Anonymous Method (Pridicate<T> match)
            int[] OddArr = Array.FindAll(IntArr, (value) => value % 2 == 1);
            

            // 2nd param is Action<T>
            Array.ForEach(OddArr, (value) => Console.WriteLine(value));

            // 2nd param is Comparision<T>: 
            Array.Sort(IntArr, (x, y) => x.CompareTo(y));

            //BubbleSort(IntArr, (first, second) => first < second); ???
        }
    }


    // the System.Action family of delegates is for referring to void-returning methods

    // the System.Func family of delegates is for referring to returning methods, like below
    class DelegateFuncYo
    {
        // Mix with Lambda func
        // Syntax: Func<T, T, ..., TResult>


        // We can use it many times

        // name of Func // parametter-list (Lambda func))
        Func<string, int> stringLength = (s) => s.Length; // here, T is string; TResult is type int

        // multiply float and int, and result is float
        Func<float, int, float> multiply = (x, y) => x * y;

        public void DoThing()
        {
            Console.WriteLine(stringLength("Man of the world"));

            float result = multiply(1.3f, 22);
            Console.WriteLine(result);
        }


        // Action, still use Lambda function, return void
        Action<int> DoWorkWithAction = (x) => Console.WriteLine(x);
    }

    // NOTICE:  instance method is higher prior than extension method.
    public static class ExtensionForProgram
    {
        // all class and method you wanna add to A, must be static (public ?)
        // method must be had 'this' keyword to 1st param, this param must be A type.
        public static void DoProgramMe(this Program Integer)        // it must be a reference data type
        {
            Console.WriteLine("Extension");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var lazyObject = new Lazy<object>(() => { return LoadData(); });
            Console.WriteLine(lazyObject);
            Console.WriteLine(lazyObject.Value);


            Program program = new Program();
            program.DoProgramMe();      // print Extension

            LambdaExpressionYo lambda = new LambdaExpressionYo();
            lambda.DoLambda();

            DelegateFuncYo delegateYo = new DelegateFuncYo();
            delegateYo.DoThing();

            Console.ReadKey();
        }

        static string LoadData()
        {
            Console.WriteLine("Start loading");
            return "This is a 'HUGE' data";
        }

        //public void DoProgramMe() { Console.WriteLine("Instance Method is higher prior"); }
    }
}
