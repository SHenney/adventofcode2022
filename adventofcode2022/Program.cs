using adventofcode2022.day_1;
using adventofcode2022.day_2;
using adventofcode2022.day_3;
using adventofcode2022.day_4;

DotNetEnv.Env.TraversePath().Load(); //Load from .env file

//Day 1
D1_CalorieCount d1 = new();
int answer1 = d1.SolvePart1();
Console.WriteLine($"And the solution is: {answer1}");

int answer1v2 = d1.SolvePart1_v2();
Console.WriteLine($"And the solution is: {answer1v2}");

int answer2 = d1.SolvePart2();
Console.WriteLine($"And the solution is: {answer2}");


//Day 2
D2_RockPaperScissors d2 = new D2_RockPaperScissors();
int answer2_1 = d2.SolvePart1();
Console.WriteLine($"And the solution is: {answer2_1}");

int answer2_2 = d2.SolvePart2();
Console.WriteLine($"And the solution is: {answer2_2}");


//Day 3
D3_Rucksack.SolvePuzzle();


//Day 4
D4_CampCleanup.SolvePuzzle();