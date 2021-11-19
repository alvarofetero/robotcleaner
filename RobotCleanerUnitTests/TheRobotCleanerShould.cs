using FluentAssertions;
using RobotCleanerLibrary;
using Xunit;

namespace RobotCleanerUnitTests
{
    public class TheRobotCleanerShould
    {
        [Fact]
        public void Return0_WhenStartAt_1_1_And_CommandsAreNull()
        {
            //Arrange
            var initialPosition = new Position(1, 1);
            var robotCleaner = new RobotCleaner(initialPosition);
            string[] commands = null;

            //Act
            var places = robotCleaner.Clean(commands);

            //Assert
            places.Should().Be(0);

        }

        [Fact]
        public void Return1_WhenStartAt_1_1_And_CommandsAreE1()
        {
            //Arrange
            var initialPosition = new Position(1, 1);
            var robotCleaner = new RobotCleaner(initialPosition);
            string[] commands = null;

            //Act
            var places = robotCleaner.Clean(commands);

            //Assert
            places.Should().Be(1);

        }


    }
}
