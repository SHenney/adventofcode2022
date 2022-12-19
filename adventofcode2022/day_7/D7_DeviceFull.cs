using adventofcode2022.input;

namespace adventofcode2022.day_7
{
    public class D7_DeviceFull
    {
        private string inputFilename = "day_7.txt";
        private PuzzleInput reader;

        public D7_DeviceFull()
        {
            reader = new PuzzleInput(inputFilename);
        }

        public static void SolvePuzzle()
        {
            var puzzle = new D7_DeviceFull();
            var answer1 = puzzle.SolvePart1();
            Console.WriteLine($"What is the sum of the total sizes of those directories? {answer1}");

            var answer2 = puzzle.SolvePart2();
            Console.WriteLine($"What is the total size of that directory? {answer2}");
        }

        public int SolvePart1()
        {
            var input = reader.GetLines();
            var fileSystem = new FileSystem();
            fileSystem.BuildFileTree(input);
            var totalSize = fileSystem.SumSizeOfDirsUnder100k();

            return totalSize;
        }

        public int SolvePart2()
        {
            var input = reader.GetLines();
            var fileSystem = new FileSystem();
            fileSystem.BuildFileTree(input);
            var sizeToDelete = fileSystem.SizeOfSmallestDirToDelete();

            return sizeToDelete;
        }
    }
}
