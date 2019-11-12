using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class King : Character
    {
        private int TalkEvenCounter = 0;
        private bool CandyOver = false;

        public event EventHandler<string> OnDialogReply;
        public event EventHandler<Item> OnItemEmmit;

        public override void Talk()
        {
            if (TalkEvenCounter < 2)
            {
                OnDialogReply?.Invoke(this, "Nic nereknu!");
                TalkEvenCounter++;
                return;
            }

            if (CandyOver)
            {
                OnDialogReply?.Invoke(this, "Nic nereknu a bonbon uz jsi dostal!");
            }
            else
            {
                OnDialogReply?.Invoke(this, "Tu mas bonbonek!");
                OnItemEmmit?.Invoke(this, new Item() {Name = "Candy", Description = "Candy. What else."});
                CandyOver = true;
            }
        }
    }
}