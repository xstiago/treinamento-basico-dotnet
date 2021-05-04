using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoWeb.Core.Entities
{
    public class LegalPerson : Customer
    {
        public LegalPerson(string name, string address, string email, bool active) : base(name, address, email, active)
        {
        }

        public int CNPJ { get; set; }
    }
}
