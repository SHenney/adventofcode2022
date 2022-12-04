namespace adventofcode2022.day_1
{
    public class Elf
    {
        private List<int> PackOfCalories { get; set; } = new List<int>();
        //TODO elf id?

        public void AddCaloriesToPack(int item)
        {
            PackOfCalories.Add(item);
        }

        public int CaloriesInPack()
        {
            return PackOfCalories.Sum();
        }
    }
}
