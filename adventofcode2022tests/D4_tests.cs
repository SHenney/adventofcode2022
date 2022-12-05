using adventofcode2022.day_4;

namespace adventofcode2022tests
{
    public class D4_tests
    {

        [TestCase("2-4,6-8", ExpectedResult = false)]
        [TestCase("5-7,7-9", ExpectedResult = false)]
        [TestCase("2-8,3-7", ExpectedResult = true)]
        [TestCase("3-7,2-8", ExpectedResult = true)]
        [TestCase("2-8,3-8", ExpectedResult = true)]
        [TestCase("3-8,2-8", ExpectedResult = true)]
        [TestCase("3-8,3-8", ExpectedResult = true)]
        [TestCase("3-7,3-8", ExpectedResult = true)]
        [TestCase("3-8,3-7", ExpectedResult = true)]
        [TestCase("10-10,10-72", ExpectedResult = true)]
        public bool Test_DoesOneAssignmentCompletelyOverlapOther(string items)
        {
            var assignments = new CleanupAssignments(items);
            var assignmentsOverlap = assignments.DoesOneAssignmentCompletelyOverlapOther();
            return assignmentsOverlap;
        }

        [TestCase("2-4,6-8", ExpectedResult = false)]
        [TestCase("2-4,4-8", ExpectedResult = true)]
        [TestCase("2-4,3-8", ExpectedResult = true)]
        [TestCase("2-8,2-4", ExpectedResult = true)]
        [TestCase("2-2,2-2", ExpectedResult = true)]
        [TestCase("5-7,7-9", ExpectedResult = true)]
        [TestCase("2-8,3-7", ExpectedResult = true)]
        [TestCase("3-7,2-8", ExpectedResult = true)]
        [TestCase("2-8,3-8", ExpectedResult = true)]
        [TestCase("3-8,2-8", ExpectedResult = true)]
        [TestCase("3-8,3-8", ExpectedResult = true)]
        [TestCase("3-7,3-8", ExpectedResult = true)]
        [TestCase("3-8,3-7", ExpectedResult = true)]
        [TestCase("10-10,10-72", ExpectedResult = true)]
        public bool Test_IsThereAnyAssignmentOverlap(string items)
        {
            var assignments = new CleanupAssignments(items);
            var assignmentsOverlap = assignments.IsThereAnyAssignmentOverlap();
            return assignmentsOverlap;
        }

        static object[] overlapAssignmentScenarios =
        {
            new object[] { new List<CleanupAssignments>() { new CleanupAssignments("2-4,6-8"), new CleanupAssignments("2-4,6-8") }, 0 },
            new object[] { new List<CleanupAssignments>() { new CleanupAssignments("2-8,3-7"), new CleanupAssignments("2-4,6-8") }, 1 },
            new object[] { new List<CleanupAssignments>() { new CleanupAssignments("2-8,3-7"), new CleanupAssignments("3-7,3-8") }, 2 },
            new object[] { new List<CleanupAssignments>() { new CleanupAssignments("2-8,3-7"), new CleanupAssignments("2-8,3-7"), new CleanupAssignments("2-8,3-7"), new CleanupAssignments("3-7,3-8") }, 4 },
            new object[] { new List<CleanupAssignments>() { }, 0 },
            new object[] { new List<CleanupAssignments>() { new CleanupAssignments("10-10,10-72"), new CleanupAssignments("2-4,6-8") }, 1 },
        };
        [TestCaseSource(nameof(overlapAssignmentScenarios))]
        public void Test_SumOfFullyOverlappingAssignments(List<CleanupAssignments> assignments, int expectedOverlapSum)
        {
            var puzzleSolver = new D4_CampCleanup();
            var sum = puzzleSolver.SumOfFullyOverlappingAssignments(assignments);
            Assert.That(sum, Is.EqualTo(expectedOverlapSum));
        }
    }
}
