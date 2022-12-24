namespace adventofcode2022.day_9
{
    public class Knots
    {
        public List<int[]> Rope;
        public List<(int, int)> TailPath;

        public Knots(int length = 2) { 
            Rope = new List<int[]>();
            for (int i = 0; i < length; i++)
            {
                Rope.Add(new int[]{ 0, 0});
            }
            TailPath = new List<(int, int)> { (0,0) };
        }
                

        public void MakeAMove(string[] input)
        {
            
            var head = Rope.First();
            foreach (string move in input)
            {
                var amount = int.Parse(move.Split(' ')[1].ToString());
                var direction = move[0];
                for (int i = 0; i < amount; i++)
                {
                    switch (direction)
                    {
                        case 'U':
                            head[1]++;
                            break;
                        case 'D':
                            head[1]--;
                            break;
                        case 'R':
                            head[0]++;
                            break;
                        case 'L':
                            head[0]--;
                            break;
                    }
                    MoveBody();
                }
            }
        }

        public void MoveBody()
        {
            for(int i = 0; i < Rope.Count - 1; i++)
            {
                //Moves tail position based on Head position
                var first = Rope[i];
                var second = Rope[i+1];
                int xDiff = first[0] - second[0];
                
                //Horizontal change
                if (Math.Abs(xDiff) > 1)
                {
                    // Left
                    if(xDiff > 0)
                    {
                        second[0] = first[0] - 1;
                    }
                    else
                    {
                        second[0] = first[0] + 1;
                    }
                    //Adjust vertical if not on same row
                    if (second[1] < first[1])
                    {
                        second[1]++;
                    }
                    else if (second[1] > first[1])
                    {
                        second[1]--;
                    }
                }

                int yDiff = first[1] - second[1];
                //Vertical change
                if (Math.Abs(yDiff) > 1)
                {
                    //Down
                    if(yDiff > 0)
                    {
                        second[1] = first[1] - 1;
                    }
                    else
                    {
                        second[1] = first[1] + 1;
                    }
                    //Adjust horizontal if not in same column
                    if (second[0] < first[0])
                    {
                        second[0]++;
                    }
                    else if (second[0] > first[0])
                    {
                        second[0]--;
                    }
                }
            }

            // Store final Tail loc
            var tail = Rope.Last();
            TailPath.Add((tail[0], tail[1]));
        }
    }
}
