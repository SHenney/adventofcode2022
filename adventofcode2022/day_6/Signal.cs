using adventofcode2022.input;

namespace adventofcode2022.day_6
{
    public class Signal : PuzzleItem
    {
        public Signal(string item) : base(item)
        {
        }

        public int IndexAfterPacketMarker()
        {
            for(int i = 0; i+3 < Item.Length; i++)
            {
                if (Item[i] == Item[i + 1] ||
                    Item[i] == Item[i + 2] ||
                    Item[i] == Item[i + 3] ||
                    Item[i + 1] == Item[i + 2] ||
                    Item[i + 1] == Item[i + 3] ||
                    Item[i + 2] == Item[i + 3])
                {
                    continue;
                }
                return i + 4; //+4 to end buffer
            }
            return -1; //Something broke
        }

        public int IndexAfterMessageMarker()
        {
            for (int i = 0; i + 14 < Item.Length; i++)
            {
                var distinct = Item.Substring(i, 14).Distinct();
                if (distinct.Count() == 14)
                {
                    return i + 14;
                };
            }

            return -1; //Something broke
        }
    }
}
