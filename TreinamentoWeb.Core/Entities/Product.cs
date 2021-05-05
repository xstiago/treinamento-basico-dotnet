using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoWeb.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
        }

        public Product(bool active, string description, decimal price, string manufacturer, string kind ) : base(active)
        {
            Description = description;
            Price = price;
            Manufacturer = manufacturer;
            Kind = kind;
        }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public string Kind { get; set; }

    }
}
