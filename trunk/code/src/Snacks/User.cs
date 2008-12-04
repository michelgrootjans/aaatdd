namespace Snacks
{
    public class User : IDebitableUser
    {
        public double Credit { get;private set; }

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