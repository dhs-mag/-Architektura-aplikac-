using Data.Things.Contract;

namespace Data.Things
{
    public class Coin : Thing, IConsumable
    {
        public Coin(string name, string emojiRepresentation = "💰") : base(name, emojiRepresentation)
        {
        }

        public void Dispose()
        {
        }
    }
}