using adventofcode2022.input;

namespace adventofcode2022.day_5
{
    public class D5_SupplyStacks
    {
        private string inputFilename = "day_5.txt";
        private PuzzleInput reader;

        public D5_SupplyStacks()
        {
            reader = new PuzzleInput(inputFilename);
        }

        public static void SolvePuzzle()
        {
            var puzzle = new D5_SupplyStacks();
            var answer1 = puzzle.SolvePart1();
            Console.WriteLine($"After the rearrangement procedure completes, what crate ends up on top of each stack? {answer1}");

            var answer2 = puzzle.SolvePart2();
            Console.WriteLine($"After the rearrangement procedure completes, what crate ends up on top of each stack? {answer2}");
        }

        public string SolvePart1()
        {
            var input = reader.GetLines();
            var cargoShip = new CargoCrane(input);
            cargoShip.LoadShip();
            cargoShip.MoveCargoOneAtATime();
            var tops = string.Concat(cargoShip.Cargo.Select(c => c.Last()));
            return tops;
        }

        public string SolvePart2()
        {
            var input = reader.GetLines();
            var cargoShip = new CargoCrane(input);
            cargoShip.LoadShip();
            cargoShip.MoveCargoInGroups();
            var tops = string.Concat(cargoShip.Cargo.Select(c => c.Last()));
            return tops;
        }

    }
}
