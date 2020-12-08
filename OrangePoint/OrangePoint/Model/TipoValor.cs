using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class TipoValor
    {
        private int codTipoValor;
        public int CodTipoValor { get => codTipoValor; set => codTipoValor = value; }

        private string descTipo;
        public string DescTipo { get => descTipo; set => descTipo = value; }
    }
}
