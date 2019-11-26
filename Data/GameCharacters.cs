using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{

    public class King : Character
    {
        private int talkEvCounter = 0;
        private bool candyOver = false;

        public override Item Talk()
        {
            if (talkEvCounter < 2)
            {
                OnTalk("KingNothing");
                talkEvCounter++;
                return null;
            }
            else
            {
                if (candyOver)
                {
                    OnTalk("KingGiven");
                    return null;
                }
                else
                {
                    OnTalk("KingGiveItem");
                    candyOver = true;
                    OnNewItem(new Item() { Name = "Candy", Description = "Candy. What else." });
                }

            }

            return null;
        }
    }

    public class Dragon : Character
    {
        

        public override Item Talk()
        {
            OnTalk("Dragon");
            return null;
        }

        
    }
}
