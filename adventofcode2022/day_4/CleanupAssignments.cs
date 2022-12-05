using adventofcode2022.input;

namespace adventofcode2022.day_4
{
    public class CleanupAssignments : PuzzleItem
    {
        private int[] Elf1Assignment { get; set; }
        private int[] Elf2Assignment { get; set; }

        public CleanupAssignments(string item) : base(item)
        {
            var assignments = Item.Split(new char[] { '-', ',' });
            Elf1Assignment = new int[] { Convert.ToInt32(assignments[0]), Convert.ToInt32(assignments[1]) };
            Elf2Assignment = new int[] { Convert.ToInt32(assignments[2]), Convert.ToInt32(assignments[3]) };
        }

        public bool DoesOneAssignmentCompletelyOverlapOther()
        {
            //Assignment 1 overlaps
            if (Elf1Assignment[0] <= Elf2Assignment[0] && Elf1Assignment[1] >= Elf2Assignment[1])
            {
                return true;
            }
            //Assignment 2 overlaps
            else if (Elf2Assignment[0] <= Elf1Assignment[0] && Elf2Assignment[1] >= Elf1Assignment[1])
            {
                return true;
            }
            return false;
        }

        public bool IsThereAnyAssignmentOverlap()
        {
            //Assignment 1 overlaps
            if (Elf1Assignment[0] <= Elf2Assignment[0] && Elf1Assignment[1] >= Elf2Assignment[0])
            {
                return true;
            }
            //Assignment 2 overlaps
            else if (Elf2Assignment[0] <= Elf1Assignment[0] && Elf2Assignment[1] >= Elf1Assignment[0])
            {
                return true;
            }

            return false;
        }
    }
}
