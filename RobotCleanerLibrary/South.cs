namespace RobotCleanerLibrary
{
    public class South : IDirection
    {
        public Position MoveForward(Position position, int numberOfSteps)
        {
            position.y += numberOfSteps;
            return position;
        }
    }
}
