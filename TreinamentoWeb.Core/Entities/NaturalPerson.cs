using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoWeb.Core.Entities
{
    public class NaturalPerson : Customer
    {
        public NaturalPerson()
        {
        }

        public NaturalPerson(string cpf, string name, string address, string email, bool active) : base(name, address, email, active)
        {
            CPF = cpf;
        }

        public string CPF { get; set; }
    }
}
