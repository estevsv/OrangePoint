using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class ContatoEmpresa
    {
        private int codContato;
        public int CodContato { get => codContato; set => codContato = value; }

        private Empresa empresa;
        public Empresa Empresa { get => empresa; set => empresa = value; }

        private string descContato;
        public string DescContato { get => descContato; set => descContato = value; }
    }
}
