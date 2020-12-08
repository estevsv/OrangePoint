using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model.Balanço_Patrimonial
{
    public class SubtipoBalancoPatrimonial
    {
        private int codSubtipoBalanco;
        public int CodSubtipoBalanco { get => codSubtipoBalanco; set => codSubtipoBalanco = value; }

        private TipoBalancoPatrimonial tipoBalancoPatrimonial;
        public TipoBalancoPatrimonial TipoBalancoPatrimonial { get => tipoBalancoPatrimonial; set => tipoBalancoPatrimonial = value; }

        private string descricao;
        public string Descricao { get => descricao; set => descricao = value; }
    }
}
