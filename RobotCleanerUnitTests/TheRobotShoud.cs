using FluentAssertions;
using System;
using Xunit;

namespace RobotCleanerUnitTests
{
    public class TheRobotShoud
    {
        [Fact]
        public void ReturnTrue_GivenFirstInputLine_IsAnInteger()
        {
            //Arrange - Given
            var numberOfCommand = 1;
            var startX = 0;
            var startY = 0;
            string[] commands = {"E 0"};

            var robotCleaner = new RobotCleaner();

            //Act - When
            var result = robotCleaner.Clean(numberOfCommand, startX, startY, commands);

            //Assert - Then
            result.Should().Be("1");
        }
    }

    public class RobotCleaner
    {
        public string Clean(int numberOfCommand, int x, int y, string[] commands)
        {
            return string.Empty;
        }
    }
}
