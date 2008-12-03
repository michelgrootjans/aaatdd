using NUnit.Framework;
using Rhino.Mocks;

namespace BDD
{
    [TestFixture]
    public abstract class StaticContextSpecification
    {
        private MockRepository mockery;

        [SetUp]
        public void setup()
        {
            mockery = new MockRepository();
            establish_context();

            mockery.ReplayAll();

            initialize_system_under_test();

            because();
        }

        [TearDown]
        public void tear_down()
        {
            after_each_observation();
            mockery.VerifyAll();
        }

        protected abstract void because();

        protected virtual void establish_context()
        {
        }

        protected virtual void initialize_system_under_test()
        {
        }

        protected virtual void after_each_observation()
        {
        }

        protected InterfaceType an<InterfaceType>()
        {
            return MockRepository.GenerateMock<InterfaceType>();
        }

        protected InterfaceType strict_dependency<InterfaceType>()
        {
            return mockery.StrictMock<InterfaceType>();
        }

        protected InterfaceType not_important_in_this_context<InterfaceType>()
        {
            return an<InterfaceType>();
        }
    }

    public abstract class InstanceContextSpecification<SystemUnderTest> : StaticContextSpecification
    {
        protected SystemUnderTest sut;
        protected abstract SystemUnderTest create_sut();

        protected abstract override void establish_context();

        protected override void initialize_system_under_test()
        {
            sut = create_sut();
        }
    }
}