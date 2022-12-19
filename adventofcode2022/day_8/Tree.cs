namespace adventofcode2022.day_8
{
    public class Tree
    {
        public int height = 0;
        public bool isVisible = false;
        public Tree? North { get; set; }
        public Tree? South { get; set; }
        public Tree? East { get; set; }
        public Tree? West { get; set; }

        public int northViewDistance = 0;
        public int southViewDistance = 0;
        public int eastViewDistance = 0;
        public int westViewDistance = 0;
        public int scenicScore { get { return northViewDistance * southViewDistance * eastViewDistance * westViewDistance; } }

        public Tree(int height)
        {
            this.height = height;
        }
    }
}
