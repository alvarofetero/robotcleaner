using System;

namespace RobotCleanerLibrary
{
    public partial class RobotCleaner
    {
        private int maxValueXPosition = 100000;
        private int maxValueYPosition = 100000;
        private int minValueXPosition = -100000;
        private int minValueYPosition = -100000;
        private Position currentPosition;

        public Position CurrentPosition { get { return currentPosition; } }
        IDirection currentDirection;

        

        public RobotCleaner(Position initialPosition)
        {
            var x=initialPosition.x;
            var y=initialPosition.y;
            
            if (initialPosition.x > maxValueXPosition) x = maxValueXPosition;
            if (initialPosition.y > maxValueYPosition) y = maxValueYPosition;
            if (initialPosition.x < minValueXPosition) x = minValueXPosition;
            if (initialPosition.y < minValueYPosition) y = minValueYPosition;

            this.currentPosition = new Position(x, y);
            
        }

        public string Clean(int numberOfCommand, string[] commands)
        {
            if (commands.Length>0)
            {
                var currentCommand=commands[0].Split(' ');
                var directionFromInput = currentCommand[0];
                var steps = currentCommand[1];
                var stepsAsInt = int.Parse(steps);
                if (stepsAsInt < 0) stepsAsInt = 0;
                if (stepsAsInt > 100000) stepsAsInt = 100000;

                this.currentDirection= DirectionFactory.CreateDirectionFrom(directionFromInput);

                this.currentPosition = this.currentDirection.MoveForward(this.currentPosition, stepsAsInt);
                
            }

            return commands.Length.ToString();
        }

       

        

    }
}
