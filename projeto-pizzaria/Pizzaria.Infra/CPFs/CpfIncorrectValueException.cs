﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CPFs
{
    public class CpfIncorrectValueException : CpfException
    {
        public CpfIncorrectValueException() : base("CPF não pode conter Letras e caracteres especiais!")
        {
        }
    }
}
