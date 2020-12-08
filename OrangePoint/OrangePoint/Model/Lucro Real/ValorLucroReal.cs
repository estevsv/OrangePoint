using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model.Lucro_Real
{
    public class ValorLucroReal
    {
        private int codValorLucroReal;
        public int CodValorLucroReal { get => codValorLucroReal; set => codValorLucroReal = value; }

        private SubtipoLucroReal subtipoLucroReal;
        public SubtipoLucroReal SubtipoLucroReal { get => subtipoLucroReal; set => subtipoLucroReal = value; }

        private Valor valor;
        public Valor Valor { get => valor; set => valor = value; }
    }
}
