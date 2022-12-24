using adventofcode2022.input;

namespace adventofcode2022.day_9
{
    public class D9_RopeBridge
    {
        private string inputFilename = "day_9.txt";
        private PuzzleInput reader;

        public D9_RopeBridge()
        {
            reader = new PuzzleInput(inputFilename);
        }

        public static void SolvePuzzle()
        {
            var puzzle = new D9_RopeBridge();
            var answer1 = puzzle.SolvePart1();
            Console.WriteLine($"How many positions does the tail of the rope visit at least once? {answer1}");

            var answer2 = puzzle.SolvePart2();
            Console.WriteLine($"How many positions does the tail of the rope visit at least once? {answer2}");
        }

        public int SolvePart1()
        {
            var input = reader.GetLines();
            Knots puzzleSolver = new Knots();
            puzzleSolver.MakeAMove( input );

            int tailLocCount = puzzleSolver.TailPath.Distinct().Count();
            return tailLocCount;
        }

        public int SolvePart2()
        {
            var input = reader.GetLines();
            Knots puzzleSolver = new Knots(10);
            puzzleSolver.MakeAMove(input);

            int tailLocCount = puzzleSolver.TailPath.Distinct().Count();
            return tailLocCount;
        }
    }
}
