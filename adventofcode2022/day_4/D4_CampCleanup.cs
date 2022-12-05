using adventofcode2022.input;

namespace adventofcode2022.day_4
{
    public class D4_CampCleanup
    {
        private string inputFilename = "day_4.txt";
        private PuzzleInput reader;

        public D4_CampCleanup()
        {
            reader = new PuzzleInput(inputFilename);
        }

        public static void SolvePuzzle()
        {
            var puzzle = new D4_CampCleanup();
            var answer1 = puzzle.SolvePart1();
            Console.WriteLine($"In how many assignment pairs does one range fully contain the other? {answer1}");

            var answer2 = puzzle.SolvePart2();
            Console.WriteLine($"In how many assignment pairs do the ranges overlap? {answer2}");
        }

        public int SolvePart1()
        {
            var cleanupAssignments = reader.GetLinesAs<CleanupAssignments>();

            return SumOfFullyOverlappingAssignments(cleanupAssignments);
        }

        public int SolvePart2()
        {
            var cleanupAssignments = reader.GetLinesAs<CleanupAssignments>();

            return SumOfAnyOverlappingAssignments(cleanupAssignments);
        }

        public int SumOfFullyOverlappingAssignments(List<CleanupAssignments> cleanupAssignments)
        {
            return cleanupAssignments.Count(a => a.DoesOneAssignmentCompletelyOverlapOther());
        }

        public int SumOfAnyOverlappingAssignments(List<CleanupAssignments> cleanupAssignments)
        {
            return cleanupAssignments.Count(a => a.IsThereAnyAssignmentOverlap());
        }
    }
}
