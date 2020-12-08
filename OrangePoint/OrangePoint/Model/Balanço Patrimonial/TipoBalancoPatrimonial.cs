using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model.Balanço_Patrimonial
{
    public class TipoBalancoPatrimonial
    {
        private int codTipoBalanco;
        public int CodTipoBalanco { get => codTipoBalanco; set => codTipoBalanco = value; }

        private string descricao;
        public string Descricao { get => descricao; set => descricao = value; }

    }
}
