using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInheritance
{
    class Base
    {
        protected string name;
        protected int age;

        protected virtual string Address { get; set; }          // virtual get, set

        public virtual void doThing() { }

        public virtual void doStuff() { }

        public Base(int value) { }
    }

    class Child : Base          // single inheritance, syntax just like C++
    {
        private string title;

        protected override string Address                       // override get, set
        {
            get
            {
                return base.Address;
            }

            set
            {
                base.Address = value;
            }
        }

        public new void doThing() { }

        public sealed override void doStuff()           // sealed member: can not be overriden
        {
            base.doStuff();     // call base
        }

        public void Input()
        {
            Console.WriteLine("Your name: ");
            this.name = Console.ReadLine();

            Console.WriteLine("Your age: ");
            if(! int.TryParse(Console.ReadLine(), out this.age))
            {
                Console.WriteLine("Error");
                this.age = -1; // by default
            }

            Console.WriteLine("Your title: ");
            this.title = Console.ReadLine();
        }

        public Child(int value) : base(value)       // constructor, must be use 'base', just like 'super(...)' in Java
        {

        }
    }

    class SubChild : Child
    {
        // cannot override sealed member
        //public override void doStuff();

        public SubChild(int value) : base(value)
        {

        }
    }



    sealed class Command
    {
        //
    }

    // Sealed classes include the sealed modifier, and the result is that they cannot be derived from
    //sealed class DerivedCommand : Command
    //{

    //}

    public abstract class PdaItem
    {
        public PdaItem(string str)
        {
            Name = str;
        }

        public virtual string Name { get; set; }    // May be overriden
        public abstract void doWork();              // It will be overriden by devired class
    }


    public class Contact : PdaItem
    {
        public Contact(string str) : base(str)
        {
            if(str is string)  // 'is' operator to check type
            {
                // do thing :v
                object data = this as PdaItem;          // 'as' operator
            }
        }

        public override void doWork()       // must be overriden
        {
            
        }
    }

    interface IFace
    {
        void doFacing();        // public default
    }

    // The base class specifier (if there is one) must
    // come first, but otherwise order is not significant.Classes can implement
    // multiple interfaces, but may derive directly from only one base class
    class Face : IFace
    {
        public void doFacing()          // no need 'override' keyword
        {
            // love is on the air
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child(143);
            Base baser = child;

            child = (Child)baser; // must be cast
            
            
            
            
            
        }
    }
}
