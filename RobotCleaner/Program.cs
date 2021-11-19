using RobotCleanerLibrary;
using System;
using System.Collections.Generic;

namespace RobotCleanerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            
                Console.Write("Enter number of commands >");
                var firstLine = Console.ReadLine();
                var numberOfCommands = int.Parse(firstLine);
                Console.Write("Enter initial position >");
                var secondLine = Console.ReadLine();
                List<string> commands = new List<string>();
                string oneCommand;
                for (int i = 0; i<numberOfCommands;i++)
                {
                    Console.Write("Enter commands >");
                    oneCommand = Console.ReadLine();
                    commands.Add(oneCommand);
                }

                var secondLineArray = secondLine.Split(' ');
                var startingX = int.Parse(secondLineArray[0]);
                var startingY = int.Parse(secondLineArray[1]);

                var initialPosition = new Position(startingX, startingY);
                var robotCleaner = new RobotCleaner(initialPosition);

                var placesCleaned = robotCleaner.Clean(commands.ToArray());

                Console.WriteLine($" => Cleaned :{placesCleaned}");

            
            
            
            

            
        }
    }
}
