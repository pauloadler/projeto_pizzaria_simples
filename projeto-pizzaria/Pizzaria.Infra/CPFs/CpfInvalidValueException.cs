﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CPFs
{
    public class CpfInvalidValueException : CpfException
    {
        public CpfInvalidValueException() : base("CPF inválido!")
        {
        }
    }
}
