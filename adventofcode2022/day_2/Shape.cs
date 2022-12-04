namespace adventofcode2022.day_2
{
    public interface IShape : IComparable<IShape>
    {
        int Points { get; }
    }

    public class Rock : IShape

    {
        public int Points => 1;

        /// <summary>
        /// 1 = win
        /// 0 = tie
        /// -1 = lose
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(IShape? other)
        {
            if (other?.GetType() == typeof(Scissors)) return 1;
            if (other?.GetType() == typeof(Rock)) return 0;
            return -1; //Default loses
        }
    }
    public class Paper : IShape
    {
        public int Points => 2;


        /// <summary>
        /// 1 = win
        /// 0 = tie
        /// -1 = lose
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(IShape? other)
        {
            if (other?.GetType() == typeof(Rock)) return 1;
            if (other?.GetType() == typeof(Paper)) return 0;
            return -1; //Default loses
        }
    }
    public class Scissors : IShape
    {
        public int Points => 3;
        /// <summary>
        /// 1 = win
        /// 0 = tie
        /// -1 = lose
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(IShape? other)
        {
            if (other?.GetType() == typeof(Paper)) return 1;
            if (other?.GetType() == typeof(Scissors)) return 0;
            return -1; //Default loses
        }
    }
}
