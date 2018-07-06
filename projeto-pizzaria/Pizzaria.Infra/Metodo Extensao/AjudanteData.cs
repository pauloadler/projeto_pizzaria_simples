using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Metodo_Extensao
{
    public static class AjudanteData
    {
        public static bool CompararDataMenorQueAtual(this DateTime dt)
        {
            int result = DateTime.Compare(dt, DateTime.Now);
            if (result < 0)
            {
                return true;
            }

            return false;
        }
    }
}
