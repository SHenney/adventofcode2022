using adventofcode2022.day_8;

namespace adventofcode2022tests
{
    public class D8_tests
    {
        static object[] inputScenario =
        {
            new object[] { new string[] { "30373", "25512", "65332", "33549", "35390" }
            }
        };
        [TestCaseSource(nameof(inputScenario))]
        public void Test_SurveyForest(string[] input)
        {
            var puzzleSolver = new QuadcopterMap();
            var treeList = puzzleSolver.SurveyForest(input);

            Assert.That(treeList.Count, Is.EqualTo(25));
            var firstTree = treeList[0];
            Assert.That(firstTree.height, Is.EqualTo(3));
            Assert.IsNull(firstTree.North);
            Assert.IsNull(firstTree.West);
            Assert.That(firstTree.East.height, Is.EqualTo(0));
            Assert.That(firstTree.South.height, Is.EqualTo(2));

            var middleTree = treeList[12];
            Assert.That(middleTree.height, Is.EqualTo(3));
            Assert.That(middleTree.North.height, Is.EqualTo(5));
            Assert.That(middleTree.West.height, Is.EqualTo(5));
            Assert.That(middleTree.East.height, Is.EqualTo(3));
            Assert.That(middleTree.South.height, Is.EqualTo(5));

            var rightTree = treeList[19];
            Assert.That(rightTree.height, Is.EqualTo(9));
            Assert.That(rightTree.North.height, Is.EqualTo(2));
            Assert.That(rightTree.West.height, Is.EqualTo(4));
            Assert.IsNull(rightTree.East);
            Assert.That(rightTree.South.height, Is.EqualTo(0));

            var bottomTree = treeList[20];
            Assert.That(bottomTree.height, Is.EqualTo(3));
            Assert.That(bottomTree.North.height, Is.EqualTo(3));
            Assert.IsNull(bottomTree.West);
            Assert.That(bottomTree.East.height, Is.EqualTo(5));
            Assert.IsNull(bottomTree.South);
        }

        [TestCaseSource(nameof(inputScenario))]
        public void Test_MarkVisibleTrees(string[] input)
        {
            var puzzleSolver = new QuadcopterMap();
            var treeList = puzzleSolver.SurveyForest(input);
            puzzleSolver.MarkVisibleTrees(treeList);

            //Top row
            Assert.True(treeList[0].isVisible);
            Assert.True(treeList[1].isVisible);
            Assert.True(treeList[2].isVisible);
            Assert.True(treeList[3].isVisible);
            Assert.True(treeList[4].isVisible);

            //Middle row
            Assert.True(treeList[5].isVisible);
            Assert.True(treeList[6].isVisible);
            Assert.True(treeList[7].isVisible);
            Assert.False(treeList[8].isVisible);
            Assert.True(treeList[9].isVisible);

            //Middle row
            Assert.True(treeList[10].isVisible);
            Assert.True(treeList[11].isVisible);
            Assert.False(treeList[12].isVisible);
            Assert.True(treeList[13].isVisible);
            Assert.True(treeList[14].isVisible);

            //Middle row
            Assert.True(treeList[15].isVisible);
            Assert.False(treeList[16].isVisible);
            Assert.True(treeList[17].isVisible);
            Assert.False(treeList[18].isVisible);
            Assert.True(treeList[19].isVisible);

            //Bottom row
            Assert.True(treeList[20].isVisible);
            Assert.True(treeList[21].isVisible);
            Assert.True(treeList[22].isVisible);
            Assert.True(treeList[23].isVisible);
            Assert.True(treeList[24].isVisible);
        }

        [TestCaseSource(nameof(inputScenario))]
        public void Test_CountVisibleTrees(string[] input)
        {
            var puzzleSolver = new QuadcopterMap();
            var treeList = puzzleSolver.SurveyForest(input);
            puzzleSolver.MarkVisibleTrees(treeList);
            int numVisibleTrees = puzzleSolver.CountVisibleTrees(treeList);

            Assert.That(numVisibleTrees, Is.EqualTo(21));
        }

        [TestCaseSource(nameof(inputScenario))]
        public void Test_MarkViewDistance(string[] input)
        {
            var puzzleSolver = new QuadcopterMap();
            var treeList = puzzleSolver.SurveyForest(input);
            puzzleSolver.MarkViewDistance(treeList);

            //Top row
            Assert.That(treeList[0].scenicScore, Is.EqualTo(0));
            Assert.That(treeList[1].scenicScore, Is.EqualTo(0));
            Assert.That(treeList[2].scenicScore, Is.EqualTo(0));
            Assert.That(treeList[3].scenicScore, Is.EqualTo(0));
            Assert.That(treeList[4].scenicScore, Is.EqualTo(0));

            //Middle row
            Assert.That(treeList[5].scenicScore, Is.EqualTo(0));
            Assert.That(treeList[6].scenicScore, Is.EqualTo(1));
            Assert.That(treeList[7].scenicScore, Is.EqualTo(4));
            Assert.That(treeList[8].scenicScore, Is.EqualTo(1));
            Assert.That(treeList[9].scenicScore, Is.EqualTo(0));

            //Middle row
            Assert.That(treeList[10].scenicScore, Is.EqualTo(0));
            Assert.That(treeList[11].scenicScore, Is.EqualTo(6));
            Assert.That(treeList[12].scenicScore, Is.EqualTo(1));
            Assert.That(treeList[13].scenicScore, Is.EqualTo(2));
            Assert.That(treeList[14].scenicScore, Is.EqualTo(0));

            //Middle row
            Assert.That(treeList[15].scenicScore, Is.EqualTo(0));
            Assert.That(treeList[16].scenicScore, Is.EqualTo(1));
            Assert.That(treeList[17].scenicScore, Is.EqualTo(8));
            Assert.That(treeList[18].scenicScore, Is.EqualTo(3));
            Assert.That(treeList[19].scenicScore, Is.EqualTo(0));

            //Bottom row
            Assert.That(treeList[20].scenicScore, Is.EqualTo(0));
            Assert.That(treeList[21].scenicScore, Is.EqualTo(0));
            Assert.That(treeList[22].scenicScore, Is.EqualTo(0));
            Assert.That(treeList[23].scenicScore, Is.EqualTo(0));
            Assert.That(treeList[24].scenicScore, Is.EqualTo(0));
        }

        [TestCaseSource(nameof(inputScenario))]
        public void Test_BestScenicScore(string[] input)
        {
            var puzzleSolver = new QuadcopterMap();
            var treeList = puzzleSolver.SurveyForest(input);
            puzzleSolver.MarkViewDistance(treeList);
            int bestScenicScore = puzzleSolver.BestScenicScore(treeList);

            Assert.That(bestScenicScore, Is.EqualTo(8));
        }
    }
}
