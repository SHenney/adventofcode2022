using adventofcode2022.input;

namespace adventofcode2022.day_10
{
    public class D10_CathodeRayTube
    {
        private string inputFilename = "day_10.txt";
        private PuzzleInput reader;

        public D10_CathodeRayTube()
        {
            reader = new PuzzleInput(inputFilename);
        }

        public static void SolvePuzzle()
        {
            var puzzle = new D10_CathodeRayTube();
            var answer1 = puzzle.SolvePart1();
            Console.WriteLine($"What is the sum of these six signal strengths? {answer1}");

            var answer2 = puzzle.SolvePart2();
            Console.WriteLine($"What eight capital letters appear on your CRT (above)?");
        }

        public int SolvePart1()
        {
            var input = reader.GetLines();
            Cycles puzzleSolver = new Cycles();
            var registerValues = puzzleSolver.CalculateRegisterValues(input);

            var sum = new int[] { 20, 60, 100, 140, 180, 220 }.Sum(cn => puzzleSolver.SignalStrength(registerValues, cn));
            return sum;
        }

        public int SolvePart2()
        {
            var input = reader.GetLines();
            Cycles puzzleSolver = new Cycles();
            var registerValues = puzzleSolver.CalculateRegisterValues(input);
            puzzleSolver.PaintScreen(registerValues);
            return 0;
        }
    }
}
