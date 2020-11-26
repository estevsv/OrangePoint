using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class PermissaoTela
    {
        private int codPermissaoTela;
        public int CodPermissaoTela { get => codPermissaoTela; set => codPermissaoTela = value; }

        private TipoPermissao tipoPermissao;
        public TipoPermissao TipoPermissao { get => tipoPermissao; set => tipoPermissao = value; }

        private string descTela;
        public string DescTela { get => descTela; set => descTela = value; }
    }
}
