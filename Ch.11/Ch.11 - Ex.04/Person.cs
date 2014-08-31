using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch._11___Ex._04
{
    public class Person
    {
        //Private Members
        private string name;
        private int age;
        

        //Constructors
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        //Overloaded Operators
        public static bool operator >(Person person1, Person person2)
        {

            if (person1.age > person2.age)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool operator <(Person person1, Person person2)
        {

            if (person1.age < person2.age)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool operator <=(Person person1, Person person2)
        {

            if (person1.age <= person2.age)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool operator >=(Person person1, Person person2)
        {

            if (person1.age >= person2.age)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    
    
    }
}
