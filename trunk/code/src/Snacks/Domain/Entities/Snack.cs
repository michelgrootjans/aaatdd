using Utilities.Domain;

namespace Snacks.Domain.Entities
{
    public class Snack : Entity<int>
    {
        public string Name { get; set; }

        public double Price { get; set; }
    }
}