using adventofcode2022.input;

namespace adventofcode2022.day_8
{
    public class D8_TreeHouse
    {
        private string inputFilename = "day_8.txt";
        private PuzzleInput reader;

        public D8_TreeHouse()
        {
            reader = new PuzzleInput(inputFilename);
        }

        public static void SolvePuzzle()
        {
            var puzzle = new D8_TreeHouse();
            var answer1 = puzzle.SolvePart1();
            Console.WriteLine($"how many trees are visible from outside the grid? {answer1}");

            var answer2 = puzzle.SolvePart2();
            Console.WriteLine($"What is the highest scenic score possible for any tree? {answer2}");
        }

        public int SolvePart1()
        {
            var input = reader.GetLines();
            var puzzleSolver = new QuadcopterMap();
            var treeList = puzzleSolver.SurveyForest(input);
            puzzleSolver.MarkVisibleTrees(treeList);
            int numVisibleTrees = puzzleSolver.CountVisibleTrees(treeList);
            return numVisibleTrees;
        }

        public int SolvePart2()
        {
            var input = reader.GetLines();
            var puzzleSolver = new QuadcopterMap();
            var treeList = puzzleSolver.SurveyForest(input);
            puzzleSolver.MarkViewDistance(treeList);
            int bestScenicScore = puzzleSolver.BestScenicScore(treeList);
            return bestScenicScore;
        }
    }
}
