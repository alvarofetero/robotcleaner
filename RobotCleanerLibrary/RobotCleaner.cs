namespace RobotCleanerLibrary
{
    public class RobotCleaner
    {
        private int maxValueXPosition = 100000;
        private int maxValueYPosition = 100000;
        private int minValueXPosition = -100000;
        private int minValueYPosition = -100000;
        private Position currentPosition;

        public Position CurrentPosition { get { return currentPosition; } }

        

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

        public string Clean(int numberOfCommand, Position startPosition, string[] commands)
        {
            return commands.Length.ToString();
        }
    }
}
