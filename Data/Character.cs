using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class Character:GameObject
    {
        public abstract Item Talk();

        public event EventHandler<string> TalkEvent;
        public event EventHandler<Item> NewItemEvent;

        protected void OnTalk(string message)
        {
            if (TalkEvent != null)
            {
                TalkEvent(this, message);
            }
        }

        protected void OnNewItem(Item item)
        {

            if (NewItemEvent != null)
            {
                NewItemEvent(this, item);
            }
        }
    }
}
