using adventofcode2022.day_6;

namespace adventofcode2022tests
{
    public class D6_tests
    {
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", ExpectedResult = 5)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", ExpectedResult = 6)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", ExpectedResult = 10)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", ExpectedResult = 11)]
        public int Test_IndexAfterPacketMarker(string signal)
        {
            var interpreter = new Signal(signal);
            return interpreter.IndexAfterPacketMarker();
        }


        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", ExpectedResult = 19)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", ExpectedResult = 23)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", ExpectedResult = 23)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", ExpectedResult = 29)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", ExpectedResult = 26)]
        public int Test_IndexAfterMessageMarker(string signal)
        {
            var interpreter = new Signal(signal);
            return interpreter.IndexAfterMessageMarker();
        }

    }
}
