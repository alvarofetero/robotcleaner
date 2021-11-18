namespace RobotCleanerLibrary
{
    public class East : IDirection
    {
        public Position MoveForward(Position position, int numberOfSteps) => new Position(position.x + numberOfSteps, position.y);
    }

}
