namespace Snacks
{
    public class User
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
}