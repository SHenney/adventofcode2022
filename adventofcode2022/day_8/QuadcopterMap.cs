namespace adventofcode2022.day_8
{
    public class QuadcopterMap
    {

        public List<Tree> SurveyForest(string[] input)
        {
            List<Tree> treeSurvey = new List<Tree>();
            foreach (string row in input)
            {
                int rowLength = row.Length;
                for (int i = 0; i < rowLength; i++)
                {
                    int height = int.Parse($"{row[i]}");
                    Tree newTree = new Tree(height);

                    //Add tree on left (West)
                    if (i > 0)
                    {
                        Tree westTree = treeSurvey[treeSurvey.Count - 1];
                        newTree.West = westTree;
                        westTree.East = newTree;
                    }

                    //Add tree above (North)
                    int northTreeIndex = treeSurvey.Count - rowLength;
                    if (northTreeIndex >= 0)
                    {
                        Tree northTree = treeSurvey[northTreeIndex];
                        newTree.North = northTree;
                        northTree.South = newTree;
                    }

                    treeSurvey.Add(newTree);
                }
            }
            return treeSurvey;
        }

        public void MarkVisibleTrees(List<Tree> trees)
        {
            int maxHeight = 9;
            foreach (Tree tree in trees)
            {
                //North edge
                if (tree.North is null)
                {
                    int heigthToBeat = -1;
                    Tree treeUnderTest = tree;
                    while (treeUnderTest is not null && heigthToBeat < maxHeight)
                    {
                        if (treeUnderTest.height > heigthToBeat)
                        {
                            treeUnderTest.isVisible = true;
                            heigthToBeat = treeUnderTest.height;
                        }
                        treeUnderTest = treeUnderTest.South;
                    }
                }
                //South edge
                if (tree.South is null)
                {
                    int heigthToBeat = -1;
                    Tree treeUnderTest = tree;
                    while (treeUnderTest is not null && heigthToBeat < maxHeight)
                    {
                        if (treeUnderTest.height > heigthToBeat)
                        {
                            treeUnderTest.isVisible = true;
                            heigthToBeat = treeUnderTest.height;
                        }
                        treeUnderTest = treeUnderTest.North;
                    }
                }

                //West edge
                if (tree.West is null)
                {
                    int heigthToBeat = -1;
                    Tree treeUnderTest = tree;
                    while (treeUnderTest is not null && heigthToBeat < maxHeight)
                    {
                        if (treeUnderTest.height > heigthToBeat)
                        {
                            treeUnderTest.isVisible = true;
                            heigthToBeat = treeUnderTest.height;
                        }
                        treeUnderTest = treeUnderTest.East;
                    }
                }
                //East edge
                if (tree.East is null)
                {
                    int heigthToBeat = -1;
                    Tree treeUnderTest = tree;
                    while (treeUnderTest is not null && heigthToBeat < maxHeight)
                    {
                        if (treeUnderTest.height > heigthToBeat)
                        {
                            treeUnderTest.isVisible = true;
                            heigthToBeat = treeUnderTest.height;
                        }
                        treeUnderTest = treeUnderTest.West;
                    }
                }
            }
        }

        public int CountVisibleTrees(List<Tree> treeList)
        {
            return treeList.Count(t => t.isVisible);
        }

        public void MarkViewDistance(List<Tree> trees)
        {
            foreach (Tree tree in trees)
            {
                //North visibility
                Tree treeUnderTest = tree.North;
                while (treeUnderTest is not null)
                {
                    tree.northViewDistance++;
                    if (treeUnderTest.height >= tree.height)
                    {
                        break;
                    }
                    treeUnderTest= treeUnderTest.North;
                }
                //South visibility
                treeUnderTest = tree.South;
                while (treeUnderTest is not null)
                {
                    tree.southViewDistance++;
                    if (treeUnderTest.height >= tree.height)
                    {
                        break;
                    }
                    treeUnderTest = treeUnderTest.South;
                }
                //East visibility
                treeUnderTest = tree.East;
                while (treeUnderTest is not null)
                {
                    tree.eastViewDistance++;
                    if (treeUnderTest.height >= tree.height)
                    {
                        break;
                    }
                    treeUnderTest = treeUnderTest.East;
                }
                //West visibility
                treeUnderTest = tree.West;
                while (treeUnderTest is not null)
                {
                    tree.westViewDistance++;
                    if (treeUnderTest.height >= tree.height)
                    {
                        break;
                    }
                    treeUnderTest = treeUnderTest.West;
                }
            }
        }

        public int BestScenicScore(List<Tree> treeList)
        {
            return treeList.Max(t => t.scenicScore);
        }
    }
}
