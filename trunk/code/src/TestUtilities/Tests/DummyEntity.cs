using System;
using Utilities.Domain;

namespace TestUtilities.Tests
{
    public class DummyEntity :Entity<Guid>
    {
        public DummyEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}