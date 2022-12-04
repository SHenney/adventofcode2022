using adventofcode2022.input;

namespace adventofcode2022.day_2
{
    public enum Strategy
    {
        BOTH_SHAPES,
        THEM_AND_OUTPUT
    }

    public class D2_RockPaperScissors
    {
        private string inputFilename = "day_2.txt";
        private PuzzleInput reader;

        public D2_RockPaperScissors()
        {
            reader = new PuzzleInput(inputFilename);
        }

        public int SolvePart1()
        {
            // Read the input
            string[] allLines = reader.GetLines();

            var finalScore = Play(allLines, Strategy.BOTH_SHAPES);

            return finalScore;
        }

        public int SolvePart2()
        {
            // Read the input
            string[] allLines = reader.GetLines();

            var finalScore = Play(allLines, Strategy.THEM_AND_OUTPUT);

            return finalScore;
        }


        public int Play(string[] inputLines, Strategy strat)
        {
            var allRounds = MakeRoundsFromInput(inputLines, strat);
            //Play each round and record the score
            foreach (var round in allRounds)
            {
                round.PointsEarned = PlayRound(round.TheyPlay, round.IPlay);
            }

            var finalScore = allRounds.Sum(r => r.PointsEarned);
            return finalScore;
        }

        public List<Round> MakeRoundsFromInput(string[] inputLines, Strategy strat)
        {
            var allRounds = new List<Round>();
            foreach (var line in inputLines)
            {
                var encodedStrategy = line.Split(' ');
                if (strat == Strategy.BOTH_SHAPES)
                {
                    var round = MakeRoundWithBothPlays(encodedStrategy);
                    allRounds.Add(round);
                }
                else if (strat == Strategy.THEM_AND_OUTPUT)
                {
                    var round = MakeRoundFromThemAndOutput(encodedStrategy);
                    allRounds.Add(round);
                }
            }

            return allRounds;
        }

        // Part 1
        public Round MakeRoundWithBothPlays(string[] encodedPlays)
        {
            var round = new Round();
            //Them
            if (string.Equals("A", encodedPlays[0]))
            {
                round.TheyPlay = new Rock();
            }
            else if (string.Equals("B", encodedPlays[0]))
            {
                round.TheyPlay = new Paper();
            }
            else if (string.Equals("C", encodedPlays[0]))
            {
                round.TheyPlay = new Scissors();
            }

            //Me
            if (string.Equals("X", encodedPlays[1]))
            {
                round.IPlay = new Rock();
            }
            else if (string.Equals("Y", encodedPlays[1]))
            {
                round.IPlay = new Paper();
            }
            else if (string.Equals("Z", encodedPlays[1]))
            {
                round.IPlay = new Scissors();
            }

            return round;
        }

        // Part 2
        public Round MakeRoundFromThemAndOutput(string[] encodedPlays)
        {
            var round = new Round();
            //Them
            if (string.Equals("A", encodedPlays[0]))
            {
                round.TheyPlay = new Rock();
            }
            else if (string.Equals("B", encodedPlays[0]))
            {
                round.TheyPlay = new Paper();
            }
            else if (string.Equals("C", encodedPlays[0]))
            {
                round.TheyPlay = new Scissors();
            }

            //Output
            if (string.Equals("X", encodedPlays[1]))
            {
                round.IPlay = WhatShouldIPlay(round.TheyPlay, -1);
            }
            else if (string.Equals("Y", encodedPlays[1]))
            {
                round.IPlay = WhatShouldIPlay(round.TheyPlay, 0);
            }
            else if (string.Equals("Z", encodedPlays[1]))
            {
                round.IPlay = WhatShouldIPlay(round.TheyPlay, 1);
            }

            return round;
        }


        /// <summary>
        /// Returns # points I earn
        /// </summary>
        /// <param name="theyPlay"></param>
        /// <param name="iPlay"></param>
        /// <returns></returns>
        public int PlayRound(IShape? theyPlay, IShape? iPlay)
        {
            var points = iPlay?.Points ?? 0;
            var outcome = iPlay?.CompareTo(theyPlay) ?? -1;
            if (outcome == 1)
            {
                points += 6;
            }
            else if (outcome == 0)
            {
                points += 3;
            }
            return points;
        }

        public IShape? WhatShouldIPlay(IShape? theyPlay, int outcome)
        {
            var rock = new Rock();
            if (rock.CompareTo(theyPlay) == outcome)
            {
                return rock;
            }
            var paper = new Paper();
            if (paper.CompareTo(theyPlay) == outcome)
            {
                return paper;
            }
            var scissors = new Scissors();
            if (scissors.CompareTo(theyPlay) == outcome)
            {
                return scissors;
            }
            return null;
        }
    }
}
