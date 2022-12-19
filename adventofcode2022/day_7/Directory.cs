namespace adventofcode2022.day_7
{
    public class Directory
    {
        public string Name { get; set; }
        public Directory? Parent { get; set; }
        public Dictionary<string, Directory> Children = new Dictionary<string, Directory>();
        public List<string> files = new List<string>();
        private int _localFileSize = 0;
        public int localFileSize
        {
            get
            {
                if (_localFileSize == 0)
                {
                    _localFileSize = calculateLocalFileSize();
                }
                return _localFileSize;
            }
        }

        public Directory(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"name: {Name}, parent: {Parent?.Name}, children: {string.Concat(Children.Select(c => c.Value.Name))}, files: {string.Concat(files)}";
        }

        private int calculateLocalFileSize()
        {
            int fileSize = files.Sum(f => Convert.ToInt32(f.Split(' ')[0]));
            return fileSize;
        }

        public int FileSizeLocalAndSubfolders()
        {
            int subfolderSize = Children.Sum(c => c.Value.FileSizeLocalAndSubfolders());
            int allFileSize = localFileSize + subfolderSize;
            return allFileSize;
        }
    }
}
