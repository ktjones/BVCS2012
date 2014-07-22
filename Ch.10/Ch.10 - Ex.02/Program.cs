using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch._10___Ex._02
{

    public class MyClass
    {

        protected string myString;

        public virtual string GetString()
        {

            return myString;

        }

        public string ContainedString
        {
            set
            {
                
                myString = value;

            }
        }
        

        public MyClass()
        {

            myString = "Test";

        }


    }


    public class MyDerivedClass : MyClass
    {

        public MyDerivedClass()
        {

        }

        public override string GetString()
        {

            return base.myString + "(output from derived class)";

        }
   
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
