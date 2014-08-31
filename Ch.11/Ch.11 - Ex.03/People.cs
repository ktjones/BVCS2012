using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch._11___Ex._03
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
    

        //Other Methods
        public Person[] GetOldest()
        {

            Person oldestPerson = null;
            People oldestPeople = new People();
            Person currentPerson;

            foreach (DictionaryEntry p in Dictionary)
            {

                currentPerson = p.Value as Person;

                if (oldestPerson == null)
                {
                    oldestPerson = currentPerson;
                    oldestPeople.add(oldestPerson);
                }
                else
                {
                    if (currentPerson > oldestPerson)
                    {
                        oldestPeople.Clear();
                        oldestPeople.add(currentPerson);
                        oldestPerson = currentPerson;
                    }
                    else
                    {
                        if (currentPerson >= oldestPerson)
                        {
                            oldestPeople.add(currentPerson);
                        }
                    }
                }


            }

            Person[] oldestPeopleArray = new Person[oldestPeople.Count];
            int copyIndex = 0;

            foreach (DictionaryEntry p in oldestPeople)
            {
                oldestPeopleArray[copyIndex] = p.Value as Person;
                copyIndex++;
            }
            
            return oldestPeopleArray;
        }

    }
}
