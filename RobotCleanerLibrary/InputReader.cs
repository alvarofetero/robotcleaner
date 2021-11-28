using System;
using System.Collections.Generic;

namespace RobotCleanerLibrary
{
    public class InputReader
    {
        public int NumberOfCommands { get; set; }
        public Position InitialPosition { get; set; }
        public List<string> Commands { get; set; }


        private int GetNumberOfCommandsFromInput()
        {
            Console.Write("Enter number of commands >");
            var firstLine = Console.ReadLine();
            return int.Parse(firstLine);
        }

        private Position ReadPositionFromInput()
        {
            Console.Write("Enter initial position >");
            var secondLine = Console.ReadLine();
            var secondLineArray = secondLine.Split(' ');
            var startingX = int.Parse(secondLineArray[0]);
            var startingY = int.Parse(secondLineArray[1]);
            return new Position(startingX, startingY);
        }

        private List<string> GetCommandsFromInput(int numberOfCommads)
        {
            var commands = new List<string>();
            string oneCommand;
            for (int i = 0; i < numberOfCommads; i++)
            {
                Console.Write("Enter commands >");
                oneCommand = Console.ReadLine();
                commands.Add(oneCommand);
            }
            return commands;
        }

        public void ReadInput()
        {
            this.NumberOfCommands = GetNumberOfCommandsFromInput();
            this.InitialPosition = ReadPositionFromInput();
            this.Commands = GetCommandsFromInput(this.NumberOfCommands);
        }

    }
}
