using adventofcode2022.input;

namespace adventofcode2022.day_3
{
    public class Rucksack : PuzzleItem
    {
        public char[] ItemsAsList { get; set; }
        public Rucksack(string item) : base(item)
        {
            ItemsAsList = Item.ToCharArray();
        }

        public List<char> FindCommonItemsInCompartments()
        {
            var half = ItemsAsList.Length / 2;
            var compartmentA = ItemsAsList.Take(half).ToList();
            var compartmentB = ItemsAsList.Skip(half).Take(half).ToList();

            var commonItems = compartmentA.Intersect(compartmentB).ToList();
            return commonItems;
        }

        public List<char> FindCommonItemsInDifferentPack(Rucksack other)
        {
            var commonItems = ItemsAsList.Intersect(other.ItemsAsList).ToList();
            return commonItems;
        }
    }
}