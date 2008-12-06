using Utilities.Domain;

namespace Snacks.Domain.Entities
{
    public class User : Entity<int>, IDebitableUser
    {
        public double Credit { get;private set; }


        public string Name { get; set; }

        public User(double credit)
        {
            Credit = credit;
        }

        public void Debit(double amount)
        {
            Credit -= amount;
        }
    }

    public interface IDebitableUser
    {
        void Debit(double amount);
    }
}