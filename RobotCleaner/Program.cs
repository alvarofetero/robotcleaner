using RobotCleanerLibrary;
using System;
using System.Collections.Generic;

namespace RobotCleanerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            { 
                var inputReader = new InputReader();
                inputReader.ReadInput();

                var robotCleaner = new RobotCleaner(inputReader.InitialPosition);
                var placesCleaned = robotCleaner.Clean(inputReader.Commands.ToArray());

                Console.WriteLine($" => Cleaned :{placesCleaned}");
            }

        }
    }
}
