using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch._10___Ex._01
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
    
    
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
