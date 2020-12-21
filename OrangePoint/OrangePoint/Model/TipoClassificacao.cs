using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class TipoClassificacao
    {
        private int codTipoClassificacao;
        public int CodTipoClassificacao { get => codTipoClassificacao; set => codTipoClassificacao = value; }

        private string descricao;
        public string Descricao { get => descricao; set => descricao = value; }
    }
}
