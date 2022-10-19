// Create a zip from this and the template file and copy it to %UserProfile%\Documents\Visual Studio %version%\Templates\ItemTemplates\[Visual ]C#
using Moq;
using NUnit.Framework;

namespace $rootnamespace$
{
    [TestFixture]
    public class $safeitemrootname$
    {
        private readonly ITestableObject testable;
        private Mock<IMockedObject> fooMock;

        [SetUp]
        public void TestInitialize()
        {
            testable = new TestableObject();
            fooMock = new Mock<IMockedObject>();
            fooMock.Setup(mock => mock.Get(It.IsAny<int>()))
                .Returns((type) =>
                {
                    if (type == 0)
                    {
                        return 1;
                    }
                    return 0;
                });
        }

        [TestCase(true, TestName = "Test")]
        public void Test(bool expected)
        {
            // Arrange
            testable.Bar();

            // Act
            var actual = testable.Act();
            //void TestDelegate() => Foo.Bar(0);

            // Assert
            Assert.AreEqual(expected, actual);
            //Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
            //Assert.Throws<Exception>(TestDelegate);
        }
    }
}
