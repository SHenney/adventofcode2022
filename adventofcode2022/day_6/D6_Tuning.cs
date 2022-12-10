using adventofcode2022.input;

namespace adventofcode2022.day_6
{
    public class D6_Tuning
    {
        private string inputFilename = "day_6.txt";
        private PuzzleInput reader;

        public D6_Tuning()
        {
            reader = new PuzzleInput(inputFilename);
        }

        public static void SolvePuzzle()
        {
            var puzzle = new D6_Tuning();
            var answer1 = puzzle.SolvePart1();
            Console.WriteLine($"How many characters need to be processed before the first start-of-packet marker is detected? {answer1}");

            var answer2 = puzzle.SolvePart2();
            Console.WriteLine($"How many characters need to be processed before the first start-of-message marker is detected? {answer2}");
        }

        public int SolvePart1()
        {
            var input = reader.GetLinesAs<Signal>();
            return input[0].IndexAfterPacketMarker();
        }

        public int SolvePart2()
        {
            var input = reader.GetLinesAs<Signal>();
            return input[0].IndexAfterMessageMarker();
        }
    }
}
