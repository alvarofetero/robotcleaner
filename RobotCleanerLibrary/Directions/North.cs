namespace RobotCleanerLibrary
{
    public class North : IDirection
    {
        public Position MoveForward(Position position, int numberOfSteps) => new Position(position.x, position.y - numberOfSteps);
    }
}
