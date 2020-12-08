using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    class AlvaraEmpresa
    {
        private int codAlvara;
        public int CodAlvara { get => codAlvara; set => codAlvara = value; }

        private Empresa empresa;
        public Empresa Empresa { get => empresa; set => empresa = value; }

        private string descAlvara;
        public string DescAlvara { get => descAlvara; set => descAlvara = value; }

    }
}
