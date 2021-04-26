namespace Treinamento.Classes
{
    public class Customer : BaseEntity
    {
        public Customer() { }

        public Customer(string name, string address, string email, bool active) : base(active)
        {
            Name = name;
            Address = address;
            Email = email;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; private set; }
        
        public string GetActive() => Active ? "Yes" : "No";

        public void SetEmail(string email)
        {
            Email = email;
        }
    }
}
