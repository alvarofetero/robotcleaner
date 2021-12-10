using System;
using System.Collections.Generic;
using System.Text;

namespace RobotCleanerLibrary
{
    public class CommandProcessor
    {
        private List<Command> listOfCommands;

        public List<Command> ListOfCommands { get { return listOfCommands; } }


        public CommandProcessor()
        {
            listOfCommands = new List<Command>(); 
        }

        public void ParseCommands(string[] commands)
        {
            for (int i = 0; i <= commands.Length-1; i++)
            {
                var currentCommand = commands[i].Split(' ');
                var directionFromInput = currentCommand[0];
                var steps = currentCommand[1];

                listOfCommands.Add(new Command { Direction = directionFromInput, Steps = steps });
            }
        }

    }

    public class Command
    {
        public string Direction;
        public string Steps;
    }
}
