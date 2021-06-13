using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class Valor
    {
        private int codValor;
        public int CodValor { get => codValor; set => codValor = value; }

        private SubtipoValor subtipoValor;
        public SubtipoValor SubtipoValor { get => subtipoValor; set => subtipoValor = value; }

        private DataEmpresa dataEmpresa;
        public DataEmpresa DataEmpresa { get => dataEmpresa; set => dataEmpresa = value; }

        private decimal numValor;
        public decimal NumValor { get => numValor; set => numValor = value; }

        private int valorRelatorio;
        public int ValorRelatorio { get => valorRelatorio; set => valorRelatorio = value; }
    }
}
