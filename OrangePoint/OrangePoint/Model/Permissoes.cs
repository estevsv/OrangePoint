using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class Permissoes
    {
        private int codPermissao;
        public int CodPermissao { get => codPermissao; set => codPermissao = value; }

        private Usuario usuario;
        public Usuario Usuario { get => usuario; set => usuario = value; }

        private TipoPermissao tipoPermissao;
        public TipoPermissao TipoPermissao { get => tipoPermissao; set => tipoPermissao = value; }
    }
}
