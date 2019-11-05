namespace Data
{
    public enum ItemType
    {
        WEAPON, POTION, MERCH
    }
    
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public ItemType type { get; set; }
    }
}