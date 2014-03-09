using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace BetterUnitTests.Fast
{
    [TestFixture]
    public class HandleGenerationTests
    {
        [SetUp]
        public void Setup()
        {
            HandlePersistence = new Mock<IHandlePersistence>();
        }

        Mock<IHandlePersistence> HandlePersistence;

        [Test]
        public void When_a_generated_handle_does_exist_a_new_handle_is_generated_saved_and_returned()
        {
            var handleFactory = new HandleFactoryForTesting(HandlePersistence.Object);
            handleFactory.SetGeneratedHandles("A", "B", "C", "D");
            HandlePersistence.Setup(x => x.HandleExists(It.IsAny<string>())).ReturnsInOrder(true, true, true, false);
            var newHandle = handleFactory.CreateNewHandle();
            Assert.That(newHandle, Is.EqualTo("D"));
            HandlePersistence.Verify(x => x.SaveNewHandle("D"));
            HandlePersistence.Verify(x => x.SaveNewHandle("A"), Times.Never());
            HandlePersistence.Verify(x => x.SaveNewHandle("B"), Times.Never());
            HandlePersistence.Verify(x => x.SaveNewHandle("C"), Times.Never());
        }

        [Test]
        public void When_the_handle_does_not_exist_it_is_saved_and_returned()
        {
            var handleFactory = new HandleFactory(HandlePersistence.Object);
            HandlePersistence.Setup(x => x.HandleExists(It.IsAny<string>())).Returns(false);
            var newHandle = handleFactory.CreateNewHandle();
            HandlePersistence.Verify(x => x.SaveNewHandle(newHandle));
        }
    }

    class HandleFactoryForTesting : HandleFactory
    {
        Queue<string> queueOfHandles;

        public HandleFactoryForTesting(IHandlePersistence handlePersistence) : base(handlePersistence)
        {
        }

        public void SetGeneratedHandles(params string[] handles)
        {
            queueOfHandles = new Queue<string>(handles);
        }

        protected override string GenerateHandle()
        {
            return queueOfHandles.Dequeue();
        }
    }
}