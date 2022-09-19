// Create a zip from this and the template file %UserProfile%\Documents\Visual Studio 2019\Templates\ItemTemplates\Visual C#
using Moq;
using NUnit.Framework;
using Platform.TestUtils;

namespace $rootnamespace$
{
    [TestFixture]
    public class $safeitemrootname$ : TestBase
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
