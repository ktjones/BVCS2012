using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChlOCardLib
{
    public class Card
    {

        public readonly Suit suit;
        public readonly Rank rank;

        public Card (Suit newsuit, Rank newrank)
        {

            suit = newsuit;
            rank = newrank;

        }

        private Card()
        {
        }

        
        public override string ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }
    
    
    
    }
}
