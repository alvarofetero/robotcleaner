namespace RobotCleanerLibrary
{
    public class West : IDirection
    {
        public Position MoveForward(Position position, int numberOfSteps)
        {
            position.x -= numberOfSteps;
            return position;
        }
    }
}
