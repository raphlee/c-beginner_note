using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


// alias
using CountDownTimer = System.Timers.Timer;

// using namespace

namespace HelloWorld
{
    class Program
    {
        // access modifiers: 5 types   
        public string name;
        private object feature;
        protected int value;
        internal bool isTrue;
        protected internal float fee;

        // declaring a property
        private string _firstName;  // need to declare first, then declare property: set and get func
        public string firstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;     // special keyword for this scenario
            }
        }


        private int _age;
        public int age
        {
            get
            {
                return _age;
            }

            private set             //
            {
                _age = value;
            }
        }

        public string title { get; set; } = "employee"; // not attually stored, be carefull. value will assign to origin prop

        public object readOnly { get; } // be carefull

        


        static void Main(string[] args)
        {
            #region Hello 

            HelloWorld.Program myWorld = new HelloWorld.Program();
            myWorld.Control();

            Program program = new Program();
            program.Control();

           // CountDownTimer timer;

            string hello = "Welcome to the C# world.";
            System.Console.WriteLine(hello);

            System.Console.WriteLine("Enter your name: ");
            string name = System.Console.ReadLine();

            System.Console.WriteLine("So, your name is: (same Java) " + name);          // same java
            System.Console.WriteLine($"Another way to print (with $ ahead): {name}");      // must be have $ syntax ahead
            System.Console.WriteLine("Another way to print: {0} (replace index)", name);    // no need $ ahead. using {i}, just like %(x).

            System.Console.WriteLine("Enter a number: ");
            string input = System.Console.ReadLine();
            double number;
            if(double.TryParse(input, out number))
            {
                System.Console.WriteLine("Your number is: " + number);
            }
            else
            {
                System.Console.WriteLine("Invalid number");
            }

            // try catch finally (maybe), further, we have unchecked
            //checked
            //{
            //    int n = int.MaxValue;
            //    n++;
            //    System.Console.WriteLine(n);
            //}

            string[] languages = { "C", "C++", "C#", "Java", "VB" ,"Python" };

            System.Array.IndexOf(languages, "C#");
            System.Array.Sort(languages); // and 17 more methods, ctrl + space to see

            int[] numbers = new int[7];

            // multi dimension
            int[,] cells = { { } };

            int sum = Addition(5, 5);
            string first = "first";
            string second = "second";
            Swap(ref first, ref second);
            System.Console.WriteLine($"Sum: { sum }, First: { first }; Second: { second }");

            char button;  // uninitialized variable
            bool isGetButton = TryGetButton('Z', out button);   // now button will get a value

            DoStuff(sum, 1, 2, 3);  // or int[]
            Method(sum);


            DisplayGreeting("Raph");
            DisplayGreeting("Santiago", lastName: "Lee");
            DisplayGreeting("Ngoc", middleName: "Xuan", lastName: "Dang");

//#warning "Warning"

            #endregion Hello world


            try
            {

            }
            catch (Exception)
            {
                
            }
            finally
            {

            }
        }

        // methods using in Main() must be a static methods.
        static int Addition(int a, int b)
        {
            return a + b;
        }

        // Reference Parameters(ref) // passed by reference. READ AND WRITE ALL REF PARAMS
        static void Swap(ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }

        /**
         * A method that takes a reference to a variable intends to write to the variable, 
         * but not to read from it. In such cases, clearly it could be safe to pass an uninitialized local variable by reference. 
         * To achieve this, code needs to decorate parameter types with the keyword out.
         * */

        static bool TryGetButton(char character, out char button) {
            button = '1';   // write to the variable (param)

            return false;
        }

        /**
         * you can pass lots of param here
         * */
        static void DoStuff(int i, params int[] listInteger) { /*statement*/ }

        /**
         * optional method
         * */
        static void Method(int a, int b = 5) { /*statement*/ }

        /**
         * Named arguments
         *  // very convenience
         * */
        static void DisplayGreeting(string firstName, string middleName = default(string), string lastName = default(string))
        {
            /*statement*/
            System.Console.WriteLine(firstName);
        }

        static void Me(int a, int b = default(int)) { }

        void Control()
        {
            this.name = "Man in the middle";
            this.feature = 123;
        }


        static void StoreFile()
        {
            FileStream fs = new FileStream("", FileMode.Create);        // FileMode: Append, Create, CreateNew, Open, OpenOrCreate, Truncate
            StreamWriter sw = new StreamWriter(fs);

            StreamReader sr = new StreamReader(fs);

            sw.WriteLine("Man in the middle");

            sw.Close();         // just like Java
        }

        public void tryNewGetSet()
        {
            this.firstName = "Lee";                        // call the firstName's setter, although origin prop is _firstName
            System.Console.WriteLine(this.firstName);      // call the firstName's getter, ----------------------------------
                                                           // to see more information: point cusor to the firstName
        } 
    }
}
