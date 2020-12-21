using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class ClassificacaoEmpresa
    {
        private int codClassificacao;
        public int CodClassificacao { get => codClassificacao; set => codClassificacao = value; }

        private TipoClassificacao tipoClassificacao;
        public TipoClassificacao TipoClassificacao { get => tipoClassificacao; set => tipoClassificacao = value; }

        private DataEmpresa dataEmpresa;
        public DataEmpresa DataEmpresa { get => dataEmpresa; set => dataEmpresa = value; }

        private int flagAtivo;
        public int FlagAtivo { get => flagAtivo; set => flagAtivo = value; }
    }
}
