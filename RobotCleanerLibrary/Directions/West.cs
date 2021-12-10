namespace RobotCleanerLibrary
{
    public class West : IDirection
    {
        private int MinWestBoundary = -100000;
        public Position MoveForward(Position position, int numberOfSteps)
        {
            if (position.x - numberOfSteps < MinWestBoundary)
            {
                return new Position(MinWestBoundary, position.y);
            }
            else
            { 
                return new Position(position.x - numberOfSteps, position.y);
            }
        }
    }
}
