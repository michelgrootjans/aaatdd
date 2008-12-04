using NUnit.Framework;
using Rhino.Mocks;
using Utilities.Containers;

namespace FindADate.Tests.Utilities
{
    [TestFixture]
    public class ArrangeActAssert
    {
        [SetUp]
        public void SetUp()
        {            
            Container.Initialize(new DictionaryContainer());
            Arrange();
            SetupSUT();
            Act();            
        }

        protected virtual void SetupSUT() { }

        public virtual void Arrange()
        {
        }

        public virtual void Act()
        {
        }

        [TearDown]
        public void TearDown()
        {
            Container.Initialize(null);
            OnTearDown();
        }

        protected S RegisterStubInContainer<S>() where S : class
        {
            S s = MockRepository.GenerateStub<S>();
            Container.Register(s);
            return s;
        }

        protected S DependencyInContainer<S>() where S : class
        {
            return RegisterStubInContainer<S>();
        }

        protected S Dependency<S>() where S : class
        {
            return MockRepository.GenerateStub<S>();
        }

        /// <summary>
        /// Called when [fixture tear down].
        /// </summary>
        public virtual void OnTearDown() { }
    }

    public class ArrangeActAssert<T> : ArrangeActAssert
    {
        protected T sut { get; private set; }

        protected override void SetupSUT()
        {
            sut = CreateSUT();
        }

        public virtual T CreateSUT()
        {
            return default(T);
        }
    }
}