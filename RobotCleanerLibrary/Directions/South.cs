namespace RobotCleanerLibrary
{
    public class South : IDirection
    {
        public Position MoveForward(Position position, int numberOfSteps) => new Position(position.x, position.y + numberOfSteps);
    }
}
