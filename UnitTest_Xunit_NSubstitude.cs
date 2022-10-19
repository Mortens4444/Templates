using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace $rootnamespace$
{
    public partial class $safeitemrootname$
    {
        private ITestableObject testable;
        private IMockedObject fooMock;

        public void TestInitialize()
        {
            testable = new TestableObject();
            fooMock = (IMockedObject)Substitute.For(new[] { typeof(IMockedObject) }, Array.Empty<object>());
            fooMock.Get(Arg.Any<int>())
                .Returns((args) => (int)args[0] == 0 ? 1 : 0);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TheoryTest(bool expected)
        {
            // Arrange
			      TestInitialize();
            testable.Bar();

            // Act
            var actual = testable.Act();

            // Assert
			      actual.Should().Be(expected);
			      //Enumerable.SequenceEqual(expected, actual).Should().BeTrue();
        }
		
        [Fact]
        public void FactTest()
        {
            // Arrange
			      TestInitialize();
            testable.Bar();

            // Act
			      void TestDelegate() => testable.Act(0);

            // Assert
            Assert.Throws<Exception>(TestDelegate);
        }
    }
}
