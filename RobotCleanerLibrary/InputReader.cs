using System;
using System.Collections.Generic;

namespace RobotCleanerLibrary
{
    public class InputReader
    {
        private const string TextForNumberOfCommands = "Enter number of commands >";
        private const string TextForInitialPosition = "Enter initial position (e.g. 10 20) >";
        private const string TextForCommands = "Enter commands (e.g.  E 4) >";
        private char[] Separator = new char[] { ' ' };

        public int NumberOfCommands { get; set; }
        public Position InitialPosition { get; set; }
        public List<string> Commands { get; set; }


        private int GetNumberOfCommandsFromInput()
        {
            Console.Write(TextForNumberOfCommands);
            var firstLine = Console.ReadLine();
            return int.Parse(firstLine);
        }

        private Position ReadPositionFromInput()
        {
            Console.Write(TextForInitialPosition);
            var secondLine = Console.ReadLine();
            string[] inputValues = secondLine.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            if (inputValues.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Not enough parameter");
            }
            var startingX = int.Parse(inputValues[0]);
            var startingY = int.Parse(inputValues[1]);
            return new Position(startingX, startingY);
        }

        private List<string> GetCommandsFromInput(int numberOfCommads)
        {
            var commands = new List<string>();
            string oneCommand;
            for (int i = 0; i < numberOfCommads; i++)
            {
                Console.Write(TextForCommands);
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
