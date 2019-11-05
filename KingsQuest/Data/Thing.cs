namespace Data
{
    public abstract class Thing
    {
        public string Name { get; private set; }
        
        public string EmojiRepresentation { get; private set; }

        protected Thing(string name, string emojiRepresentation)
        {
            Name = name;
            EmojiRepresentation = emojiRepresentation;
        }
    }
}