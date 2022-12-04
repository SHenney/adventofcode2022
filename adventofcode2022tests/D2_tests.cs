using adventofcode2022.day_2;

namespace adventofcode2022tests
{
    internal class D2_tests
    {
        [Test]
        public void Test_ComparisonsWork()
        {
            var aRock = new Rock();
            var aPaper = new Paper();
            var aScissors = new Scissors();
            Assert.That(aPaper.CompareTo(aRock), Is.EqualTo(1));
            Assert.That(aPaper.CompareTo(aScissors), Is.EqualTo(-1));
            Assert.That(aPaper.CompareTo(aPaper), Is.EqualTo(0));
            Assert.That(aRock.CompareTo(aRock), Is.EqualTo(0));
            Assert.That(aRock.CompareTo(aScissors), Is.EqualTo(1));
            Assert.That(aRock.CompareTo(aPaper), Is.EqualTo(-1));
            Assert.That(aScissors.CompareTo(aRock), Is.EqualTo(-1));
            Assert.That(aScissors.CompareTo(aPaper), Is.EqualTo(1));
            Assert.That(aScissors.CompareTo(aScissors), Is.EqualTo(0));
        }

        static object[] playRoundScenarios =
        {   //they, I, shape points, outcome points
            new object[] {new Rock(), new Rock(), 1, 3},
            new object[] {new Rock(), new Paper(), 2, 6},
            new object[] {new Rock(), new Scissors(), 3, 0},
            new object[] {new Paper(), new Paper(), 2, 3},
            new object[] {new Paper(), new Rock(), 1, 0},
            new object[] {new Paper(), new Scissors(), 3, 6},
            new object[] {new Scissors(), new Scissors(), 3, 3},
            new object[] {new Scissors(), new Rock(), 1, 6},
            new object[] {new Scissors(), new Paper(), 2, 0},
            new object[] {null, null, 0, 0},
        };

        [TestCaseSource(nameof(playRoundScenarios))]
        public void Test_PlayRound(IShape? theyPlay, IShape? iPlay, int shapePoints, int outcomePoints)
        {
            var problemSolver = new D2_RockPaperScissors();
            var pointsEarned = problemSolver.PlayRound(theyPlay, iPlay);

            var expectedPoints = shapePoints + outcomePoints;
            Assert.That(pointsEarned, Is.EqualTo(expectedPoints));
        }

        static object[] encodedRoundScenarios =
        {
            new object[] {new string[] {"A","X"}, new Rock(), new Rock() },
            new object[] {new string[] {"A","Y"}, new Rock(), new Paper() },
            new object[] {new string[] {"A","Z"}, new Rock(), new Scissors() },
            new object[] {new string[] {"B","X"}, new Paper(), new Rock() },
            new object[] {new string[] {"B","Y"}, new Paper(), new Paper() },
            new object[] {new string[] {"B","Z"}, new Paper(), new Scissors() },
            new object[] {new string[] {"C","X"}, new Scissors(), new Rock() },
            new object[] {new string[] {"C","Y"}, new Scissors(), new Paper() },
            new object[] {new string[] {"C","Z"}, new Scissors(), new Scissors() },
        };
        [TestCaseSource(nameof(encodedRoundScenarios))]
        public void Test_MakeRoundWithBothPlays(string[] encodedStrategy, IShape theyPlay, IShape iPlay)
        {
            var problemSolver = new D2_RockPaperScissors();
            var round = problemSolver.MakeRoundWithBothPlays(encodedStrategy);

            Assert.That(round, Is.TypeOf<Round>());
            Assert.That(round.TheyPlay.GetType, Is.EqualTo(theyPlay.GetType()));
            Assert.That(round.IPlay.GetType, Is.EqualTo(iPlay.GetType()));
        }

        static object[] encodedThemAndOutputRoundScenarios =
        {
            new object[] {new string[] {"A","X"}, new Rock(), new Scissors() },
            new object[] {new string[] {"A","Y"}, new Rock(), new Rock() },
            new object[] {new string[] {"A","Z"}, new Rock(), new Paper() },
            new object[] {new string[] {"B","X"}, new Paper(), new Rock() },
            new object[] {new string[] {"B","Y"}, new Paper(), new Paper() },
            new object[] {new string[] {"B","Z"}, new Paper(), new Scissors() },
            new object[] {new string[] {"C","X"}, new Scissors(), new Paper() },
            new object[] {new string[] {"C","Y"}, new Scissors(), new Scissors() },
            new object[] {new string[] {"C","Z"}, new Scissors(), new Rock() },
        };
        [TestCaseSource(nameof(encodedThemAndOutputRoundScenarios))]
        public void Test_MakeRoundFromThemAndOutput(string[] encodedStrategy, IShape theyPlay, IShape iPlay)
        {
            var problemSolver = new D2_RockPaperScissors();
            var round = problemSolver.MakeRoundFromThemAndOutput(encodedStrategy);

            Assert.That(round, Is.TypeOf<Round>());
            Assert.That(round.TheyPlay.GetType, Is.EqualTo(theyPlay.GetType()));
            Assert.That(round.IPlay.GetType, Is.EqualTo(iPlay.GetType()));
        }


        static object[] inputLineScenarios =
        {
            new object[] {new string[] {"A X"}, 1, 4, Strategy.BOTH_SHAPES},
            new object[] {new string[] {"A X", "B Y"}, 2, 9, Strategy.BOTH_SHAPES },
            new object[] {new string[] {"A X", "B Y", "C Z" }, 3, 15, Strategy.BOTH_SHAPES },
            new object[] {new string[] {"A Y", "B X", "C Z" }, 3, 15, Strategy.BOTH_SHAPES },
            new object[] {new string[] {"A X"}, 1, 3, Strategy.THEM_AND_OUTPUT},
            new object[] {new string[] {"A X", "B Y"}, 2, 8, Strategy.THEM_AND_OUTPUT },
            new object[] {new string[] {"A X", "B Y", "C Z" }, 3, 15, Strategy.THEM_AND_OUTPUT },
            new object[] {new string[] {"A Y", "B X", "C Z" }, 3, 12, Strategy.THEM_AND_OUTPUT },
        };

        [TestCaseSource(nameof(inputLineScenarios))]
        public void Test_MakeRoundsFromInput(string[] inputLine, int roundCount, int score, Strategy strat)
        {
            var problemSolver = new D2_RockPaperScissors();
            var roundList = problemSolver.MakeRoundsFromInput(inputLine, strat);

            Assert.That(roundList.Count, Is.EqualTo(roundCount));
            foreach (var round in roundList)
            {
                Assert.That(round.TheyPlay, Is.InstanceOf<IShape>());
                Assert.That(round.IPlay, Is.InstanceOf<IShape>());
            }
        }

        [TestCaseSource(nameof(inputLineScenarios))]
        public void Test_Play(string[] inputLine, int roundCount, int expectedScore, Strategy strat)
        {
            var problemSolver = new D2_RockPaperScissors();
            var score = problemSolver.Play(inputLine, strat);

            Assert.That(score, Is.EqualTo(expectedScore));
        }

        static object[] whatIPlayScenarios =
        {   //they, I, shape points, outcome points
            new object[] {new Rock(), 1, new Paper()},
            new object[] {new Rock(), 0, new Rock() },
            new object[] {new Rock(), -1, new Scissors()},
            new object[] {new Paper(), 0, new Paper()},
            new object[] {new Paper(), -1, new Rock()},
            new object[] {new Paper(), 1, new Scissors()},
            new object[] {new Scissors(), 0, new Scissors()},
            new object[] {new Scissors(), 1, new Rock()},
            new object[] {new Scissors(), -1, new Paper()},
        };
        [TestCaseSource(nameof(whatIPlayScenarios))]
        public void Test_WhatShouldIPlay(IShape? theyPlay, int outcome, IShape? iShouldPlay)
        {
            var problemSolver = new D2_RockPaperScissors();
            var playThis = problemSolver.WhatShouldIPlay(theyPlay, outcome);

            Assert.That(playThis?.GetType(), Is.EqualTo(iShouldPlay?.GetType()));
        }
    }
}
