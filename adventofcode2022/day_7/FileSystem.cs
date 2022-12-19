namespace adventofcode2022.day_7
{
    public class FileSystem
    {
        public Directory Root { get; }
        public List<Directory> DirectoryList { get; }

        public FileSystem()
        {
            Root = new Directory("/");
            DirectoryList = new List<Directory> { Root };
        }

        private void PrintDebug(string msg)
        {
            //Console.WriteLine(msg);
        }


        public void BuildFileTree(string[] input)
        {
            Directory currentDir = Root;

            //Start after the first line - we've already started with root.
            foreach (var line in input.Skip(1))
            {
                if (line.Contains("$ cd"))
                {
                    var changeTo = line.Split(' ')[2];
                    PrintDebug($"Changing directory to: {changeTo}");
                    if (changeTo.Equals(".."))
                    {
                        currentDir = currentDir.Parent;
                    }
                    else
                    {
                        if (!currentDir.Children.ContainsKey(changeTo))
                        {
                            PrintDebug($"Creating dir {changeTo} as child in {currentDir.Name}");
                            //Create & store new dir with name
                            var newDir = new Directory(changeTo);
                            newDir.Parent = currentDir;
                            currentDir.Children.Add(changeTo, newDir);
                            DirectoryList.Add(newDir);
                        }
                        currentDir = currentDir.Children.GetValueOrDefault(changeTo);
                    }
                }
                else if (line.Contains("$ ls"))
                {
                    continue; //Do nothing
                }
                else if (line.Contains("dir"))
                {
                    var dirName = line.Split(' ')[1];
                    if (!currentDir.Children.ContainsKey(dirName))
                    {
                        PrintDebug($"Creating dir {dirName} as child in {currentDir.Name}");
                        //Create & store new dir with name
                        var newDir = new Directory(dirName);
                        newDir.Parent = currentDir;
                        currentDir.Children.Add(dirName, newDir);
                        DirectoryList.Add(newDir);
                    }
                }
                else
                {
                    //PrintDebug($"Adding file {line} to dir {currentDir.Name}");
                    //this is a file
                    currentDir.files.Add(line);
                }
            }
        }


        public int SumSizeOfDirsUnder100k()
        {
            return DirectoryList.Sum(d =>
            {
                var localSize = d.FileSizeLocalAndSubfolders();
                if (localSize <= 100000)
                {
                    PrintDebug($"directory {d.Name} is {localSize}");
                    return localSize;
                }
                return 0;
            });
        }

        public int SizeOfSmallestDirToDelete()
        {
            var diskSize = 70000000;
            var spaceNeeded = 30000000;
            var spaceFilled = Root.FileSizeLocalAndSubfolders();
            var currentFreeSpace = diskSize - spaceFilled;

            var minNeededToDelete = spaceNeeded - currentFreeSpace;
            return DirectoryList.FindAll(d => d.FileSizeLocalAndSubfolders() >= minNeededToDelete).Min(d => d.FileSizeLocalAndSubfolders());
        }
    }
}
