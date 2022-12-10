using adventofcode2022.input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventofcode2022.day_5
{
    public class CargoCrane
    {
        public List<List<char>> Cargo { get; set; }
        public int MoveInstructionsStartIndex = 0;
        private string[] CargoAndInstructions { get; set; }

        public CargoCrane(string[] items)
        {
            CargoAndInstructions = items;
        }

        public void LoadShip()
        {
            //Load cargo
            int numCargoStacks = (CargoAndInstructions[0].Length + 1) / 4; //Each crate is 3 chars + 1 gap
            var loadingCargo = new List<List<char>>(numCargoStacks);
            for (int i = 0; i < numCargoStacks; i++)
            {
                loadingCargo.Add(new List<char>());
            }

            for (int i = 0; i < CargoAndInstructions.Length; i++)
            {
                string line = CargoAndInstructions[i];
                //Cargo
                if (line.Contains('['))
                {
                    //start cargo row
                    for(int stack = 0; stack < numCargoStacks; stack++)
                    {
                        var supplies = line[(stack * 4) + 1]; //[A] [B]
                        if(char.IsLetter(supplies))
                        {
                            loadingCargo[stack].Add(supplies);
                        }
                    }
                }
                else if (line.Contains("move")) 
                { 
                    // Move instructions interpreted elsewhere
                    MoveInstructionsStartIndex = i;
                    break;
                }
            }

            for (int i = 0; i < numCargoStacks; i++)
            {
                loadingCargo[i].Reverse();
            }
            Cargo = loadingCargo;
            /*Cargo = new List<Stack<char>>(numCargoStacks);
            for (int i = 0; i < numCargoStacks; i++)
            {
                loadingCargo[i].Reverse();
                Cargo.Add(new Stack<char>(loadingCargo[i]));
            }*/
        }

        public void MoveCargoOneAtATime()
        {
            for(int line = MoveInstructionsStartIndex; line < CargoAndInstructions.Length; line++)
            {
                //just split the thing
                var instruction = CargoAndInstructions[line].Split(' ');
                var numToMove = Convert.ToInt32(instruction[1]);
                var origin = Convert.ToInt32(instruction[3]) - 1; // Adjust to base 0
                var destination = Convert.ToInt32(instruction[5]) - 1; // Adjust to base 0
                for(int i = 0; i < numToMove; i++)
                {
                    var countToPop = 1;
                    var supplies = Cargo[origin].TakeLast(countToPop);
                    Cargo[destination].AddRange(supplies);
                    Cargo[origin].RemoveRange(Cargo[origin].Count - countToPop, countToPop); // remove what was transferred
                }
            }
        }

        public void MoveCargoInGroups()
        {
            for (int line = MoveInstructionsStartIndex; line < CargoAndInstructions.Length; line++)
            {
                //just split the thing
                var instruction = CargoAndInstructions[line].Split(' ');
                var numToMove = Convert.ToInt32(instruction[1]);
                var origin = Convert.ToInt32(instruction[3]) - 1; // Adjust to base 0
                var destination = Convert.ToInt32(instruction[5]) - 1; // Adjust to base 0

                var supplies = Cargo[origin].TakeLast(numToMove);
                Cargo[destination].AddRange(supplies);
                Cargo[origin].RemoveRange(Cargo[origin].Count - numToMove, numToMove); // remove what was transferred
/*
                for (int i = 0; i < numToMove; i++)
                {
                    var countToPop = 1;
                    
                }*/
            }
        }
    }
}
