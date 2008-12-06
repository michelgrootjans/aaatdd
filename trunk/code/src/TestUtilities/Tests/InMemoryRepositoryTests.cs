/*
 * Created by: 
 * Created: zaterdag 6 december 2008
 */

using System;
using System.Linq;
using NUnit.Framework;
using Utilities.Repository;

namespace TestUtilities.Tests
{
    public class InMemoryRepositoryTest : ArrangeActAssert<IRepository>
    {
        protected DummyEntity dummyEntity;
        private readonly Random random = new Random();

        public override void Arrange()
        {
            dummyEntity = new DummyEntity(random.Next());
        }

        public override IRepository CreateSUT()
        {
            return new InMemoryRepository();
        }
    }

    public class when_the_repository_is_empty : InMemoryRepositoryTest
    {
        [Test]
        public void should_find_an_empty_list_if_entities()
        {
            var entities = sut.FindAll<DummyEntity>();
            entities.ToList().Count.ShouldBeEqualTo(0);
        }

        [Test]
        public void should_find_a_null_list_of_entities()
        {
            var entityFound = sut.Get<DummyEntity>(dummyEntity.Id);
            entityFound.ShouldBeNull();
        }

        [Test]
        public void should_allow_to_delete_a_non_existing_entity()
        {
            sut.Delete(dummyEntity);
        }
    }    
    
    public class when_repository_is_told_to_save_an_entity : InMemoryRepositoryTest
    {
        public override void Act()
        {
            sut.Save(dummyEntity);
        }

        [Test]
        public void should_find_it_in_all_entities()
        {
            var entities = sut.FindAll<DummyEntity>();
            entities.ToList().Count.ShouldBeEqualTo(1);
        }

        [Test]
        public void should_be_able_to_find_the_entity()
        {
            var entityFound = sut.Get<DummyEntity>(dummyEntity.Id);
            entityFound.ShouldBeSameAs(dummyEntity);
        }
    }
    
    public class when_repository_is_told_to_delete_an_existing_entity : InMemoryRepositoryTest
    {
        public override void Act()
        {
            sut.Save(dummyEntity);
            sut.Delete(dummyEntity);
        }

        [Test]
        public void shouldnt_find_it_in_all_entities()
        {
            var entities = sut.FindAll<DummyEntity>();
            entities.ToList().Count.ShouldBeEqualTo(0);
        }

        [Test]
        public void should_not_be_able_to_find_the_entity()
        {
            var entityFound = sut.Get<DummyEntity>(dummyEntity.Id);
            entityFound.ShouldBeNull();
        }
    }
}