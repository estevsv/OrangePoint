using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class TipoPermissao
    {
        private int codTipoPermissao;
        public int CodTipoPermissao { get => codTipoPermissao; set => codTipoPermissao = value; }

        private string descPermissao;
        public string DescPermissao { get => descPermissao; set => descPermissao = value; }
    }
}
