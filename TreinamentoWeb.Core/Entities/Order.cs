using System;
using System.Collections.Generic;

namespace TreinamentoWeb.Core.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
        }

        public Order(bool active, IEnumerable<Product> products, Customer customer) 
            : base(active)
        {
            Products = products;
            Customer = customer;
        }

        public Customer Customer { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
