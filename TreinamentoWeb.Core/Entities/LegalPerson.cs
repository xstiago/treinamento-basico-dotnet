using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoWeb.Core.Entities
{
    public class LegalPerson : Customer
    {
        public LegalPerson()
        {
        }

        public LegalPerson(string cnpj, string name, string address, string email, bool active) : base(name, address, email, active)
        {
            CNPJ = cnpj;
        }

        public string CNPJ { get; set; }
    }
}
