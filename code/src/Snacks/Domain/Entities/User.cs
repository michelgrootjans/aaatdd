using System.Collections.Generic;
using Utilities.Domain;

namespace Snacks.Domain.Entities
{
    public class User : Entity<long>
    {
        private readonly List<Snack> snaks;

        public User(double credit)
        {
            Credit = credit;
            snaks = new List<Snack>();
        }

        public double Credit { get;private set; }

        public string Name { get; set; }

        public IList<Snack> Snacks
        {
            get { return snaks; }
        }

        public void Request(Snack snack)
        {
            Debit(snack.Price);
            snaks.Add(snack);
        }

        private void Debit(double amount)
        {
            Credit -= amount;
        }
    }
}