using adventofcode2022.day_9;

namespace adventofcode2022tests
{
    public class D9_tests
    {
        static object[] moveHeadAndTailScenario =
       {
            new object[] { new string[] { "U 2", "L 1", "D 1", "R 2"}, 1, 1, 0, 1},
            new object[] { new string[] { "U 1", "R 2"}, 2, 1, 1, 1 },
            new object[] { new string[] { "U 1", "R 1", "U 1"}, 1, 2, 1, 1 },
            new object[] { new string[] { "U 1", "R 1", "L 1"}, 0, 1, 0, 0 },
            new object[] { new string[] { "U 1", "R 1", "D 1"}, 1, 0, 0, 0 },
            new object[] { new string[] { "R 14"} , 14, 0, 13, 0},
            new object[] { new string[] { "R 4"} , 4, 0, 3, 0},
            new object[] { new string[] { "R 4", "U 4"}, 4,4,4,3},
            new object[] { new string[] { "R 4", "U 4", "L 3",}, 1, 4, 2, 4},
            new object[] { new string[] { "R 4", "U 4", "L 3", "D 1", } , 1, 3, 2, 4},
            new object[] { new string[] { "R 4", "U 4", "L 3", "D 1", "R 4"} , 5, 3, 4, 3},
            new object[] { new string[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1" } , 5, 2, 4, 3},
            new object[] { new string[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5"} , 0, 2, 1, 2},
            new object[] { new string[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5", "R 2" } , 2, 2, 1, 2}
        };
        [TestCaseSource(nameof(moveHeadAndTailScenario))]
        public void Test_MakeAMove_TailLocation(string[] input, int headX, int headY, int tailX, int tailY)
        {
            Knots knots = new Knots();
            knots.MakeAMove(input);

            var head = knots.Rope.First();
            var tail = knots.Rope.Last();
            Assert.That(head[0], Is.EqualTo(headX));
            Assert.That(head[1], Is.EqualTo(headY));
            Assert.That(tail[0], Is.EqualTo(tailX));
            Assert.That(tail[1], Is.EqualTo(tailY));
        }

        static object[] moveBodyScenario =
        {
            new object[] { 2, 0, 1, 0 },
            new object[] { -2, 0, -1, 0 },
            new object[] { 0, 2, 0, 1},
            new object[] { 0, -2, 0, -1},
            new object[] { 2, 2, 1, 1 },
            new object[] { 2, -2, 1, -1 },
            new object[] { -2, -2, -1, -1 },
            new object[] { -2, 2, -1, 1 },
            //Diagonal moves
            new object[] { -2, 1, -1, 1}, //Move diagonal
            new object[] { 2, 1, 1, 1}, //Move diagonal
            new object[] { -2, -1, -1, -1}, //Move diagonal
            new object[] { 2, -1, 1, -1}, //Move diagonal
            new object[] { -1, 2, -1, 1},
            new object[] { -1, -2, -1, -1},
            new object[] { 1, 2, 1, 1},
            new object[] { 1, -2, 1, -1},
        };
        [TestCaseSource(nameof(moveBodyScenario))]
        public void Test_MoveBody(int headX, int headY, int tailX, int tailY)
        {
            Knots knots = new Knots();
            var head = knots.Rope.First();
            head[0] = headX;
            head[1] = headY;
            knots.MoveBody();

            var tail = knots.Rope.Last();
            Assert.That(tail[0], Is.EqualTo(tailX));
            Assert.That(tail[1], Is.EqualTo(tailY));
        }

        static object[] uniqueTailSpaces =
       {
            new object[] { new string[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5", "R 2" }, 2, 13, 25},
            new object[] { new string[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5", "R 2" }, 10, 1, 25},
            new object[] { new string[] { "R 5", "U 8", "L 8", "D 3", "R 17", "D 10", "L 25", "U 20" }, 10, 36, 97 }
        };
        [TestCaseSource(nameof(uniqueTailSpaces))]
        public void Test_HowManyTailLocs(string[] input, int ropeLength, int expectedTailLocCount, int expectedTailStored)
        {
            Knots knots = new Knots(ropeLength);
            knots.MakeAMove(input);

            int tailLocCount = knots.TailPath.Distinct().Count();
            Assert.That(tailLocCount, Is.EqualTo(expectedTailLocCount));
            Assert.That(knots.TailPath.Count(), Is.EqualTo(expectedTailStored));
        }
    }
}
