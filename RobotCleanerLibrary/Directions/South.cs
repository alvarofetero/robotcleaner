namespace RobotCleanerLibrary
{
    public class South : IDirection
    {
        private int MaxSouthBoundary = 100000;
        public Position MoveForward(Position position, int numberOfSteps)
        {
            return position.y + numberOfSteps < MaxSouthBoundary ?
                new Position(position.x, position.y + numberOfSteps):
                new Position(position.x, MaxSouthBoundary);
        }
    }
}
