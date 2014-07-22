using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChlOCardLib;

namespace Ch._10___Ex._05
{
    class Program
    {
        static void Main(string[] args)
        {

            int cardCount = 0;
            int cardMaxCount = 50;

            Deck myDeck = new Deck();
            myDeck.Shuffle();

            Card[] myCardArray = new Card[5];

            int flagcounter = 0;

            while (cardCount < cardMaxCount)
            {

                flagcounter = 0;

                for (int j = 0; j < 5; j++)
                {

                    myCardArray[j] = myDeck.GetCard(cardCount);

                    if (myCardArray[j].suit != myCardArray[0].suit)
                    {
                            
                        flagcounter += 1;

                    }
                        
                    cardCount += 1;

                }

            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(myCardArray[i].ToString());
            }

            if (flagcounter == 0)
            {

                Console.WriteLine("Flush!");

            }
            else
            {

                Console.WriteLine("No Flush!  Too Bad.");
                
            }


            Console.ReadKey();
     
        }
    }
}
