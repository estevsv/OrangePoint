using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class AtividadeEmpresa
    {
        private int codAtividadeEmpresa;
        public int CodAtividadeEmpresa { get => codAtividadeEmpresa; set => codAtividadeEmpresa = value; }

        private Empresa empresa;
        public Empresa Empresa { get => empresa; set => empresa = value; }

        private Atividade atividade;
        public Atividade Atividade { get => atividade; set => atividade = value; }
    }
}
