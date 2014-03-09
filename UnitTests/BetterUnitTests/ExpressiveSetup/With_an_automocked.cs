using Machine.Specifications;
using Moq;
using StructureMap.AutoMocking;

namespace BetterUnitTests.ExpressiveSetup
{
    [Subject(typeof(object))]
    public abstract class With_an_automocked<T> where T : class
    {
        Establish context = () => autoMocker = new MoqAutoMocker<T>();

        protected static T ClassUnderTest
        {
            get { return autoMocker.ClassUnderTest; }
        }

        protected static Mock<TMock> GetTestDouble<TMock>()
            where TMock : class
        {
            return Mock.Get(autoMocker.Get<TMock>());
        }

        static AutoMocker<T> autoMocker;
    }
}