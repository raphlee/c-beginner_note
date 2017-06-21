using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stuff
{

    enum State
    {
        Idle, // 0      // first, default is 0, and increase after then. But you can assign explicit values to enums
        Attack, // 1
        Move = 5,
        Jump,  // 6 now
        Injured = 100
    }

    // Flags Attribute
    // If you decide to use bit flag enums, the declaration of the enum should be marked with FlagsAttribute

    // To join enum values, you use a bitwise OR operator. 
    // To test for the existence of a particular bit you use the bitwise AND operator
    [Flags]
    public enum FileAttributes
    {
        ReadOnly =      1 << 0,     // 0000 0000 0000 0001
        Hidden   =      1 << 1,     // 0000 0000 0000 0010

        Moreover = ReadOnly | Hidden        // Join Enum
    }

    // quite like class, but no inheritance and ...
    struct Angle {

        public int Degrees { get; } // can not be initialized
        public int Minutes { get; }
        public int Seconds { get; }

        public Angle(int degrees, int minutes, int seconds)
        {
            Degrees = degrees;
            Minutes = minutes;
            Seconds = seconds;
        }


        // XML Comments, sample
        /// <summary>
        /// Move the Angle out of here
        /// </summary>
        /// <remarks>
        /// This method use
        /// <seealso cref="System.Object"/>
        /// </remarks>
        /// <param name="degrees">Degrees of the world: origin</param>
        /// <param name="minutes">Minutes of the world: origin</param>
        /// <param name="seconds">Seconds of the world: origin</param>
        /// <returns>new Angle</returns>
        public Angle MoveOut(int degrees, int minutes, int seconds)
        {
            return new Angle(
                Degrees + degrees,
                Minutes + minutes,
                Seconds + seconds
                );
        }
        
    }

    class ValueTypes
    {
        /**
         *  70. DO NOT create value types that consume more than 16 bytes of memory.
            71. Reference types:
	        A reference type variable, therefore, has two storage locations associated with it: 
                - the storage location directly associated with the variable, 
                - and the storage location referred to by the reference that is the value stored in the variable.

	        This is why the guideline for value types is to ensure that they are never more than 16 bytes or thereabouts; 
            if a value type is more than four times as expensive to copy as a reference, 
            it probably should simply be a reference type.
         * 
         * */
        public Angle AxisX { get; set; }
        public Angle AxisY { get; set; }


        public void DoMoveOut()
        {
            Angle newMe = AxisX.MoveOut(0, 0, 0);
        }
    }


    class OverloadingOperator
    {
        //....

        int Vx;
        int Vy;

        public OverloadingOperator(int Vx, int Vy)
        {
            this.Vx = Vx;
            this.Vy = Vy;
        }

        // 2 operator == and != must be overridden togethers
        // Here, we've got warning: not override Equals(object o) and GetHashCode()
        public static bool operator == (OverloadingOperator o1, OverloadingOperator o2)
        {
            if(ReferenceEquals(o1, null))       // check o1 is null???
            {
                return ReferenceEquals(o2, null);
            }
            return ReferenceEquals(o1, o2);
        }

        public static bool operator != (OverloadingOperator o1, OverloadingOperator o2)
        {
            return !(o1 == o2);
        }


        public static OverloadingOperator operator + (OverloadingOperator o1, OverloadingOperator o2)
        {
            return new OverloadingOperator(o1.Vx + o2.Vx, o1.Vy + o2.Vy);
        }


        void boxingGirl()
        {
            int number = 43;
            object thing;

            // boxing
            thing = number;

            // unboxing
            number = (int)thing;
        }
}


    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder strBuilder = new StringBuilder("Man in the middle");

            
        }
    }
}
