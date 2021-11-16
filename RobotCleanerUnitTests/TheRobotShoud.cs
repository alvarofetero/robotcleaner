using FluentAssertions;
using RobotCleanerLibrary;
using Xunit;

namespace RobotCleanerUnitTests
{
    public class TheRobotShoud
    {

        [Theory]
        [InlineData("1", new string[] { "E 1" })]
        [InlineData("2", new string[] { "E 1", "N 5" })]
        [InlineData("3", new string[] { "E 1", "N 5", "S 10" })]
        public void ReturnTrue_GivenFirstInputLine_NumnberOfCommandsIsCorrect(string numberOfCommandInInputLine, string[] inputCommands)
        {
            //Arrange - Given
            var numberOfCommand = int.Parse(numberOfCommandInInputLine);
            var position = new Position(0, 0);
            
            string[] commands = inputCommands;

            var robotCleaner = new RobotCleaner();

            //Act - When
            var result = robotCleaner.Clean(numberOfCommand, position.x, position.y, commands);

            //Assert - Then
            result.Should().Be(numberOfCommandInInputLine);
        }

        [Fact]
        public void RobotMoveOneToTheEast()
        {

        }
    }
}
