/*
 * Created by: 
 * Created: zaterdag 6 december 2008
 */

using System.Linq;
using NUnit.Framework;
using Utilities.Repository;

namespace TestUtilities.Tests
{
    [TestFixture]
    public class InMemoryRepositoryTests : ArrangeActAssert<IRepository>
    {
        private DummyEntity dummyEntity;

        public override void Arrange()
        {
            dummyEntity = new DummyEntity();
        }

        public override IRepository CreateSUT()
        {
            return new InMemoryRepository();
        }

        [Test]
        public void should_be_able_to_get_all_strings()
        {
            var entities = sut.FindAll<DummyEntity>();
            entities.ToList().Count.ShouldBeEqualTo(0);
        }

        [Test]
        public void should_be_able_to_save_one_entity()
        {
            sut.Save(dummyEntity);
            var entities = sut.FindAll<DummyEntity>();

            entities.ToList().Count.ShouldBeEqualTo(1);
        }

        [Test]
        public void should_be_able_to_find_one_entity()
        {
            sut.Save(dummyEntity);
            var entityFound = sut.Get<DummyEntity>(dummyEntity.Id);

            entityFound.ShouldBeSameAs(dummyEntity);
        }

        [Test]
        public void should_be_able_to_delete_an_entity()
        {
            sut.Save(dummyEntity);
            sut.Delete(dummyEntity);

            var entityFound = sut.Get<DummyEntity>(dummyEntity.Id);
            entityFound.ShouldBeNull();
        }

        [Test]
        public void should_return_null_on_an_entity_that_doesnt_exist()
        {
            var entityFound = sut.Get<DummyEntity>(dummyEntity.Id);
            entityFound.ShouldBeNull();
        }
    }
}