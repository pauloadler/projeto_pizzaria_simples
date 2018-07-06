using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CNPJs
{
    public class CnpjValueNullOrEmptyException : CnpjException
    {
        public CnpjValueNullOrEmptyException() : base("CNPJ não pode ser nulo!")
        {
        }
    }
}
