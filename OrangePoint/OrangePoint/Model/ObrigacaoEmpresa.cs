using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class ObrigacaoEmpresa
    {
        private int codObrigacaoEmpresa;
        public int CodObrigacaoEmpresa { get => codObrigacaoEmpresa; set => codObrigacaoEmpresa = value; }

        private Empresa empresa;
        public Empresa Empresa { get => empresa; set => empresa = value; }

        private TipoClassificacao tipoClassificacao;
        public TipoClassificacao TipoClassificacao { get => tipoClassificacao; set => tipoClassificacao = value; }

        private int tipoObrigacao;
        public int TipoObrigacao { get => tipoObrigacao; set => tipoObrigacao = value; }
    }
}
