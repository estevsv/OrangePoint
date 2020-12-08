using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model.Balanço_Patrimonial
{
    public class ValorBalancoPatrimonial
    {
        private int codValorBalancoPatrimonial;
        public int CodValorBalancoPatrimonial { get => codValorBalancoPatrimonial; set => codValorBalancoPatrimonial = value; }

        private SubtipoBalancoPatrimonial subtipoBalancoPatrimonial;
        public SubtipoBalancoPatrimonial SubtipoBalancoPatrimonial { get => subtipoBalancoPatrimonial; set => subtipoBalancoPatrimonial = value; }

        private Valor valor;
        public Valor Valor { get => valor; set => valor = value; }
    }
}
