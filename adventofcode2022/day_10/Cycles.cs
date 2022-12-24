namespace adventofcode2022.day_10
{
    public class Cycles
    {
        public List<int> CalculateRegisterValues(string[] input)
        {
            List<int> xValues = new List<int> { 1 };

            foreach(string instruction in input)
            {
                if (instruction.Contains("noop"))
                {
                    xValues.Add(xValues.Last()); // Maintain same value
                }
                else
                {
                    int changeValue = int.Parse(instruction.Split(" ")[1]);
                    xValues.Add(xValues.Last()); //First cycle
                    xValues.Add(xValues.Last() + changeValue);
                }
            }
            return xValues;
        }

        public int SignalStrength(List<int> registerValues, int cycleNumber)
        {
            // Cycle is base 1
            return registerValues[cycleNumber - 1] * cycleNumber;
        }

        public void PaintScreen(List<int> registerValues)
        {
            for(int row = 0; row < 6; row++)
            {
                char[] lineText = new char[40];
                for (int cycle = 0; cycle <= 39; cycle++)
                {
                    int i = (row * 40) + cycle; //Index of register (base 0)
                    int x = registerValues[i]; //Pixel location
                    bool isVisible = x - 1 <= cycle && x + 1 >= cycle;
                    lineText[cycle] = isVisible ? '#' : '.';
                }
                Console.WriteLine(lineText);
            }
        }
    }
}
