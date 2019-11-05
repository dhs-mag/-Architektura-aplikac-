using System.Collections.Generic;

namespace Data
{
    public enum PersonType
    {
        FRIEND, FOE
    }
    public class Person
    {
        public string Name { get; set; }
        public string Story { get; set; }
        public int Stamina { get; set; }
        public List<Item> Items { get; set; }
        public PersonType nature { get; set; }
        public Person()
        {
            Items = new List<Item>();
            Stamina = 10;
        }
    }
}