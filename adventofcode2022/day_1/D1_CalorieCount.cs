using adventofcode2022.input;

namespace adventofcode2022.day_1
{
    public class D1_CalorieCount
    {
        private string inputFilename = "day_1.txt";
        private PuzzleInput reader;

        public D1_CalorieCount()
        {
            reader = new PuzzleInput(inputFilename);
        }
        public int SolvePart1()
        {
            // Read the input
            string[] allLines = reader.GetLines();
            //List<Elf> elfList = MakeElvesFromInput(allLines); //TODO this would be better to do, but would need to modify unit tests >:(

            // Count the calories!
            int highestCalories = FindHighestCaloriePack(allLines);

            return highestCalories;
        }

        public int SolvePart1_v2()
        {
            // Read the input
            string[] allLines = reader.GetLines();

            // Count the calories!
            int sumHighestCalories = SumOfCaloriesInBestPacks(allLines, 1);

            return sumHighestCalories;
        }

        public int SolvePart2()
        {
            // Read the input
            string[] allLines = reader.GetLines();

            // Count the calories!
            int sumHighestCalories = SumOfCaloriesInBestPacks(allLines, 3);

            return sumHighestCalories;
        }

        public List<Elf> MakeElvesFromInput(string[] calorieCountLines)
        {
            List<Elf> elfList = new List<Elf>();
            Elf elf = new Elf();

            foreach (string line in calorieCountLines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    // Add calories to pack
                    int calorieInItem = 0;
                    if (int.TryParse(line, out calorieInItem))
                    {
                        elf.AddCaloriesToPack(calorieInItem);
                    }
                }
                else
                {
                    //Add the elf to the list only if it has things in it's pack
                    if (elf.CaloriesInPack() > 0)
                    {
                        elfList.Add(elf);

                        //Create another elf!
                        elf = new Elf();
                    }
                }
            }

            //Add the last elf to the list
            if (elf.CaloriesInPack() > 0)
            {
                elfList.Add(elf);
            }

            return elfList;
        }

        public int FindHighestCaloriePack(string[] calorieCountLines)
        {
            List<Elf> elfList = MakeElvesFromInput(calorieCountLines);
            if (elfList.Count > 0)
            {
                var mostCalories = elfList.Max(e => e.CaloriesInPack());
                return mostCalories;
            }

            return 0;
        }

        public int SumOfCaloriesInBestPacks(string[] calorieCountLines, int numPacksToCount)
        {
            List<Elf> elfList = MakeElvesFromInput(calorieCountLines);

            if (elfList.Count > 0)
            {
                var sumCalories = elfList.OrderByDescending(e => e.CaloriesInPack())
                    .Take(numPacksToCount)
                    .Sum(e => e.CaloriesInPack());
                return sumCalories;
            }

            return 0;
        }
    }
}
