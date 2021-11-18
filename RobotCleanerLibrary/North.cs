namespace RobotCleanerLibrary
{
    public class North : IDirection
    {
        public Position MoveForward(Position position, int numberOfSteps)
        {
            position.y -= numberOfSteps;
            return position;
        }
    }
}
