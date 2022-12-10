using adventofcode2022.day_5;

namespace adventofcode2022tests
{
    public class D5_tests
    {
        static object[] inputScenario1 =
        {
            new object[] { new string[]{
                "[G]                 [D] [R]        ",
                "[W]         [V]     [C] [T] [M]    ",
                "[L]         [P] [Z] [Q] [F] [V]    ",
                "[J]         [S] [D] [J] [M] [T] [V]",
                "[B]     [M] [H] [L] [Z] [J] [B] [S]",
                "[R] [C] [T] [C] [T] [R] [D] [R] [D]",
                "[T] [W] [Z] [T] [P] [B] [B] [H] [P]",
                "[D] [S] [R] [D] [G] [F] [S] [L] [Q]",
                "1   2   3   4   5   6   7   8   9 ",
            "",
            "move 5 from 5 to 4"}},
        };
        [TestCaseSource(nameof(inputScenario1))]
        public void Test_Load(string[] input)
        {
            var cargoShip = new CargoCrane(input);
            cargoShip.LoadShip();

            var expectedStack1 = new char[] { 'D', 'T', 'R', 'B', 'J', 'L', 'W', 'G' };
            var expectedStack2 = new char[] { 'S', 'W', 'C' };
            var expectedStack9 = new char[] { 'Q', 'P', 'D', 'S', 'V' };

            Assert.That(cargoShip.Cargo.Count, Is.EqualTo(9));
            Assert.That(cargoShip.Cargo[0], Is.EquivalentTo(expectedStack1));
            Assert.That(cargoShip.Cargo[1], Is.EquivalentTo(expectedStack2));
            Assert.That(cargoShip.Cargo[8], Is.EquivalentTo(expectedStack9));
        }

        [TestCaseSource(nameof(inputScenario1))]
        public void Test_MoveCargoOneAtATime(string[] input)
        {
            var cargoShip = new CargoCrane(input);
            cargoShip.LoadShip();
            cargoShip.MoveCargoOneAtATime();

            var expectedStack4 = new char[] { 'D', 'T', 'C', 'H', 'S', 'P', 'V', 'Z', 'D', 'L', 'T', 'P' };
            var expectedStack5 = new char[] { 'G' };
            Assert.That(cargoShip.MoveInstructionsStartIndex, Is.EqualTo(10));
            Assert.That(cargoShip.Cargo[3], Is.EquivalentTo(expectedStack4));
            Assert.That(cargoShip.Cargo[4], Is.EquivalentTo(expectedStack5));
        }

        static object[] inputScenario2 =
        {
            new object[] { new string[]{
                "[G]                 [D] [R]        ",
                "[W]         [V]     [C] [T] [M]    ",
                "[L]         [P] [Z] [Q] [F] [V]    ",
                "[J]         [S] [D] [J] [M] [T] [V]",
                "[B]     [M] [H] [L] [Z] [J] [B] [S]",
                "[R] [C] [T] [C] [T] [R] [D] [R] [D]",
                "[T] [W] [Z] [T] [P] [B] [B] [H] [P]",
                "[D] [S] [R] [D] [G] [F] [S] [L] [Q]",
                "1   2   3   4   5   6   7   8   9 ",
            "",
            "move 5 from 5 to 4",
            "move 1 from 4 to 9"}},
        };
        [TestCaseSource(nameof(inputScenario2))]
        public void Test_MoveCargoOneAtATime2(string[] input)
        {
            var cargoShip = new CargoCrane(input);
            cargoShip.LoadShip();
            cargoShip.MoveCargoOneAtATime();

            var expectedStack4 = new char[] { 'D', 'T', 'C', 'H', 'S', 'P', 'V', 'Z', 'D', 'L', 'T' };
            var expectedStack5 = new char[] { 'G' };
            var expectedStack9 = new char[] { 'Q', 'P', 'D', 'S', 'V', 'P' };
            Assert.That(cargoShip.MoveInstructionsStartIndex, Is.EqualTo(10));
            Assert.That(cargoShip.Cargo[3], Is.EquivalentTo(expectedStack4));
            Assert.That(cargoShip.Cargo[4], Is.EquivalentTo(expectedStack5));
            Assert.That(cargoShip.Cargo[8], Is.EquivalentTo(expectedStack9));
        }

        static object[] inputScenario3 =
       {
            new object[] { new string[]{
                "    [D]    ",
                "[N] [C]    ",
                "[Z] [M] [P]",
                "1   2   3",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"
            }, new char[]{'C', 'M', 'Z'} },
             new object[] { new string[]{
                "    [D]    ",
                "[N] [C]    ",
                "[Z] [M] [P]",
                "1   2   3",
            "",
            "move 1 from 2 to 1",
            }, new char[]{'D', 'C', 'P'} },
             new object[] { new string[]{
                "    [D]    ",
                "[N] [C]    ",
                "[Z] [M] [P]",
                "1   2   3",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            }, new char[]{default, 'C', 'Z' } },
        };
        [TestCaseSource(nameof(inputScenario3))]
        public void Test_MoveCargoOneAtATime3(string[] input, char[] tops)
        {
            var cargoShip = new CargoCrane(input);
            cargoShip.LoadShip();
            cargoShip.MoveCargoOneAtATime();

            Assert.That(cargoShip.Cargo.Count, Is.EqualTo(3));
            Assert.That(cargoShip.MoveInstructionsStartIndex, Is.EqualTo(5));
            for(int i = 0; i < 3; i++)
            {
                char actualTop = default;
                if(cargoShip.Cargo[i].Count > 0)
                {
                    actualTop = cargoShip.Cargo[i].Last();
                }
                Assert.That(actualTop, Is.EqualTo(tops[i]));
            }
        }

        static object[] inputScenario4 =
      {
            new object[] { new string[]{
                "    [D]    ",
                "[N] [C]    ",
                "[Z] [M] [P]",
                "1   2   3",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"
            }, new char[]{'M', 'C', 'D'} },
             new object[] { new string[]{
                "    [D]    ",
                "[N] [C]    ",
                "[Z] [M] [P]",
                "1   2   3",
            "",
            "move 1 from 2 to 1",
            }, new char[]{'D', 'C', 'P'} },
             new object[] { new string[]{
                "    [D]    ",
                "[N] [C]    ",
                "[Z] [M] [P]",
                "1   2   3",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            }, new char[]{default, 'C', 'D' } },
        };
        [TestCaseSource(nameof(inputScenario4))]
        public void Test_MoveCargoInGroups(string[] input, char[] tops)
        {
            var cargoShip = new CargoCrane(input);
            cargoShip.LoadShip();
            cargoShip.MoveCargoInGroups();

            Assert.That(cargoShip.Cargo.Count, Is.EqualTo(3));
            Assert.That(cargoShip.MoveInstructionsStartIndex, Is.EqualTo(5));
            for (int i = 0; i < 3; i++)
            {
                char actualTop = default;
                if (cargoShip.Cargo[i].Count > 0)
                {
                    actualTop = cargoShip.Cargo[i].Last();
                }
                Assert.That(actualTop, Is.EqualTo(tops[i]));
            }
        }
    }
}
