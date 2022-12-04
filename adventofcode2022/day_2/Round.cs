namespace adventofcode2022.day_2
{
    public class Round
    {
        public IShape? TheyPlay { get; set; }
        public IShape? IPlay { get; set; }

        public int Outcome { get; set; } // -1 = lose, 0 = draw, 1 = win
        public int PointsEarned { get; set; }
    }
}
