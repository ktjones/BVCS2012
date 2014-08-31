using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch._11___Ex._02
{
    public class People : DictionaryBase
    {

        //add
        public void add(Person newPerson)
        {
        
            Dictionary.Add(newPerson.Name, newPerson);
        
        }



        //remove
        public void remove(string name)
        {

            Dictionary.Remove(name);
        
        }


        //constructors

        public Person this[string name]
        {
            get
            {
                return (Person)Dictionary[name];
            }
            set
            {
                Dictionary[name] = value;
            }
        }
    
    
    }
}
