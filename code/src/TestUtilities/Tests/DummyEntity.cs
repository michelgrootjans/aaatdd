using System;
using Utilities.Domain;

namespace TestUtilities.Tests
{
    public class DummyEntity :Entity<int>
    {
        public DummyEntity(int id)
        {
            Id = id;
        }
    }
}