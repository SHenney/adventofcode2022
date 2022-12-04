using adventofcode2022.input;

namespace adventofcode2022.day_3
{
    public class D3_Rucksack
    {
        private string inputFilename = "day_3.txt";
        private PuzzleInput reader;

        public D3_Rucksack() {
            reader = new PuzzleInput(inputFilename);
        }
        public static void SolvePuzzle()
        {
            var puzzle = new D3_Rucksack();
            var answer1 = puzzle.SolvePart1();
            Console.WriteLine($"What is the sum of the priorities of those item types? {answer1}");

            var answer2 = puzzle.SolvePart2();
            Console.WriteLine($"What is the sum of the priorities of those item types? {answer2}");
        }

        public int SolvePart1()
        {
            var rucksacks = reader.GetLinesAs<Rucksack>();

            var prioritySum = SumOfPrioritiesByCompartmentItems(rucksacks);
            return prioritySum;
        }

        public int SolvePart2()
        {
            var rucksacks = reader.GetLinesAs<Rucksack>();

            var badgePrioritySum = SumOfBadgePriorities(rucksacks);
            return badgePrioritySum;
        }

        public int SumOfPrioritiesByCompartmentItems(List<Rucksack> rucksacks)
        {
            int totalPriorities = rucksacks
                .Select(r => r.FindCommonItemsInCompartments().FirstOrDefault())
                .Sum(i => ItemPriority(i));
            return totalPriorities;
        }

        public int SumOfBadgePriorities(List<Rucksack> rucksacks)
        {
            var totalPriorities = GetListOfBadges(rucksacks).Sum(b => ItemPriority(b));
            return totalPriorities;
        }

        public List<char> GetListOfBadges(List<Rucksack> rucksacks)
        {
            var badgeList = new List<char>();
            var totalPacks = rucksacks.Count();
            //Console.WriteLine($"Is the # rucksacks % by 3? {(totalPacks % 3) == 0}"); //Quick & dirty sanity check
            for (var i = 0; i + 2 <= totalPacks; i += 3) // Don't go out of bounds!
            {
                List<char> firstPacksShare = rucksacks[i].FindCommonItemsInDifferentPack(rucksacks[i + 1]);
                List<char> lastPacksShare = rucksacks[i + 1].FindCommonItemsInDifferentPack(rucksacks[i + 2]);
                char badge = firstPacksShare.Intersect(lastPacksShare).FirstOrDefault();
                badgeList.Add(badge);
            }
            return badgeList;
        }

        public int ItemPriority(char item)
        {
            var ch = item;
            if (ch >= 65 && ch < 97)
            {
                return ch - 38;
            }
            if (ch >= 97 && ch <= 122)
            {
                return ch - 96;
            }

            return 0;
        }
    }
}
