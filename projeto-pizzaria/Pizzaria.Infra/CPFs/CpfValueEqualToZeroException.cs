using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CPFs
{
    public class CpfValueEqualToZeroException : CpfException
    {
        public CpfValueEqualToZeroException() : base("O CPF não pode ter o valor igual a 0!")
        {

        }
    }
}
