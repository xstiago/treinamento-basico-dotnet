namespace TreinamentoWeb.Core.Entities
{
    public abstract class Customer : BaseEntity
    {
        protected Customer() { }

        protected Customer(string name, string address, string email, bool active) : base(active)
        {
            Name = name;
            Address = address;
            Email = email;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
