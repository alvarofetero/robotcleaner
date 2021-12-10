namespace RobotCleanerLibrary
{
    public class East : IDirection
    {
        private int MaxEastBoundary= 100000;
        public Position MoveForward(Position position, int numberOfSteps)
        {
            return position.x + numberOfSteps <= MaxEastBoundary
                ? new Position(position.x + numberOfSteps, position.y)
                : new Position( MaxEastBoundary, position.y);

        }
    }

}
