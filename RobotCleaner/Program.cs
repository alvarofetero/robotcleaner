using RobotCleanerLibrary;
using System;
using System.Collections.Generic;

namespace RobotCleanerClient
{
    class Program
    {
        static void Main(string[] args)
        {
                var numberOfCommands = GetNumberOfCommandsFromInput();

                var initialPosition = ReadPositionFromInput();
                var commands = GetCommandsFromInput(numberOfCommands);
                var robotCleaner = new RobotCleaner(initialPosition);
                var placesCleaned = robotCleaner.Clean(commands.ToArray());

                Console.WriteLine($" => Cleaned :{placesCleaned}");
        }

        private static Position ReadPositionFromInput()
        {
            Console.Write("Enter initial position >");
            var secondLine = Console.ReadLine();
            var secondLineArray = secondLine.Split(' ');
            var startingX = int.Parse(secondLineArray[0]);
            var startingY = int.Parse(secondLineArray[1]);
            return new Position(startingX, startingY);
        }

        private static List<string> GetCommandsFromInput(int numberOfCommads)
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

        private static int GetNumberOfCommandsFromInput()
        {
            Console.Write("Enter number of commands >");
            var firstLine = Console.ReadLine();
            return int.Parse(firstLine);
        }



    }
}
