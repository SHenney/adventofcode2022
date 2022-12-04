namespace adventofcode2022.input
{
    public abstract class PuzzleItem
    {
        public string Item { get; set; } = ""; // Keep this non-null

        public PuzzleItem(string item)
        {
            Item = item;
        }
    }
}
