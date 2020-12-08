using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class SubtipoValor
    {
        private int codSubtipoValor;
        public int CodSubtipoValor { get => codSubtipoValor; set => codSubtipoValor = value; }

        private TipoValor tipoValor;
        public TipoValor TipoValor { get => tipoValor; set => tipoValor = value; }

        private string descSubtipo;
        public string DescSubtipo { get => descSubtipo; set => descSubtipo = value; }
    }
}
