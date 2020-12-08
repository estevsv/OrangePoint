using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model.Lucro_Real
{
    public class SubtipoLucroReal
    {
        private int codSubtipoLucroReal;
        public int CodSubtipoLucroReal { get => codSubtipoLucroReal; set => codSubtipoLucroReal = value; }

        private TipoLucroReal tipoLucroReal;
        public TipoLucroReal TipoLucroReal { get => tipoLucroReal; set => tipoLucroReal = value; }

        private string descricao;
        public string Descricao { get => descricao; set => descricao = value; }
    }
}
