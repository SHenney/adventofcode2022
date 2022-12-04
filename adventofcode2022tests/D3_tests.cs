using adventofcode2022.day_3;

namespace adventofcode2022tests
{
    public class D3_tests
    {
        [Test]
        public void Test_POC()
        {
            List<string> a = new() { "a", "A", "b" };
            List<string> b = new() { "c", "A", "W" };

            string? commonContent = a.Intersect(b).FirstOrDefault();
            Assert.That(commonContent, Is.EqualTo("A"));

            List<char> charlist = "abcDEF".ToCharArray().ToList();
        }

        [TestCase('a', ExpectedResult = 1)]
        [TestCase('b', ExpectedResult = 2)]
        [TestCase('z', ExpectedResult = 26)]
        [TestCase('A', ExpectedResult = 27)]
        [TestCase('Z', ExpectedResult = 52)]
        [TestCase('p', ExpectedResult = 16)]
        [TestCase('L', ExpectedResult = 38)]
        [TestCase('P', ExpectedResult = 42)]
        [TestCase('v', ExpectedResult = 22)]
        [TestCase('t', ExpectedResult = 20)]
        [TestCase('s', ExpectedResult = 19)]
        public int Test_ItemPriority(char item)
        {
            var problemSolver = new D3_Rucksack();
            return problemSolver.ItemPriority(item);
        }

        static object[] commonItemsScenarios =
        {
            new object[] {"aBcDae", new List<char> { 'a' }},
            new object[] {"aBcWBDae", new List<char> { 'a', 'B' }},
            new object[] {"aBcD", new List<char> { }},
        };
        [TestCaseSource(nameof(commonItemsScenarios))]
        public void Test_FindCommonItemsInCompartments(string items, List<char> expectedCommonItems)
        {
            var rucksack = new Rucksack(items);
            var commonItems = rucksack.FindCommonItemsInCompartments();

            Assert.That(commonItems, Is.EquivalentTo(expectedCommonItems));
        }

        static object[] rucksackPrioritiesScenarios =
        {
            new object[] { new List<Rucksack>() { new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp") }, 16},
            new object[] { new List<Rucksack>() { new Rucksack("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL") }, 38},
            new object[] { new List<Rucksack>() { new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp"), new Rucksack("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL") }, 54},
            new object[] { new List<Rucksack>() { new Rucksack("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"), new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp") }, 54},
            new object[] { new List<Rucksack>() {
                new Rucksack("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"),
                new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp"),
                new Rucksack("PmmdzqPrVvPwwTWBwg"),
                new Rucksack("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"),
                new Rucksack("ttgJtRGJQctTZtZT"),
                new Rucksack("CrZsJsPPZsGzwwsLwLmpwMDw"),
            }, 157},
            new object[] { new List<Rucksack>() { new Rucksack("abcd") }, 0}, //No common items
            new object[] { new List<Rucksack>() { }, 0}, //No items
        };

        [TestCaseSource(nameof(rucksackPrioritiesScenarios))]
        public void Test_SumOfPrioritiesByCompartmentItems(List<Rucksack> rucksacks, int expectedPriority)
        {
            var problemSolver = new D3_Rucksack();
            var priority = problemSolver.SumOfPrioritiesByCompartmentItems(rucksacks);

            Assert.That(priority, Is.EqualTo(expectedPriority));
        }

        static object[] commonItemsBetweenPacksScenarios =
        {
            new object[] { new Rucksack("abcd"), new Rucksack("defg"), new List<char> { 'd' }},
            new object[] { new Rucksack("abcdew"), new Rucksack("defg"), new List<char> { 'd', 'e' }},
            new object[] { new Rucksack(""), new Rucksack("defg"), new List<char> { }},
            new object[] { new Rucksack("wxyz"), new Rucksack("defg"), new List<char> { }},
        };
        [TestCaseSource(nameof(commonItemsBetweenPacksScenarios))]
        public void Test_FindCommonItemsInDifferentPack(Rucksack myPack, Rucksack otherPack, List<char> expectedCommonItems)
        {
            var commonItems = myPack.FindCommonItemsInDifferentPack(otherPack);

            Assert.That(commonItems, Is.EquivalentTo(expectedCommonItems));
        }


        static object[] rucksackBadgesScenarios =
        {
            new object[] { new List<Rucksack>() { new Rucksack("abc"), new Rucksack("cwq"), new Rucksack("bbc") }, new List<char> {'c'}, 3 },
            new object[] { new List<Rucksack>() { new Rucksack("abc"), new Rucksack("cwq"), new Rucksack("bbc"), new Rucksack("abc"), new Rucksack("cwq"), new Rucksack("bbc") }, new List<char> {'c', 'c'}, 6 },
            new object[] { new List<Rucksack>() { new Rucksack("abc"), new Rucksack("cwq"), new Rucksack("bbc"), new Rucksack("www"), new Rucksack("cwq"), new Rucksack("new") }, new List<char> {'c', 'w'}, 26 },
            new object[] { new List<Rucksack>() { }, new List<char> {}, 0 },
            new object[] { new List<Rucksack>() { new Rucksack("abb"), new Rucksack("cwq"), new Rucksack("bbc"), new Rucksack("www"), new Rucksack("cwq"), new Rucksack("new") }, new List<char> { default(char), 'w'}, 23},
        };

        [TestCaseSource(nameof(rucksackBadgesScenarios))]
        public void Test_GetListOfBadges(List<Rucksack> rucksacks, List<char> expectedBadges, int expectedPriority)
        {
            var problemSolver = new D3_Rucksack();
            var badgeList = problemSolver.GetListOfBadges(rucksacks);

            Assert.That(badgeList, Is.EquivalentTo(expectedBadges));
        }

        [TestCaseSource(nameof(rucksackBadgesScenarios))]
        public void Test_SumOfBadgePriorities(List<Rucksack> rucksacks, List<char> expectedBadges, int expectedPriority)
        {
            var problemSolver = new D3_Rucksack();
            var badgePriority = problemSolver.SumOfBadgePriorities(rucksacks);

            Assert.That(badgePriority, Is.EqualTo(expectedPriority));
        }
    }
}
