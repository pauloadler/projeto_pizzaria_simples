using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CPFs
{
    public class CpfValueLessThanElevenException : CpfException
    {
        public CpfValueLessThanElevenException() : base("O CPF não pode ter menos de 11 digitos!")
        {
        }
    }
}
