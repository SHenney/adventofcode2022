using adventofcode2022.day_3;
using adventofcode2022.input;

namespace adventofcode2022tests
{
    public class PuzzleInput_tests
    {
        //Not going to commit this with a file path and don't want an env dependency in unit tests
        public void Test_PuzzleInput_Day3()
        {
            var filePath = ""; //Just add the path to the day3 file input to use this test
            PuzzleInput input = new PuzzleInput();
            var puzzlesInPacks = input.GetLinesAs<Rucksack>(filePath);

            Assert.That(puzzlesInPacks, Is.Not.Empty);
            foreach (var pack in puzzlesInPacks)
            {
                Assert.That(pack, Is.TypeOf<Rucksack>());
                Assert.That(pack.Item, Is.TypeOf<string>());
                Assert.That(pack.Item, Is.Not.Empty);
            }
        }
    }
}
