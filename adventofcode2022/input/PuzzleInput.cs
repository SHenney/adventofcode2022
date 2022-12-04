namespace adventofcode2022.input
{
    public class PuzzleInput
    {
        private string defaultFilePath = "";

        public PuzzleInput() { }

        /// <summary>
        /// Sets the default file path using the INPUT_DIR folder as the given file name's location
        /// </summary>
        /// <param name="fileName">A file in the /input directory</param>
        public PuzzleInput(string fileName)
        {
            var inputDir = Environment.GetEnvironmentVariable("INPUT_DIR") ?? "";
            defaultFilePath = Path.Combine(inputDir, fileName);
        }
        public string[] GetLines(string? filePath = null)
        {
            var path = filePath ?? defaultFilePath;
            string[] allLines = File.ReadAllLines(path);

            return allLines;
        }

        public List<T> GetLinesAs<T>(string? filePath = null) where T : PuzzleItem
        {
            var path = filePath ?? defaultFilePath;
            var allLines = GetLines(path);
            var puzzleItems = new List<T>();
            foreach (var line in allLines)
            {
                T entryObject = (T)Activator.CreateInstance(typeof(T), line);
                puzzleItems.Add(entryObject);
            }

            return puzzleItems;
        }
    }
}
