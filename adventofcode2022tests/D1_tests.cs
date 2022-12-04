using adventofcode2022.day_1;

namespace adventofcode2022tests
{
    public class Day1Tests
    {
        static object[] topCalorieScenarios =
        {
            new object[] {new string[] {"100"}, 100 },
            new object[] {new string[] {"1000", "", "200"}, 1000 },
            new object[] {new string[] {"100", "", "2000"}, 2000 },
            new object[] {new string[] {"1000", "20", "", "200"}, 1020 },
            new object[] {new string[] {"1000", "20", "", "200", "900"}, 1100 },
            new object[] {new string[] {"100", "", "2000", "", "200", "", "900"}, 2000 },
            new object[] {new string[] {"100", "", "", "2000"}, 2000 },
            new object[] {new string[] {""}, 0 },
        };

        [TestCaseSource(nameof(topCalorieScenarios))]
        public void Test_FindHighestCaloriePack(string[] packInventory, int expectedResult)
        {
            D1_CalorieCount problemSolver = new D1_CalorieCount();
            int highestCalories = problemSolver.SumOfCaloriesInBestPacks(packInventory, 1);//problemSolver.FindHighestCaloriePack(packInventory);

            Assert.That(highestCalories, Is.EqualTo(expectedResult));
        }

        static object[] topSumScenarios =
        {
            new object[] {new string[] {"100"}, 1, 100 },
            new object[] {new string[] {"100"}, 2, 100 },
            new object[] {new string[] {"100", "200", "", "3"}, 2, 303 },
            new object[] {new string[] {"100", "200", "", "3"}, 1, 300 },
            new object[] {new string[] {"100", "200", "", "3", "", "1000", "", "2"}, 3, 1303 },
        };
        [TestCaseSource(nameof(topSumScenarios))]
        public void Test_FindTotalOfTopCaloriePacks(string[] packInventory, int sumX, int expectedResult)
        {
            D1_CalorieCount problemSolver = new D1_CalorieCount();
            int sumTopCalories = problemSolver.SumOfCaloriesInBestPacks(packInventory, sumX);

            Assert.That(sumTopCalories, Is.EqualTo(expectedResult));
        }


        static object[] elfCountAndCaloriesScenarios =
        {
            new object[] {new string[] {"100"}, 1, new int[] { 100 } },
            new object[] {new string[] {"100", "", "200"}, 2, new int[] { 100, 200 } },
            new object[] {new string[] {"100", "20", "", "200"}, 2, new int[] { 120, 200 } },
            new object[] {new string[] {"100", "20", "", "200", "50"}, 2, new int[] { 120, 250 } },
            new object[] {new string[] {"100", "", "200", "", "3"}, 3, new int[] { 100, 200, 3 } },
            new object[] {new string[] {""}, 0, new int[] { } },
            new object[] {new string[] {"", "", "200", "", "100", ""}, 2, new int[] { 200, 100 } },
        };

        [TestCaseSource(nameof(elfCountAndCaloriesScenarios))]
        public void Test_ParseElves_CountElves(string[] packInventory, int expectedElfCount, int[] totalCalories)
        {
            D1_CalorieCount problemSolver = new D1_CalorieCount();
            List<Elf> elfList = problemSolver.MakeElvesFromInput(packInventory);

            Assert.That(elfList.Count, Is.EqualTo(expectedElfCount));
        }

        [TestCaseSource(nameof(elfCountAndCaloriesScenarios))]
        public void Test_ParseElves_CountCalories(string[] packInventory, int expectedElfCount, int[] totalCalories)
        {
            D1_CalorieCount problemSolver = new D1_CalorieCount();
            List<Elf> elfList = problemSolver.MakeElvesFromInput(packInventory);

            var elfCount = elfList.Count;
            for (var i = 0; i < elfCount; i++)
            {
                Assert.That(elfList[i].CaloriesInPack, Is.EqualTo(totalCalories[i]));
            }
        }
    }
}