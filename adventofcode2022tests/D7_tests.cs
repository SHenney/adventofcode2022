using adventofcode2022.day_7;

namespace adventofcode2022tests
{
    public class D7_tests
    {
        static object[] inputScenario =
        {
            new object[] { new string[] { "$ cd /", "$ ls", "dir a", "14848514 b.txt", "8504156 c.dat", "dir d", "$ cd a", "$ ls", "dir e", "29116 f", "2557 g", "62596 h.lst", "$ cd e", "$ ls", "584 i", "$ cd ..", "$ cd ..", "$ cd d", "$ ls", "4060174 j", "8033020 d.log", "5626152 d.ext", "7214296 k", "dir e" }
            }
        };
        [TestCaseSource(nameof(inputScenario))]
        public void Test_BuildFileTree_directories(string[] input)
        {
            FileSystem puzzleSolver = new FileSystem();
            puzzleSolver.BuildFileTree(input);
            var root = puzzleSolver.Root;

            Assert.That(root.Name, Is.EqualTo("/"));
            Assert.True(root.Children.ContainsKey("a"));
            Assert.True(root.Children.ContainsKey("d"));

            adventofcode2022.day_7.Directory dirA = root.Children.GetValueOrDefault("a");
            Assert.True(dirA.Children.ContainsKey("e"));
            
            adventofcode2022.day_7.Directory dirD = root.Children.GetValueOrDefault("d");
            Assert.True(dirD.Children.ContainsKey("e"));
        }

        [TestCaseSource(nameof(inputScenario))]
        public void Test_FileSizeLocalAndSubfolders(string[] input)
        {
            FileSystem puzzleSolver = new FileSystem();
            puzzleSolver.BuildFileTree(input);
            var root = puzzleSolver.Root;

            Assert.That(root.FileSizeLocalAndSubfolders(), Is.EqualTo(48381165));

            var dirA = root.Children.GetValueOrDefault("a");
            Assert.That(dirA.FileSizeLocalAndSubfolders(), Is.EqualTo(94853));

            var dirE = dirA.Children.GetValueOrDefault("e");
            Assert.That(dirE.FileSizeLocalAndSubfolders(), Is.EqualTo(584));

            var dirD = root.Children.GetValueOrDefault("d");
            Assert.That(dirD.FileSizeLocalAndSubfolders(), Is.EqualTo(24933642));

            var dirDE = dirD.Children.GetValueOrDefault("e");
            Assert.That(dirDE.FileSizeLocalAndSubfolders(), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(inputScenario))]
        public void Test_SumSizeOfDirsUnder100k(string[] input)
        {
            FileSystem puzzleSolver = new FileSystem();
            puzzleSolver.BuildFileTree(input);
            var sum = puzzleSolver.SumSizeOfDirsUnder100k();

            Assert.That(sum, Is.EqualTo(95437));
        }

        [TestCaseSource(nameof(inputScenario))]
        public void Test_SizeOfSmallestDirToDelete(string[] input)
        {
            FileSystem puzzleSolver = new FileSystem();
            puzzleSolver.BuildFileTree(input);
            var candidate = puzzleSolver.SizeOfSmallestDirToDelete();

            Assert.That(candidate, Is.EqualTo(24933642));
        }
    }
}
